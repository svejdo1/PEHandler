
using System;
namespace Barbar.PEHandler.Parser
{
  public class ResourceDirectoryEntryParser : BaseParser, ISectionParser<ResourceDirectoryEntry>
  {
    private readonly IResourceDirectoryNode m_Parent;

    public ResourceDirectoryEntryParser(StreamParser parser, IResourceDirectoryNode parent)
      : base(parser)
    {
      if (parent == null)
      {
        throw new ArgumentNullException("parent");
      }

      m_Parent = parent;
    }

    public ResourceDirectoryEntry Load()
    {
      var result = new ResourceDirectoryEntry { Parent = m_Parent, Position = parser.Position };

      result.ID = parser.ReadUInt32();
      result.Rva = parser.ReadUInt32();
      return result;
    }
  }
}
