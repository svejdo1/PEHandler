
using System.Collections.Generic;
namespace Barbar.PEHandler
{
  public class ResourceDirectoryEntry : IResourceDirectoryNode
  {
    public uint ID { get; set; }
    public uint Rva { get; set; }

    public long Position { get; set; }
    public IResourceDirectoryNode Parent { get; set; }
    public ResourceDirectoryTable Table { get; set; }
    public ResourceDataEntry Data { get; set; }
    public IList<IResourceDirectoryNode> Children
    {
      get 
      {
        if ((Table == null && Data == null) || 
          (Table != null && Data != null))
        {
          throw new ParseException("Invalid node");
        }

        return new List<IResourceDirectoryNode>
        {
          Table == null ? (IResourceDirectoryNode)Data : Table
        };
      }
    }

    public bool IsPointerToSubdirectory
    {
      get
      {
        const uint FLAG = ((uint)1) << 31;
        return (FLAG & Rva) == FLAG;
      }
    }
    
    public uint Address
    {
      get
      {
        const uint FLAG = ((uint)1) << 31;
        if ((FLAG & Rva) == FLAG)
        {
          return FLAG ^ Rva;
        }
        return Rva;
      }
    }

    public override string ToString()
    {
      return string.Format("ID:{0},Address:{1},IsLeaf={2}", ID, Address, !IsPointerToSubdirectory);
    }
  }
}
