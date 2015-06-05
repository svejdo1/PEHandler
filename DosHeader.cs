using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Barbar.PEHandler
{
  public class DosHeader
  {
    public static readonly char[] SIGNATURE = new char[] { 'M', 'Z' };

    // offset 00
    public char[] Signature { get; set; }
    // offset 02
    public short NumberOfBytesInLastPage { get; set; }
    // offset 04
    public short NumberOfPages { get; set; }
    // offset 06
    public short NumberOfRelocationEntries { get; set; }
    // offset 08
    public short HeaderSizeInParagraphs { get; set; }
    // offset 0A
    public short MinimumParagraphs { get; set; }
    // offset 0C
    public short MaximumParagraphs { get; set; }
    // offset 0E
    public short Ss { get; set; }
    // offset 10
    public short Sp { get; set; }
    // offset 12
    public short Checksum { get; set; }
    // offset 14
    public short Ip { get; set; }
    // offset 16
    public short Cs { get; set; }
    // offset 18
    public short OffsetOfRealocationTable { get; set; }
    // offset 1A
    public short OverlayNumber { get; set; }
    public short[] Reserved1 { get; set; }
    public short OemId { get; set; }
    public short OemInfo { get; set; }
    public short[] Reserved2 { get; set; }
    public long ELfaNew { get; set; }
  }
}
