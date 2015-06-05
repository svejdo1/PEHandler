using Barbar.PEHandler.Resources;

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
      result.Value = parser.ReadInt32();
      return result;
    }
  }
}
