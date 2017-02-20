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
  class WorkingConfigService
  {
    private static string CONFIG_FILE_NAME = Path.Combine(Application.StartupPath, "work.conf");
    private static WorkingConfigService INSTANCE;
    public List<WorkingConfig> WORKS { get; set; }
    public Guid LastId;
    public static WorkingConfig CurrentSession;

    public WorkingConfigService()
    {
      WORKS = new List<WorkingConfig>();
    }

    public static WorkingConfig GetLastSession()
    {
      if (null != CurrentSession)
        return CurrentSession;
      if (null == INSTANCE)
        return null;
      CurrentSession = INSTANCE.WORKS.FirstOrDefault(c => c.Id == INSTANCE.LastId);
      return CurrentSession;
    }

    public static void LoadSavedSession()
    {
      INSTANCE = JsonUtils.Load<WorkingConfigService>(CONFIG_FILE_NAME);
      if (null == INSTANCE)
      {
        INSTANCE = new WorkingConfigService();
      }
    }

    public static void SaveSession(WorkingConfig config)
    {
      Task.Factory.StartNew(() =>
      {
        lock (INSTANCE)
        {
          if (config.Id == Guid.Empty)
            config.Id = Guid.NewGuid();
          var saved = INSTANCE.WORKS.FirstOrDefault(c => c.ServerSetting == config.ServerSetting);
          if (null == saved)
          {
            INSTANCE.WORKS.Add(config);
          }
          else
          {
            INSTANCE.WORKS.Remove(config);
            INSTANCE.WORKS.Add(config);
          }
          INSTANCE.LastId = config.Id;
          JsonUtils.Save(INSTANCE, CONFIG_FILE_NAME);
          CurrentSession = config;
        }
      });
    }
  }
}
