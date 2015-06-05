using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Barbar.PEHandler
{
  [Serializable]
  public class ParseException : Exception
  {

    public ParseException(string message)
      : base(message)
    {
    }

    public ParseException(string format, params object[] args) :
      base(string.Format(format, args))
    {
    }
  }
}
