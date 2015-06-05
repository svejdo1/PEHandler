using System.Collections.Generic;

namespace Barbar.PEHandler.Resources
{
  public class VersionString : BaseFileInfo
  {
    public IList<ushort> Padding { get; set; }
    public string Value { get; set; }

    public override string ToString()
    {
      return string.Format("{0}={1}", Key, Value);
    }
  }
}
