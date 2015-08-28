using CooQGenerate.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooQGenerate
{
  public class TemplateConfig
  {
    public String Name { get; set; }
    public String Description { get; set; }
    private String destFolderName { get; set; }
    public String DestFolderName { get; set; }
    public String DestFileName { get; set; }
    public Boolean IsSingle { get; set; }
    public Boolean Selected { get; set; }
    public String TemplateString { get; set; }
    public TemplateConfig(String config)
    {
      if (String.IsNullOrEmpty(config))
        return;
      var items = config.Split(';');
      Name = StringUtils.GetItemByIndex(items, 0);
      destFolderName = StringUtils.GetItemByIndex(items, 1);
      DestFileName = StringUtils.GetItemByIndex(items, 2);
      Description = StringUtils.GetItemByIndex(items, 3);
      IsSingle = "1".Equals(StringUtils.GetItemByIndex(items, 4));
    }

    public string SetDestFolderName(string key, string baseFolder)
    {
      DestFolderName = destFolderName.Replace(key, baseFolder);
      return DestFolderName;
    }
    public override string ToString()
    {
      return String.Format("Name:{0}", Name);
    }
  }
}
