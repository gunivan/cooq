using CooQGenerate.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CooQGenerate
{
  public class TemplateConfigurer
  {
    private static Logs.Logger LOG = Logs.LogFactory.GetLog(typeof(TemplateConfigurer));
    private static String TEMPLATE_FOLDER = Path.Combine(Application.StartupPath, "templates");
    private static String DEST_SOURCE_FOLDER_DEFAULT = Path.Combine(Application.StartupPath, "DataAccess");
    private static String TEMPLATE_CONFIG_FILE = "template.conf";
    public readonly static String KEY_SOURCE_DIR = "${SRC}";
    private string destSourceDir;

    public List<TemplateConfig> TemplateConfigs { get; set; }
    public String TemplateName { get; set; }
    public String Namespace { get; set; }
    public String DestSourceDir
    {
      get { return destSourceDir; }
      set
      {
        if (String.IsNullOrEmpty(value))
          return;
        destSourceDir = value;
        foreach (var tc in TemplateConfigs)
        {
          tc.SetDestFolderName(KEY_SOURCE_DIR, value);
        }
      }
    }

    public TemplateConfigurer(String templateName)
    {
      TemplateName = templateName;
    }

    /// <summary>
    /// Get all supported template
    /// </summary>
    /// <returns></returns>
    public static List<TemplateConfigurer> LoadAllTemplates()
    {
      if (!Directory.Exists(TEMPLATE_FOLDER))
        throw new TemplateConfigException("Template folder not found.");
      var folders = Directory.GetDirectories(TEMPLATE_FOLDER);
      var list = new List<TemplateConfigurer>();
      foreach (var folder in folders)
      {
        var dir = new DirectoryInfo(folder);
        list.Add(LoadTemplateConfig(dir.Name));
      }
      return list;
    }

    /// <summary>
    /// Load config for template
    /// </summary>
    /// <param name="templateName"></param>
    /// <returns></returns>
    public static TemplateConfigurer LoadTemplateConfig(String templateName)
    {
      var configurer = new TemplateConfigurer(templateName);
      configurer.Load(templateName);
      return configurer;
    }

    public static String LoadTemplateString(String templateName, TemplateConfig config)
    {
      return File.ReadAllText(Path.Combine(Path.Combine(TEMPLATE_FOLDER, templateName), config.Name));
    }

    public static String GetTemplateStringFile(String templateName, TemplateConfig config)
    {
      return Path.Combine(Path.Combine(TEMPLATE_FOLDER, templateName), config.Name);
    }

    public void Load(String templateName)
    {
      var templateDir = Path.Combine(TEMPLATE_FOLDER, templateName);
      if (!Directory.Exists(templateDir))
        throw new TemplateConfigException("Template directory not found.");
      var configFile = Path.Combine(templateDir, TEMPLATE_CONFIG_FILE);
      if (!File.Exists(configFile))
      {
        throw new TemplateConfigException("Template config file not found.");
      }
      TemplateConfigs = new List<TemplateConfig>();
      var lines = File.ReadAllLines(configFile);
      LoadProperties(lines);
      LoadTemplates(templateDir, lines);
      LOG.Debug("Load config for template: {0}, templates: {1}", templateName, TemplateConfigs.Count);
    }

    private void LoadProperties(String[] lines)
    {
      var propConfigLines = lines.Where(l => l.Contains("="));
      Namespace = StringUtils.GetPropertyValue(propConfigLines.FirstOrDefault(l => l.Trim().StartsWith("namespace=")));
      DestSourceDir = StringUtils.GetPropertyValue(propConfigLines.FirstOrDefault(l => l.Trim().StartsWith("destdir=")));
      DestSourceDir = String.IsNullOrEmpty(DestSourceDir) ? DEST_SOURCE_FOLDER_DEFAULT : DestSourceDir;
    }

    void LoadTemplates(String templateDir, String[] lines)
    {
      var templatesConfigLines = lines.Where(l => !l.Contains("="));
      foreach (var l in templatesConfigLines)
      {
        if (!String.IsNullOrWhiteSpace(l) && !l.StartsWith("#"))
        {
          var tc = new TemplateConfig(l);
          //load template
          tc.TemplateString = File.ReadAllText(Path.Combine(templateDir, tc.Name));
          TemplateConfigs.Add(tc);
        }
      }
    }

    public override string ToString()
    {
      return this.TemplateName;
    }
  }
}
