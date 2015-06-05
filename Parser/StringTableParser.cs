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
      }
      return result;
    }
  }
}
