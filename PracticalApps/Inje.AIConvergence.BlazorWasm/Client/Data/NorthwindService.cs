using System.Net.Http.Json;
using Inje.AIConvergence.Shared;

namespace Inje.AIConvergence.BlazorWasm.Client.Data;

public class NorthwindService : INorthwindService
{
  private readonly HttpClient http;
  public NorthwindService(HttpClient http)
  {
    this.http = http;
  }

  public async Task<Customer?> CreateCustomerAsync(Customer customer)
  {
    HttpResponseMessage response = await http.PostAsJsonAsync("api/customers", customer);
    return await response.Content.ReadFromJsonAsync<Customer>();
  }

  public async Task DeleteCustomerAsync(string id)
  {
    HttpResponseMessage response = await http.DeleteAsync($"api/customers/{id}");
  }

  public Task<Customer?> GetCustomerAsync(string id)
  {
    return http.GetFromJsonAsync<Customer>($"api/customers/{id}");
  }

  public Task<List<Customer>?> GetCustomersAsync()
  {
    return http.GetFromJsonAsync<List<Customer>>("api/customers");
  }

  public Task<List<Customer>?> GetCustomersAsync(string country)
  {
    return http.GetFromJsonAsync<List<Customer>>($"api/customers/in/{country}");
  }

  public async Task<Customer?> UpdateCustomerAsync(Customer customer)
  {
    HttpResponseMessage response = await http.PutAsJsonAsync("api/customers", customer);
    return await response.Content.ReadFromJsonAsync<Customer>();
  }
}
