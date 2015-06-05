using Barbar.PEHandler.Resources;
using System.Collections.Generic;

namespace Barbar.PEHandler.Parser
{
  public class VarParser : BaseFileInfoParser, ISectionParser<Var>
  {
    public VarParser(StreamParser parser)
      : base(parser)
    {
    }

    public Var Load()
    {
      Var result = new Var();
      DoLoad(result);
      if (result.Key != "Translation")
      {
        throw new ParseException(@"Expected token ""Translation"".");
      }

      result.Padding = parser.PadToFourBytes();
      result.Value = new List<VarValue>();
      for (var i = 0; i < result.ValueLength / 4; i++)
      {
        result.Value.Add(parser.ReadInt32());
      }
      return result;
    }
  }
}
