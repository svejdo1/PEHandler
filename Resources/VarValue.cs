
namespace Barbar.PEHandler.Resources
{
  public struct VarValue
  {
    private int m_Value;

    public VarValue(int value)
    {
      m_Value = value;
    }

    public override string ToString()
    {
      return string.Format("Codepage:{0},LCID:{1}", Codepage, LCID);
    }

    public int LCID
    {
      get { return m_Value & 0xFFFF; }
    }

    public int Codepage
    {
      get { return ((m_Value) >> 16); }
    }

    public static implicit operator int(VarValue varValue)
    {
      return varValue.m_Value;
    }

    public static implicit operator VarValue(int value)
    {
      return new VarValue(value);
    }
  }
}
