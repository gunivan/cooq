using CooQ.Database;
using CooQ.Types;
using CooQGenerate.Utils;
using NVelocity;
using NVelocity.App;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CooQGenerate
{
  class TemplateGenerator
  {
    private static readonly Logs.Logger LOG = Logs.LogFactory.GetLog(typeof(TemplateGenerator));

    public static VelocityEngine Engine;

    static TemplateGenerator()
    {
      Init();
    }

    public static void Init()
    {
      if (null != Engine)
        return;
      Engine = new VelocityEngine();
      Engine.Init();
    }

    public static void Generate(GenerateRequest request)
    {
      Debug.Print("Save to folder:" + request.Configurer.DestSourceDir);
      var tables = request.Tables;
      var configurer = request.Configurer;
      var providerType = request.ProviderType;
      if (null == tables || tables.Count <= 0 || null == configurer)
        throw new CoooQGenerateException("No tables to generated");
      if (!Directory.Exists(configurer.DestSourceDir))
      {
        try
        {
          Directory.CreateDirectory(configurer.DestSourceDir);
        }
        catch
        {
          try
          {
            Directory.CreateDirectory(Path.Combine(Application.StartupPath, configurer.DestSourceDir));
          }
          catch (Exception e)
          {
            throw new CoooQGenerateException("Cannot create destination directory to store code file." + e.Message);
          }
        }
      }
      //loop each template config to generate to file
      foreach (var templateConfig in configurer.TemplateConfigs)
      {
        Task.Factory.StartNew(() =>
        {
          try
          {
            Debug.Print(String.Format("Start generate for template: {0}", templateConfig.Name));
            if (!Directory.Exists(templateConfig.DestFolderName))
            {
              Directory.CreateDirectory(templateConfig.DestFolderName);
            }
            if (templateConfig.IsSingle)
            {
              var context = GetContext(configurer, providerType);
              context.Put("tables", tables);
              var fileName = Path.Combine(templateConfig.DestFolderName, templateConfig.DestFileName);
              using (var sw = File.CreateText(fileName))
              {
                Engine.Evaluate(context, sw, null, templateConfig.TemplateString);
              }
            }
            else
            {
              var tasks = new List<Task>();
              foreach (var table in tables)
              {
                var task = new Task(() =>
                {
                  Debug.Print(String.Format("Start generate for template: {0}, table:{1}", templateConfig.Name, table.OriginName));
                  var t = table;
                  var context = GetContext(configurer, providerType);
                  context.Put("table", t);
                  var fileName = Path.Combine(templateConfig.DestFolderName,
                    templateConfig.DestFileName.Replace("${TABLE}", StringUtils.Capitalize(t.Name)));
                  using (var sw = File.CreateText(fileName))
                  {
                    Engine.Evaluate(context, sw, null, templateConfig.TemplateString);
                  }
                  Debug.Print(String.Format("End generate for template: {0}, table:{1}", templateConfig.Name, table.Name));
                });
                tasks.Add(task);
                task.Start();
              }
              Task.WaitAll(tasks.ToArray());
            }
          }
          catch (Exception ex)
          {
            Debug.Print(ex.Message);
            LOG.Error(ex);
          }
          finally
          {
            Debug.Print(String.Format("End generate for template:{0}", templateConfig.Name));
          }
        });
      }
    }

    private static VelocityContext GetContext(TemplateConfigurer configurer, DatabaseType type)
    {
      var context = new VelocityContext();
      context.Put("namespace", configurer.Namespace);
      context.Put("string", typeof(String));
      context.Put("fn", typeof(StringUtils));
      context.Put("providerType", String.Format("{0}.{1}", type.GetType().FullName, type));
      return context;
    }
  }
}
