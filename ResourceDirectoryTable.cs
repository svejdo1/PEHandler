using System;
using System.Collections.Generic;

namespace Barbar.PEHandler
{
  public class ResourceDirectoryTable : IFilePosition, IResourceDirectoryNode
  {
    public int Characteristics { get; set; }
    public TimeType TimeDateStamp { get; set; }
    public short MajorVersion { get; set; }
    public short MinorVersion { get; set; }
    public short NumberOfNameEntries { get; set; }
    public short NumberOfIDEntries { get; set; }

    public IList<ResourceDirectoryEntry> NameEntries { get; set; }
    public IList<ResourceDirectoryEntry> IDEntries { get; set; }
    public IList<IResourceDirectoryNode> Children
    {
      get
      {
        var result = new List<IResourceDirectoryNode>(NumberOfIDEntries + NumberOfNameEntries);
        result.AddRange(NameEntries);
        result.AddRange(IDEntries);
        return result;
      }
    }

    public long Position { get; set; }
    public IResourceDirectoryNode Parent { get; set; }

    public IList<ResourceDataEntry> GetDataEntries()
    {
      var result = new List<ResourceDataEntry>();
      var stack = new Stack<IResourceDirectoryNode>();
      stack.Push(this);
      while (stack.Count > 0)
      {
        var node = stack.Pop();
        foreach (var childNode in node.Children)
        {
          var dataEntry = childNode as ResourceDataEntry;
          if (dataEntry != null)
          {
            result.Add(dataEntry);
          }
          stack.Push(childNode);
        }
      }

      return result;
    }

  }
}
