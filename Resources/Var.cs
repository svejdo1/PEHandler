using System.Collections.Generic;

namespace Barbar.PEHandler.Resources
{
  public class Var : BaseFileInfo
  {
    public IList<ushort> Padding { get; set; }
    public IList<VarValue> Value { get; set; }
  }
}
