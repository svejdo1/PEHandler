using System.Collections.Generic;

namespace Barbar.PEHandler.Resources
{
  public class Var : BaseFileInfo
  {
    public IList<ushort> Padding { get; set; }
    public int Value { get; set; }

    public int IbmCodePage
    {
      get { return Value & 0xFFFF; }
    }

    public int MicrosoftLanguageID
    {
      get { return ((Value) >> 16); }
    }
  }
}
