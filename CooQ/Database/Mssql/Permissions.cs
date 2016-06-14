using CooQ;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooQ.Database.Mssql
{
  public sealed class GrantPermissions
  {
    private readonly List<GrantPermissions.PermSet> mPermList = new List<GrantPermissions.PermSet>();

    public void AddPermission(TableBase table, params Permission[] permissions)
    {
      if (table == null)
        throw new NullReferenceException("table cannot be null");
      if (permissions == null)
        throw new NullReferenceException("permissions cannot be null");
      this.mPermList.Add(new GrantPermissions.PermSet(table, permissions));
    }

    public string CreateGrantScript(string username, bool isReadonly)
    {
      if (string.IsNullOrWhiteSpace(username))
        throw new Exception("username cannot be null or empty");
      if (this.mPermList.Count == 0)
        return string.Empty;
      StringBuilder stringBuilder = new StringBuilder();
      Dictionary<string, object> dictionary = new Dictionary<string, object>();
      foreach (GrantPermissions.PermSet permissionSet in this.mPermList)
      {
        string key = permissionSet.Table.Name.ToLower();
        if (dictionary.ContainsKey(key))
          throw new Exception("Table is in permissions set more than once");
        dictionary.Add(key, null);
        if (!isReadonly || this.HasPermission(Permission.Select, permissionSet))
          stringBuilder.Append(this.CreateGrantLine(permissionSet, username, isReadonly));
        stringBuilder.Append(this.CreateRevokeLine(permissionSet, username, isReadonly));
      }
      return stringBuilder.ToString();
    }

    private string CreateGrantLine(GrantPermissions.PermSet permissionSet, string username, bool isReadonly)
    {
      StringBuilder stringBuilder = new StringBuilder();
      if (permissionSet.Permissions.Length == 0)
        return string.Empty;
      stringBuilder.Append("GRANT ");
      bool flag = false;
      if (this.HasPermission(Permission.Select, permissionSet))
      {
        if (flag)
          stringBuilder.Append(",");
        flag = true;
        stringBuilder.Append("SELECT");
      }
      if (!isReadonly)
      {
        if (this.HasPermission(Permission.Insert, permissionSet))
        {
          if (flag)
            stringBuilder.Append(",");
          flag = true;
          stringBuilder.Append("INSERT");
        }
        if (this.HasPermission(Permission.Update, permissionSet))
        {
          if (flag)
            stringBuilder.Append(",");
          flag = true;
          stringBuilder.Append("UPDATE");
        }
        if (this.HasPermission(Permission.Delete, permissionSet))
        {
          if (flag)
            stringBuilder.Append(",");
          flag = true;
          stringBuilder.Append("DELETE");
        }
      }
      if (!flag)
        return string.Empty;
      stringBuilder.Append(" ON ").Append(permissionSet.Table.Name).Append(" TO ").Append(username).Append(";").Append(Environment.NewLine);
      return stringBuilder.ToString();
    }

    private string CreateRevokeLine(GrantPermissions.PermSet permissionSet, string username, bool isReadonly)
    {
      StringBuilder stringBuilder = new StringBuilder();
      if (permissionSet.Permissions.Length == 0)
        return string.Empty;
      stringBuilder.Append("REVOKE ");
      bool flag = false;
      if (!this.HasPermission(Permission.Select, permissionSet))
      {
        if (flag)
          stringBuilder.Append(",");
        flag = true;
        stringBuilder.Append("SELECT");
      }
      if (isReadonly || !this.HasPermission(Permission.Insert, permissionSet))
      {
        if (flag)
          stringBuilder.Append(",");
        flag = true;
        stringBuilder.Append("INSERT");
      }
      if (isReadonly || !this.HasPermission(Permission.Update, permissionSet))
      {
        if (flag)
          stringBuilder.Append(",");
        flag = true;
        stringBuilder.Append("UPDATE");
      }
      if (isReadonly || !this.HasPermission(Permission.Delete, permissionSet))
      {
        if (flag)
          stringBuilder.Append(",");
        flag = true;
        stringBuilder.Append("DELETE");
      }
      if (!flag)
        return string.Empty;
      stringBuilder.Append(" ON ").Append(permissionSet.Table.Name).Append(" TO ").Append(username).Append(";").Append(Environment.NewLine);
      return stringBuilder.ToString();
    }

    private bool HasPermission(Permission perm, GrantPermissions.PermSet permissionSet)
    {
      foreach (Permission permission in permissionSet.Permissions)
      {
        if (permission == perm)
          return true;
      }
      return false;
    }

    private class PermSet
    {
      public TableBase Table { get; private set; }

      public Permission[] Permissions { get; private set; }

      public PermSet(TableBase table, Permission[] permissions)
      {
        this.Table = table;
        this.Permissions = permissions;
      }
    }
  }
}
