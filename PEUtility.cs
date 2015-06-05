using Barbar.PEHandler.Parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Barbar.PEHandler
{
  public static class PEUtility
  {
    public static void Parse(StreamParser parser)
    {
      if (parser == null)
      {
        throw new ArgumentNullException("parser");
      }
      
      var header = new DosHeaderParser(parser).Load();
      parser.Seek(header.ELfaNew, SeekOrigin.Begin);
      var coff = new CoffHeaderParser(parser).Load();

      if (coff.SizeOfOptionalHeader == 0)
      {
        throw new Exception("SizeOfOptionalHeader is zero.");
      }
      var oh = new OptionalHeaderParser(parser).Load();

      var sections = new List<SectionTable>();
      for (var i = 0; i < coff.NumberOfSections; i++)
      {
        var section = new SectionTableParser(parser).Load();
        sections.Add(section);
      }
      var resources = sections.FirstOrDefault(r => r.ToString() == ".rsrc");
      if (resources != null)
      {
        parser.Seek(resources.PointerToRawData, SeekOrigin.Begin);
        var rawResources = new ResourceDirectoryTableParser(parser).Load();
        var dataEntries = rawResources.GetDataEntries();

        var rt = oh.ResourceTable;

        foreach (var dataEntry in dataEntries)
        {
          var language = dataEntry.Parent as ResourceDirectoryEntry;
          if (language != null && language.Parent != null)
          {
            var name = language.Parent.Parent as ResourceDirectoryEntry;
            if (name != null && name.Parent != null)
            {
              var type = name.Parent.Parent as ResourceDirectoryEntry;
              if (type != null)
              {
                parser.Seek(resources.PointerToRawData + dataEntry.OffsetToData - rt.VirtualAddress, SeekOrigin.Begin);
                switch (type.ID)
                {
                  case (uint)KnownResourceType.RT_VERSION:
                    var versionInfo = new VersionInfoParser(parser).Load();
                    break;
                  case (uint)KnownResourceType.RT_MANIFEST:
                    string manifest = new string(parser.ReadChars((int)dataEntry.Size, Encoding.UTF8));
                    break;
                  default:
                    break;
                }
              }
            }
          }
        }
      }
    }

    public static void Parse(string path)
    {
      if (string.IsNullOrEmpty(path))
      {
        throw new ArgumentNullException("path");
      }

      using (var stream = File.OpenRead(path))
      {
        var parser = new StreamParser(stream);
        Parse(parser);
      }
      
      



      

    }
  }
}
