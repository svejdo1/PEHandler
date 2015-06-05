using System.Collections.Generic;

namespace Barbar.PEHandler.Resources
{
  public class StringTable : BaseFileInfo
  {
    public int LCID
    {
      get { return int.Parse(Key.Substring(0, 4), System.Globalization.NumberStyles.HexNumber); }
    }
    public int Codepage
    {
      get { return int.Parse(Key.Substring(4, 4), System.Globalization.NumberStyles.HexNumber); }
    }

    public IList<ushort> Padding { get; set; }
    public IList<VersionString> Children { get; set; }
  }
}
