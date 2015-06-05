using System.IO;

namespace Barbar.PEHandler
{
  public interface ISectionParser<T>
  {
    T Load();
  }
}
