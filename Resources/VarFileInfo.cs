
using System.Collections.Generic;
namespace Barbar.PEHandler.Resources
{
  public class VarFileInfo : BaseFileInfo
  {
    public VarFileInfo()
    {
    }

    public VarFileInfo(BaseFileInfo baseFileInfo)
      : base(baseFileInfo)
    {
    }

    public IList<ushort> Padding { get; set; }
    public IList<Var> Children { get; set; }
  }
}
