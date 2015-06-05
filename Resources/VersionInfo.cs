using System.Collections.Generic;

namespace Barbar.PEHandler.Resources
{
  public class VersionInfo : BaseFileInfo
  {
    public IList<ushort> Padding1 { get; set; }
    public FixedFileInfo Value { get; set; }
    public IList<ushort> Padding2 { get; set; }
    public VarFileInfo VarInfo { get; set; }
    public StringFileInfo StringInfo { get; set; }
  }
}
