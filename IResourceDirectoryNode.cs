using System.Collections.Generic;

namespace Barbar.PEHandler
{
  public interface IResourceDirectoryNode : IFilePosition
  {
    IResourceDirectoryNode Parent { get; set; }
    IList<IResourceDirectoryNode> Children { get; }
  }
}
