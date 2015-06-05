using Barbar.PEHandler.Resources;

namespace Barbar.PEHandler.Parser
{
  public class FixedFileInfoParser : BaseParser, ISectionParser<FixedFileInfo>
  {
    public FixedFileInfoParser(StreamParser parser)
      : base(parser)
    {
    }

    public FixedFileInfo Load()
    {
      var result = new FixedFileInfo();

      result.Signature = parser.ReadUInt32();
      if (result.Signature != 0xFEEF04BD)
      {
        throw new ParseException("Expected value 0xFEEF04BD.");
      }

      result.StrucVersion = parser.ReadInt32();
      result.FileVersionMS = parser.ReadInt32();
      result.FileVersionLS = parser.ReadInt32();
      result.ProductVersionMS = parser.ReadInt32();
      result.ProductVersionLS = parser.ReadInt32();
      result.FileFlagsMask = parser.ReadInt32();
      result.FileFlags = parser.ReadInt32();
      result.FileOS = parser.ReadInt32();
      result.FileType = parser.ReadInt32();
      result.FileSubtype = parser.ReadInt32();
      result.FileDateMS = parser.ReadInt32();
      result.FileDateLS = parser.ReadInt32();

      return result;
    }
  }
}
