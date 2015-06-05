using System.Text;

namespace Barbar.PEHandler.Parser
{
  public class SectionTableParser : BaseParser, ISectionParser<SectionTable>
  {
    public SectionTableParser(StreamParser parser)
      : base(parser)
    {
    }

    public SectionTable Load()
    {
      var result = new SectionTable();
      result.Name = parser.ReadChars(8, Encoding.UTF8);
      result.VirtualSize = parser.ReadInt32();
      result.VirtualAddress = parser.ReadInt32();
      result.SizeOfRawData = parser.ReadInt32();
      result.PointerToRawData = parser.ReadInt32();
      result.PointerToRelocations = parser.ReadInt32();
      result.PointerToLinenumbers = parser.ReadInt32();
      result.NumberOfRelocations = parser.ReadInt16();
      result.NumberOfLinenumbers = parser.ReadInt16();
      result.Characteristics = parser.ReadInt32();
      return result;
    }
  }
}