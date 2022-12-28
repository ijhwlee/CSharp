namespace Inje.AIConvergence.Maui6.Customers
{
  public partial class App : Application
  {
    public App()
    {
      InitializeComponent();

      //MainPage = new AppShell();
      MainPage = new NavigationPage(new CustomersListPage());
    }
  }
}