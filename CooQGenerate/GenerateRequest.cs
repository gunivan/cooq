using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooQGenerate
{
  class GenerateRequest
  {
    public TemplateConfigurer Configurer { get; set; }
    public IList<CooQ.Database.DbTable> Tables { get; set; }
    public CooQ.Types.DatabaseType ProviderType { get; set; }
  }
}
