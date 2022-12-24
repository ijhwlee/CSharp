using Inje.AIConvergence.Shared;
using Microsoft.EntityFrameworkCore;

namespace Inje.AIConvergence.BlazorServer.Data;

public class NorthwindService : INorthwindService
{
  private readonly NorthwindContext db;
  public NorthwindService(NorthwindContext db)
  {
    this.db = db;
  }
  public Task<Customer> CreateCustomerAsync(Customer customer)
  {
    db.Customers.Add(customer);
    db.SaveChangesAsync();
    return Task.FromResult(customer);
  }

  public Task DeleteCustomerAsync(string id)
  {
    Customer? customer = db.Customers.FirstOrDefaultAsync(c => c.CustomerId ==id).Result;
    if (customer == null)
    {
      return Task.CompletedTask;
    }
    else
    {
      db.Customers.Remove(customer);
      return db.SaveChangesAsync();
    }
  }

  public Task<Customer?> GetCustomerAsync(string id)
  {
    return db.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
  }

  public Task<List<Customer>> GetCustomersAsync()
  {
    return db.Customers.ToListAsync();
  }

  public Task<List<Customer>> GetCustomersAsync(string country)
  {
    return db.Customers.Where(c => c.Country == country).ToListAsync();
  }

  public Task<Customer> UpdateCustomerAsync(Customer customer)
  {
    db.Entry(customer).State = EntityState.Modified;
    db.SaveChangesAsync();
    return Task.FromResult(customer);
  }
}
