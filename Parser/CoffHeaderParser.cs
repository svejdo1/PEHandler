using System;
using System.Linq;
using System.Text;

namespace Barbar.PEHandler.Parser
{
  public class CoffHeaderParser : BaseParser, ISectionParser<CoffHeader>
  {
    public CoffHeaderParser(StreamParser parser)
      : base(parser)
    {
    }

    public CoffHeader Load()
    {
      var result = new CoffHeader();
      result.Signature = parser.ReadChars(4, Encoding.ASCII);
      if (!CoffHeader.SIGNATURE.SequenceEqual(result.Signature))
      {
        throw new ParseException("Invalid header.");
      }
      result.Machine = parser.ReadInt16();
      result.NumberOfSections = parser.ReadInt16();
      result.TimeDateStamp = parser.ReadUInt32();
      result.PointerToSymbolTable = parser.ReadInt32();
      result.NumberOfSymbols = parser.ReadInt32();
      result.SizeOfOptionalHeader = parser.ReadInt16();
      result.Characteristics = parser.ReadInt16();

      return result;
    }
  }
}
