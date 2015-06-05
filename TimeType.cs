using System;

namespace Barbar.PEHandler
{
  public struct TimeType
  {
    private uint m_Value;

    public TimeType(uint value)
    {
      m_Value = value;
    }

    public DateTime AsDate
    {
      get { return new DateTime(1970, 1, 1).AddSeconds(m_Value); }
    }

    public override string ToString()
    {
      return AsDate.ToString();
    }

    public static implicit operator uint(TimeType time)
    {
      return time.m_Value;
    }

    public static implicit operator TimeType(uint value)
    {
      return new TimeType(value);
    }
  }
}
