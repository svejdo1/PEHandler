using System;

namespace Barbar.PEHandler.Parser
{
  public class BaseParser
  {
    protected StreamParser parser;

    public BaseParser(StreamParser parser)
    {
      if (parser == null)
      {
        throw new ArgumentNullException("parser");
      }

      this.parser = parser;
    }
  }
}
