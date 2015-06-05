
namespace Barbar.PEHandler.Parser
{
  public class OptionalHeaderParser : BaseParser, ISectionParser<OptionalHeader>
  {
    public OptionalHeaderParser(StreamParser parser)
      : base(parser)
    {
    }

    public OptionalHeader Load()
    {
      var header = new OptionalHeader();
      header.Signature = (ushort)parser.ReadInt16();
      header.MajorLinkerVersion = parser.ReadByte();
      header.MinorLinkerVersion = parser.ReadByte();
      header.SizeOfCode = parser.ReadInt32();
      header.SizeOfInitializedData = parser.ReadInt32();
      header.SizeOfUninitializedData = parser.ReadInt32();
      header.AddressOfEntryPoint = parser.ReadInt32();
      header.BaseOfCode = parser.ReadInt32();
      if (header.KnownSignature == KnownOptionalHeaderSignature.NormalExe)
      {
        header.BaseOfData = parser.ReadInt32();
        header.ImageBase = parser.ReadInt32();
      }
      else
      {
        header.ImageBase = parser.ReadInt64();
      }
      header.SectionAlignment = parser.ReadInt32();
      header.FileAlignment = parser.ReadInt32();
      header.MajorOperatingSystemVersion = parser.ReadInt16();
      header.MinorOperatingSystemVersion = parser.ReadInt16();
      header.MajorImageVersion = parser.ReadInt16();
      header.MinorImageVersion = parser.ReadInt16();
      header.MajorSubsystemVersion = parser.ReadInt16();
      header.MinorSubsystemVersion = parser.ReadInt16();
      header.Win32VersionValue = parser.ReadInt32();
      header.SizeOfImage = parser.ReadInt32();
      header.SizeOfHeaders = parser.ReadInt32();
      header.CheckSum = parser.ReadInt32();
      header.Subsystem = parser.ReadInt16();

      header.DllCharacteristics = parser.ReadInt16();
      if (header.KnownSignature == KnownOptionalHeaderSignature.NormalExe)
      {
        header.SizeOfStackReserve = parser.ReadInt32();
        header.SizeOfStackCommit = parser.ReadInt32();
        header.SizeOfHeapReserve = parser.ReadInt32();
        header.SizeOfHeapCommit = parser.ReadInt32();
      }
      else
      {
        header.SizeOfStackReserve = parser.ReadInt64();
        header.SizeOfStackCommit = parser.ReadInt64();
        header.SizeOfHeapReserve = parser.ReadInt64();
        header.SizeOfHeapCommit = parser.ReadInt64();
      }
      header.LoaderFlags = parser.ReadInt32();
      header.NumberOfRvaAndSizes = parser.ReadInt32();

      var iddParser = new ImageDataDirectoryParser(parser);
      int number = header.NumberOfRvaAndSizes;
      if (number > 0)
      {
        header.ExportTable = iddParser.Load();
        number--;
      }
      if (number > 0)
      {
        header.ImportTable = iddParser.Load();
        number--;
      }
      if (number > 0)
      {
        header.ResourceTable = iddParser.Load();
        number--;
      }
      if (number > 0)
      {
        header.ExceptionTable = iddParser.Load();
        number--;
      }
      if (number > 0)
      {
        header.CertificateTable = iddParser.Load();
        number--;
      }
      if (number > 0)
      {
        header.BaseRelocationTable = iddParser.Load();
        number--;
      }
      if (number > 0)
      {
        header.DebugTable = iddParser.Load();
        number--;
      }
      if (number > 0)
      {
        header.Architecture = iddParser.Load();
        number--;
      }
      if (number > 0)
      {
        header.GlobalPtr = iddParser.Load();
        number--;
      }
      if (number > 0)
      {
        header.TlsTable = iddParser.Load();
        number--;
      }
      if (number > 0)
      {
        header.LoadConfigTable = iddParser.Load();
        number--;
      }
      if (number > 0)
      {
        header.BoundImportTable = iddParser.Load();
        number--;
      }
      if (number > 0)
      {
        header.ImportAddressTable = iddParser.Load();
        number--;
      }
      if (number > 0)
      {
        header.DelayImportDescriptor = iddParser.Load();
        number--;
      }
      if (number > 0)
      {
        header.ClrHeader = iddParser.Load();
        number--;
      }
      if (number > 0)
      {
        header.Reserved = iddParser.Load();
        number--;
      }


      return header;
    }
  }
}
