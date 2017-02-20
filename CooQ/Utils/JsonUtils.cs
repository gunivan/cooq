using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Diagnostics;

namespace CooQGenerate.Utils
{
  public static class JsonUtils
  {
    public static bool Save(Object obj, string fileName)
    {
      DoTryCatch(() =>
      {
        if (!File.Exists(fileName))
        {
          var fileInfo = new FileInfo(fileName);
          Directory.CreateDirectory(fileInfo.Directory.FullName);
        }
        using (var textWriter = new StreamWriter(fileName))
        {
          textWriter.Write(JsonConvert.SerializeObject(obj, Formatting.None, new JsonSerializerSettings()
             {
               TypeNameHandling = TypeNameHandling.All
             }));
        }
      });

      return true;
    }

    public static T Load<T>(string fileName)
    {
      var retVal = default(T);

      if (!File.Exists(fileName))
      {
        return retVal;
      }
      DoTryCatch(() =>
      {
        using (TextReader textReader = new StreamReader(fileName))
        {
          retVal = JsonConvert.DeserializeObject<T>(textReader.ReadToEnd(), new JsonSerializerSettings()
             {
               TypeNameHandling = TypeNameHandling.All
             });
        }
      });
      return retVal;
    }

    public static String ToJson(Object obj)
    {
      return JsonConvert.SerializeObject(obj, Formatting.None,
          new JsonSerializerSettings()
          {
            TypeNameHandling = TypeNameHandling.All
          });
    }

    public static T FromJson<T>(String json)
    {
      return JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings()
      {
        TypeNameHandling = TypeNameHandling.All
      });
    }

    private static void DoTryCatch(Action action)
    {
      try
      {
        action();
      }
      catch
      {
      }
    }
  }
}
