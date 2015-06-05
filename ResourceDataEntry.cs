
using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace Barbar.PEHandler
{
  public class ResourceDataEntry : IResourceDirectoryNode
  {
    private static readonly ReadOnlyCollection<IResourceDirectoryNode> s_Empty = new ReadOnlyCollection<IResourceDirectoryNode>(new List<IResourceDirectoryNode>());

    public uint OffsetToData { get; set; }
    public uint Size { get; set; }
    public uint CodePage { get; set; }
    public uint Reserved { get; set; }

    public long Position { get; set; }
    public IResourceDirectoryNode Parent { get; set; }
    public IList<IResourceDirectoryNode> Children
    {
      get { return s_Empty; }
    }
  }
}
