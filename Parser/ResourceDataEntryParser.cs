using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Barbar.PEHandler.Parser
{
  public class ResourceDataEntryParser : BaseParser, ISectionParser<ResourceDataEntry>
  {
    private readonly IResourceDirectoryNode m_Parent;

    public ResourceDataEntryParser(StreamParser parser, IResourceDirectoryNode parent)
      : base(parser)
    {
      m_Parent = parent;
    }

    public ResourceDataEntry Load()
    {
      var result = new ResourceDataEntry { Position = parser.Position, Parent = m_Parent };

      result.OffsetToData = parser.ReadUInt32();
      result.Size = parser.ReadUInt32();
      result.CodePage = parser.ReadUInt32();
      result.Reserved = parser.ReadUInt32();

      return result;
    }
  }
}
