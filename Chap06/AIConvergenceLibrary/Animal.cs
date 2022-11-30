using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIConvergence.Shared;

public class Animal : IDisposable
{
  public Animal()
  {

  }
  ~Animal()
  {
    Dispose(false);
  }

  bool disposed = false;
  public void Dispose()
  {
    Dispose(true);
    GC.SuppressFinalize(this);
  }
  protected virtual void Dispose(bool disposing)
  {
    if(disposed) return;
    // release unmanged resources
    if(disposing)
    {
      // release managed resources
    }
    disposed = true;
  }
}
