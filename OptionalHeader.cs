using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Barbar.PEHandler
{
  public class OptionalHeader
  {
    public ushort Signature { get; set; }
    public byte MajorLinkerVersion { get; set; }
    public byte MinorLinkerVersion { get; set; }
    public int SizeOfCode { get; set; }
    public int SizeOfInitializedData { get; set; }
    public int SizeOfUninitializedData { get; set; }
    public int AddressOfEntryPoint { get; set; }
    public int BaseOfCode { get; set; }
    public int BaseOfData { get; set; }
    public long ImageBase { get; set; }
    public int SectionAlignment { get; set; }
    public int FileAlignment { get; set; }
    public short MajorOperatingSystemVersion { get; set; }
    public short MinorOperatingSystemVersion { get; set; }
    public short MajorImageVersion { get; set; }
    public short MinorImageVersion { get; set; }
    public short MajorSubsystemVersion { get; set; }
    public short MinorSubsystemVersion { get; set; }
    public int Win32VersionValue { get; set; }
    public int SizeOfImage { get; set; }
    public int SizeOfHeaders { get; set; }
    public int CheckSum { get; set; }
    public short Subsystem { get; set; }
    public short DllCharacteristics { get; set; }
    public long SizeOfStackReserve { get; set; }
    public long SizeOfStackCommit { get; set; }
    public long SizeOfHeapReserve { get; set; }
    public long SizeOfHeapCommit { get; set; }
    public int LoaderFlags { get; set; }
    public int NumberOfRvaAndSizes { get; set; }
    public ImageDataDirectory ExportTable { get; set; }
    public ImageDataDirectory ImportTable { get; set; }
    public ImageDataDirectory ResourceTable { get; set; }
    public ImageDataDirectory ExceptionTable { get; set; }
    public ImageDataDirectory CertificateTable { get; set; }
    public ImageDataDirectory BaseRelocationTable { get; set; }
    public ImageDataDirectory DebugTable { get; set; }
    public ImageDataDirectory Architecture { get; set; }
    public ImageDataDirectory GlobalPtr { get; set; }
    public ImageDataDirectory TlsTable { get; set; }
    public ImageDataDirectory LoadConfigTable { get; set; }
    public ImageDataDirectory BoundImportTable { get; set; }
    public ImageDataDirectory ImportAddressTable { get; set; }
    public ImageDataDirectory DelayImportDescriptor { get; set; }
    public ImageDataDirectory ClrHeader { get; set; }
    public ImageDataDirectory Reserved { get; set; }

    public KnownOptionalHeaderSignature KnownSignature
    {
      get { return (KnownOptionalHeaderSignature)Signature; }
      set { Signature = (ushort)value; }
    }
  }
}
