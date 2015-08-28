using System.Text;

namespace CooQ.Core
{
  public class AlaisCounter
  {
    private static readonly char[] CHARS = new char[36]
    {
      '0',
      '1',
      '2',
      '3',
      '4',
      '5',
      '6',
      '7',
      '8',
      '9',
      'a',
      'b',
      'c',
      'd',
      'e',
      'f',
      'g',
      'h',
      'i',
      'j',
      'k',
      'l',
      'm',
      'n',
      'o',
      'p',
      'q',
      'r',
      's',
      't',
      'u',
      'v',
      'w',
      'x',
      'y',
      'z'
    };
    private int[] mCounter = (int[]) null;

    /// <summary>
    /// Returns the next alias value.
    /// 
    /// </summary>
    /// 
    /// <returns/>
    public string GetNextAlias()
    {
      lock (this)
      {
        if (this.mCounter == null)
        {
          this.mCounter = new int[1];
        }
        else
        {
          bool local_0 = true;
          int local_1 = checked (this.mCounter.Length - 1);
          while (local_1 >= 0)
          {
            if (this.mCounter[local_1] == checked (AlaisCounter.CHARS.Length - 1))
            {
              this.mCounter[local_1] = 0;
              checked { --local_1; }
            }
            else
            {
              checked { ++this.mCounter[local_1]; }
              local_0 = false;
              break;
            }
          }
          if (local_0)
            this.mCounter = new int[checked (this.mCounter.Length + 1)];
        }
        return this.GetCurrentAlias();
      }
    }

    private string GetCurrentAlias()
    {
      StringBuilder stringBuilder = new StringBuilder();
      int index = 0;
      while (index < this.mCounter.Length)
      {
        stringBuilder.Append(AlaisCounter.CHARS[this.mCounter[index]]);
        checked { ++index; }
      }
      return stringBuilder.ToString();
    }
  }
}
