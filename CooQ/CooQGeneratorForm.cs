using CooQ;
using CooQ.Database;
using CooQ.Types;
using CooQGenerate.Utils;
using NVelocity;
using NVelocity.App;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CooQGenerate
{
  public partial class CooQGeneratorForm : Form
  {
    TextBoxWriter writerPreview;
    Boolean isChanged = false;
    IList<DbTable> tables;
    CooQ.Types.DatabaseType providerType;

    public CooQGeneratorForm()
    {
      InitializeComponent();
      var txtWriter = new TextBoxWriter(txtConsole);
      Console.SetOut(txtWriter);
      var traceDebugOutput = new TextWriterTraceListener(txtWriter);
      Trace.Listeners.Add(traceDebugOutput);
      txtConsole.MakeDoubleBuffered(true);
      writerPreview = new TextBoxWriter(txtPreview);
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      Task.Factory.StartNew(() =>
      {
        TemplateGenerator.Init();
      });
      Task.Factory.StartNew(() =>
      {
        WorkingConfigService.LoadSavedSession();
        BindWorking();
      });
      LoadAllTemplate();
      if (cbSupportedTemplates.Items.Count > 0)
        cbSupportedTemplates.SelectedIndex = 0;
      cbDatabaseType.Items.Add(DatabaseType.MSSQL);
      cbDatabaseType.Items.Add(DatabaseType.POSTGRESQL);
      cbDatabaseType.SelectedIndex = 0;
      cbDatabaseType.SelectedIndexChanged += cbDatabaseType_SelectedIndexChanged;
    }

    void cbDatabaseType_SelectedIndexChanged(object sender, EventArgs e)
    {
      providerType = (DatabaseType)cbDatabaseType.SelectedItem;
      txtDatabase.Text = "HaVa";
      if (DatabaseType.MSSQL.Equals(providerType))
      {
        txtHost.Text = @"ADMIN-PC\WINTASERVER";
      }
      else
      {
        txtHost.Text = @"192.168.1.102";
        txtPort.Text = "5432";
        txtUser.Text = "postgres";
        txtPass.Text = "root";
      }
    }

    void LoadAllTemplate()
    {
      var templates = TemplateConfigurer.LoadAllTemplates();
      cbSupportedTemplates.Items.Clear();
      foreach (var item in templates)
      {
        cbSupportedTemplates.Items.Add(item);
      }
    }

    private void btnLoadTable_Click(object sender, EventArgs e)
    {
      LoadTable();
    }

    private void LoadTable()
    {
      Debug.Print("Init connection...");
      var setting = GetConnectionSetting();
      SaveWorking(setting);
      Query.Init(setting);
      Debug.Print("Begin load tables... for type:" + providerType);
      tables = SchemaFactory.GetTables(DatabaseProvider.INSTANCE.GetConnection(), setting.Type);
      Debug.Print(String.Format("Found: {0} table", tables.Count));
    }


    private void rtbTemplate_TextChangedDelayed(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
    {
      isChanged = true;
    }

    private void btnGenerate_Click(object sender, EventArgs e)
    {
      var selectedTemplate = cbSupportedTemplates.SelectedItem as TemplateConfigurer;
      if (null == selectedTemplate)
        throw new Exception("No template selected.");

      if (null == tables || tables.Count <= 0)
      {
        LoadTable();
      }

      ThreadPool.SetMaxThreads(500, 500);
      var lastSession = WorkingConfigService.GetLastSession();
      if (null != lastSession)
      {
        selectedTemplate.DestSourceDir = lastSession.DestDir ?? selectedTemplate.DestSourceDir;
      }
      TemplateGenerator.Generate(new GenerateRequest()
      {
        Configurer = selectedTemplate,
        Tables = tables,
        ProviderType = providerType
      });
    }

    private void cbSupportedTemplates_SelectedIndexChanged(object sender, EventArgs e)
    {
      var selectedTemplate = cbSupportedTemplates.SelectedItem as TemplateConfigurer;
      if (null == selectedTemplate)
        return;
      cbTemplateFiles.Items.Clear();
      foreach (var item in selectedTemplate.TemplateConfigs)
      {
        cbTemplateFiles.Items.Add(item);
      }
      //display save to
      txtSaveTo.Text = selectedTemplate.DestSourceDir;
    }

    private void cbTemplateFiles_SelectedIndexChanged(object sender, EventArgs e)
    {
      var selectedTemplate = cbSupportedTemplates.SelectedItem as TemplateConfigurer;
      if (null == selectedTemplate)
        return;
      var selectedConfig = cbTemplateFiles.SelectedItem as TemplateConfig;
      rtbTemplate.Text = TemplateConfigurer.LoadTemplateString(selectedTemplate.TemplateName, selectedConfig);
    }

    private void SaveTemplateConfig()
    {
      var selectedTemplate = cbSupportedTemplates.SelectedItem as TemplateConfigurer;
      if (null == selectedTemplate)
        return;
      var selectedConfig = cbTemplateFiles.SelectedItem as TemplateConfig;
      var file = TemplateConfigurer.GetTemplateStringFile(selectedTemplate.TemplateName, selectedConfig);
      using (var sw = new StreamWriter(file))
      {
        sw.Write(rtbTemplate.Text);
      }
    }

    private void UpdatePreview()
    {
      lock (this)
      {
        try
        {
          var context = new VelocityContext();
          context.Put("table", GetDbTableTemp());
          context.Put("namespace", "DataAccess");
          context.Put("string", typeof(String));
          context.Put("fn", typeof(StringUtils));
          context.Put("providerType", String.Format("{0}.{1}", DatabaseType.MSSQL.GetType(), DatabaseType.MSSQL));
          txtPreview.ExeInvoke(() =>
          {
            txtPreview.Clear();
          });
          var evaluateOk = TemplateGenerator.Engine.Evaluate(context, writerPreview, null, rtbTemplate.Text);
          if (evaluateOk)
          {
            rtbPreview.ExeInvoke(() =>
            {
              rtbPreview.Text = txtPreview.Text;
            });
          }
        }
        catch (Exception ex)
        {
          Debug.Print("Error when preview template:" + ex.Message);
          Logs.LogFactory.Error(ex);
        }
      }
    }

    private DbTable GetDbTableTemp()
    {
      var dbTable = new DbTable("table_test", "schema_test", new List<DbColumn>()
      {                                                                   
        new DbColumn("column1", DbType.String, true, false, false, false),
        new DbColumn("column2", DbType.String, true, false, false, false),
        new DbColumn("primary_column", DbType.Int64, false, true, true, false)
      });
      foreach (var item in dbTable.Columns)
      {
        item.ColumnTypeName = SchemaFactory.GetColumnTypeName(item.DbType, "table_test", item.IsPrimaryKey, item.Nullable);
      }
      return dbTable;
    }

    private void btnPreview_Click(object sender, EventArgs e)
    {
      UpdatePreview();
    }

    private void rtbTemplate_Leave(object sender, EventArgs e)
    {
      if (isChanged)
      {
        if (MessageBox.Show("Do you want to save template?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
        {
          SaveTemplateConfig();
        }
      }
      isChanged = false;
    }

    private void btnBrowseSaveTo_Click(object sender, EventArgs e)
    {
      var op = new FolderBrowserDialog();
      if (op.ShowDialog() == System.Windows.Forms.DialogResult.OK)
      {
        txtSaveTo.Text = op.SelectedPath;
      }
    }

    ConnectionSetting GetConnectionSetting()
    {
      return new ConnectionSetting()
      {
        Server = txtHost.Text,
        Database = txtDatabase.Text,
        Port = txtPort.Text,
        Username = txtUser.Text,
        Password = txtPass.Text,
        Type = providerType
      };
    }

    void BindWorking()
    {
      var config = WorkingConfigService.GetLastSession();
      if (null == config)
        return;
      Task.Factory.StartNew(() =>
      {
        cbDatabaseType.ExeInvoke(() =>
        {
          cbDatabaseType.SelectedItem = config.ServerSetting.Type;
        });
        txtHost.ExeInvoke(() =>
        {
          txtHost.Text = config.ServerSetting.Server;
        });
        txtDatabase.ExeInvoke(() =>
        {
          txtDatabase.Text = config.ServerSetting.Database;
        });
        txtUser.ExeInvoke(() =>
        {
          txtUser.Text = config.ServerSetting.Username;
        });
        txtPass.ExeInvoke(() =>
        {
          txtPass.Text = config.ServerSetting.Password;
        });
        txtPort.ExeInvoke(() =>
        {
          txtPort.Text = config.ServerSetting.Port;
        });

        txtSaveTo.ExeInvoke(() =>
        {
          txtSaveTo.Text = config.DestDir;
        });
      });
    }

    void SaveWorking(ConnectionSetting connectionSetting = null)
    {
      var setting = connectionSetting ?? GetConnectionSetting();
      try
      {
        var item = WorkingConfigService.CurrentSession;
        if (null == item)
          item = new WorkingConfig();
        item.DestDir = txtSaveTo.Text;
        item.ServerSetting = setting;
        WorkingConfigService.SaveSession(item);
      }
      catch (Exception e)
      {
        Logs.LogFactory.Error("Cannot save working session." + e.Message, e);
      }
    }
  }
}
