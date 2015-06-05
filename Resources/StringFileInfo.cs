using System.Collections.Generic;

namespace Barbar.PEHandler.Resources
{
  public class StringFileInfo : BaseFileInfo
  {
    public IList<ushort> Padding { get; set; }
    public IList<StringTable> Children { get; set; }


    public StringFileInfo()
    {
    }

    public StringFileInfo(BaseFileInfo info)
      : base(info)
    {
    }
  }
}
