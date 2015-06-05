
using System;
namespace Barbar.PEHandler.Resources
{
  public class BaseFileInfo : IFilePosition
  {
    public ushort Length { get; set; }
    public ushort ValueLength { get; set; }
    public ushort Type { get; set; }
    public string Key { get; set; }

    public long Position { get; set; }

    public BaseFileInfo()
    {
    }

    public BaseFileInfo(BaseFileInfo baseFileInfo)
    {
      if (baseFileInfo == null)
      {
        throw new ArgumentNullException("baseFileInfo");
      }
      Length = baseFileInfo.Length;
      ValueLength = baseFileInfo.ValueLength;
      Type = baseFileInfo.Type;
      Key = baseFileInfo.Key;
      Position = baseFileInfo.Position;
    }
  }
}
