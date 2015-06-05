using System.Linq;

namespace Barbar.PEHandler
{
  public class SectionTable
  {
    public char[] Name { get; set; }
    public int VirtualSize { get; set; }
    public int VirtualAddress { get; set; }
    public int SizeOfRawData { get; set; }
    public int PointerToRawData { get; set; }
    public int PointerToRelocations { get; set; }
    public int PointerToLinenumbers { get; set; }
    public short NumberOfRelocations { get; set; }
    public short NumberOfLinenumbers { get; set; }
    public int Characteristics { get; set; }

    public override string ToString()
    {
      if (Name == null || Name.Length != 8)
      {
        return "Undefined";
      }
      for (var i = 0; i < 8; i++)
      {
        if (Name[i] == '\0')
        {
          return new string(Name, 0, i);
        }
      }

      return new string(Name);
    }
  }
}
