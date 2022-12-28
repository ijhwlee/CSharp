using Android.App;
using Android.Runtime;

namespace Inje.AIConvergence.Maui6.Customers
{
  [Application]
  //[Application(UsesCleartextTraffic = true)]
  public class MainApplication : MauiApplication
  {
    public MainApplication(IntPtr handle, JniHandleOwnership ownership)
      : base(handle, ownership)
    {
    }

    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
  }
}