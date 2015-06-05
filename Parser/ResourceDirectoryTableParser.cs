using System.Collections.Generic;
using System.IO;

namespace Barbar.PEHandler.Parser
{
  public class ResourceDirectoryTableParser : BaseParser, ISectionParser<ResourceDirectoryTable>
  {
    public ResourceDirectoryTableParser(StreamParser parser)
      : base(parser)
    {
    }

    private ResourceDirectoryTable LoadHeader(IResourceDirectoryNode parent)
    {
      var result = new ResourceDirectoryTable();

      result.Position = parser.Position;

      result.Characteristics = parser.ReadInt32();
      result.TimeDateStamp = parser.ReadUInt32();
      result.MajorVersion = parser.ReadInt16();
      result.MinorVersion = parser.ReadInt16();
      result.NumberOfNameEntries = parser.ReadInt16();
      result.NumberOfIDEntries = parser.ReadInt16();
      result.Parent = parent;

      result.NameEntries = new List<ResourceDirectoryEntry>();
      for (var i = 0; i < result.NumberOfNameEntries; i++)
      {
        var entry = new ResourceDirectoryEntryParser(parser, result).Load();
        result.NameEntries.Add(entry);
      }
      result.IDEntries = new List<ResourceDirectoryEntry>();
      for (var i = 0; i < result.NumberOfIDEntries; i++)
      {
        var entry = new ResourceDirectoryEntryParser(parser, result).Load();
        result.IDEntries.Add(entry);
      }

      return result;
    }

    private ResourceDirectoryTable FetchChildren(ResourceDirectoryTable result)
    {
      var root = result.Root();
      foreach (ResourceDirectoryEntry entry in result.Children)
      {
        parser.Seek(root.Position + entry.Address, SeekOrigin.Begin);
        if (entry.IsPointerToSubdirectory)
        {
          entry.Table = LoadHeader(entry);
          FetchChildren(entry.Table);
        }
        else
        {
          entry.Data = new ResourceDataEntryParser(parser, entry).Load();
        }
      }

      return result;
    }

    public ResourceDirectoryTable Load()
    {
      return FetchChildren(LoadHeader(null));
    }
  }
}
