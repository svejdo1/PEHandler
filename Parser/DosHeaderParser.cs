using System;
using System.Linq;
using System.Text;

namespace Barbar.PEHandler.Parser
{
  public class DosHeaderParser : BaseParser, ISectionParser<DosHeader>
  {
    public DosHeaderParser(StreamParser parser)
      : base(parser)
    {
    }

    public DosHeader Load()
    {
      if (parser == null)
      {
        throw new ArgumentNullException("parser");
      }

      var result = new DosHeader();
      result.Signature = parser.ReadChars(2, Encoding.ASCII);
      if (!DosHeader.SIGNATURE.SequenceEqual(result.Signature))
      {
        throw new ParseException("Invalid header.");
      }
      result.NumberOfBytesInLastPage = parser.ReadInt16();
      result.NumberOfPages = parser.ReadInt16();
      result.NumberOfRelocationEntries = parser.ReadInt16();
      result.HeaderSizeInParagraphs = parser.ReadInt16();
      result.MinimumParagraphs = parser.ReadInt16();
      result.MaximumParagraphs = parser.ReadInt16();
      result.Ss = parser.ReadInt16();
      result.Sp = parser.ReadInt16();
      result.Checksum = parser.ReadInt16();
      result.Ip = parser.ReadInt16();
      result.Cs = parser.ReadInt16();
      result.OffsetOfRealocationTable = parser.ReadInt16();
      result.OverlayNumber = parser.ReadInt16();
      
      result.Reserved1 = parser.ReadInt16s(4);
      result.OemId = parser.ReadInt16();
      result.OemInfo = parser.ReadInt16();
      result.Reserved2 = parser.ReadInt16s(10);
      result.ELfaNew = parser.ReadInt32();

      return result;
    }
  }
}
