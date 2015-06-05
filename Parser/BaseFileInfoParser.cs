using Barbar.PEHandler.Resources;
using System;

namespace Barbar.PEHandler.Parser
{
  public class BaseFileInfoParser : BaseParser, ISectionParser<BaseFileInfo>
  {
    public BaseFileInfoParser(StreamParser parser)
      : base(parser)
    {
    }

    protected void DoLoad(BaseFileInfo result)
    {
      if (result == null)
      {
        throw new ArgumentNullException("result");
      }
      result.Position = parser.Position;
      result.Length = parser.ReadUInt16();
      result.ValueLength = parser.ReadUInt16();
      result.Type = parser.ReadUInt16();
      result.Key = parser.ReadUnicodeString();
    }

    BaseFileInfo ISectionParser<BaseFileInfo>.Load()
    {
      var result = new BaseFileInfo();
      DoLoad(result);
      return result;
    }
  }
}
