using System;

namespace Barbar.PEHandler
{
  static class Extensions
  {
    public static IResourceDirectoryNode Root(this IResourceDirectoryNode node)
    {
      if (node == null)
      {
        throw new ArgumentNullException("node");
      }

      while(node.Parent != null)
      {
        node = node.Parent;
      }

      return node;
    }
  }
}
