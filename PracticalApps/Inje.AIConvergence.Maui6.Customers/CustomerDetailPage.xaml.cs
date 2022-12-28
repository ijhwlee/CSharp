namespace Inje.AIConvergence.Maui6.Customers;

public partial class CustomerDetailPage : ContentPage
{
  private CustomersListViewModel customers;
  private string type = "Edit Customer";
  public CustomerDetailPage(CustomersListViewModel customers)
	{
		InitializeComponent();
		this.customers = customers;
    BindingContext = new CustomerDetailViewModel();
    type = "Add Customer";
    InsertButton.Text = "Insert Customer";
  }
  public CustomerDetailPage(CustomersListViewModel customers,
    CustomerDetailViewModel customer)
  {
    InitializeComponent();
    this.customers = customers;
    BindingContext = customer;
    InsertButton.IsVisible = false;
    type = "Edt Customer";
    InsertButton.Text = type;
  }
  protected override void OnAppearing()
  {
    base.OnAppearing();
    Title = type;
  }
  async void InsertButton_Clicked(object sender, EventArgs e)
  {
    Button btn = (Button)sender;
    if (btn.Text == "Insert Customer")
    {
      customers.Add((CustomerDetailViewModel)BindingContext);
    }
    await Navigation.PopAsync(animated: true);
  }
}