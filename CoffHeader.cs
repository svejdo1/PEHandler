using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Barbar.PEHandler
{
  public class CoffHeader
  {
    public static readonly char[] SIGNATURE = new char[] { 'P', 'E', '\0', '\0' };

    public char[] Signature { get; set; }
    public short Machine { get; set; }
    public short NumberOfSections { get; set; }
    public TimeType TimeDateStamp { get; set; }
    public int PointerToSymbolTable { get; set; }
    public int NumberOfSymbols { get; set; }
    public short SizeOfOptionalHeader { get; set; }
    public short Characteristics { get; set; }

    public KnownMachineType KnownMachine
    {
      get { return (KnownMachineType)Machine; }
      set { Machine = (short)value; }
    }
  }
}
