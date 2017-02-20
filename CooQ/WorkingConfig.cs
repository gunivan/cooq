using CooQGenerate.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooQGenerate
{

  [JsonObject]
  public class WorkingConfig
  {
    [JsonProperty("id")]
    public Guid Id { get; set; }
    [JsonProperty("items")]
    public CooQ.ConnectionSetting ServerSetting { get; set; }
    [JsonProperty("dest")]

    public String DestDir { get; set; }
  }
}
