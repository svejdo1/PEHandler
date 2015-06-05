
namespace Barbar.PEHandler.Resources
{
  public class FixedFileInfo
  {
    public uint Signature { get; set; }
    public int StrucVersion { get; set; }
    public int FileVersionMS { get; set; }
    public int FileVersionLS { get; set; }
    public int ProductVersionMS { get; set; }
    public int ProductVersionLS { get; set; }
    public int FileFlagsMask { get; set; }
    public int FileFlags { get; set; }
    public int FileOS { get; set; }
    public int FileType { get; set; }
    public int FileSubtype { get; set; }
    public int FileDateMS { get; set; }
    public int FileDateLS { get; set; }
  }
}
