using Barbar.PEHandler.Resources;
using System;
using System.Collections.Generic;

namespace Barbar.PEHandler.Parser
{
  public class VersionInfoParser : BaseFileInfoParser, ISectionParser<VersionInfo>
  {
    public VersionInfoParser(StreamParser parser)
      : base(parser)
    {
    }

    public VersionInfo Load()
    {
      var result = new VersionInfo();
      base.DoLoad(result);
      const string KEY_VALUE = "VS_VERSION_INFO";
      if (!string.Equals(result.Key, KEY_VALUE, StringComparison.OrdinalIgnoreCase))
      {
        throw new ParseException(@"Expected token ""{0}"".", KEY_VALUE);
      }
      result.Padding1 = new List<ushort>();
      if (result.ValueLength != 0)
      {
        result.Padding1 = parser.PadToFourBytes();
        result.Value = new FixedFileInfoParser(parser).Load();
      }
      result.Padding2 = parser.PadToFourBytes();

      var baseFileInfoParser = (ISectionParser<BaseFileInfo>)this;
      while(parser.Position - result.Position < result.Length)
      {
        var info = baseFileInfoParser.Load();
        switch(info.Key)
        {
          case "VarFileInfo":
            result.VarInfo = new VarFileInfo(info);
            result.VarInfo.Padding = parser.PadToFourBytes();
            result.VarInfo.Children = new List<Var>();
            while (parser.Position - result.VarInfo.Position < result.VarInfo.Length)
            {
              result.VarInfo.Children.Add(new VarParser(parser).Load());
            }
            break;
          case "StringFileInfo":
            result.StringInfo = new StringFileInfo(info);
            result.StringInfo.Padding = parser.PadToFourBytes();
            result.StringInfo.Children = new List<StringTable>();
            while(parser.Position - result.StringInfo.Position < result.StringInfo.Length)
            {
              result.StringInfo.Children.Add(new StringTableParser(parser).Load());
            }
            break;
          default:
            throw new ParseException(@"Unknown Key ""{0}""", info.Key);
        }
      }

      return result;
    }
  }
}
