using Barbar.PEHandler.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace Barbar.PEHandler.Parser
{
  public class StringTableParser : BaseFileInfoParser, ISectionParser<StringTable>
  {
    public StringTableParser(StreamParser parser)
      : base(parser)
    {
    }

    public StringTable Load()
    {
      var result = new StringTable();
      DoLoad(result);
      // todo remove
      long position = parser.Position;
      parser.Seek(result.Position, System.IO.SeekOrigin.Begin);
      byte[] buffer = parser.ReadBytes(result.Length);
      parser.Seek(position, System.IO.SeekOrigin.Begin);

      

      if (result.Key.Length != 8)
      {
        throw new ParseException("Invalid StringTable szKey - eight hex digits expected.");
      }

      result.Padding = parser.PadToFourBytes();
      result.Children = new List<VersionString>();
      while(parser.Position - result.Position < result.Length)
      {
        var versionString = new VersionString();
        DoLoad(versionString);
        versionString.Padding = parser.PadToFourBytes();
        versionString.Value = parser.ReadUnicodeString();
        result.Children.Add(versionString);
        while ((parser.Position % 4) != 0)
        {
          parser.ReadUInt16();
        }

      }
      return result;
    }
  }
}
