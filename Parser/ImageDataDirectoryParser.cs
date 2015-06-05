
namespace Barbar.PEHandler.Parser
{
  public class ImageDataDirectoryParser : BaseParser, ISectionParser<ImageDataDirectory>
  {
    public ImageDataDirectoryParser(StreamParser parser)
      : base(parser)
    {
    }

    public ImageDataDirectory Load()
    {
      var result = new ImageDataDirectory();
      result.VirtualAddress = parser.ReadInt32();
      result.Size = parser.ReadInt32();
      return result;
    }
  }
}
