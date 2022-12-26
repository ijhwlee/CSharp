using GraphQL;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using Inje.AIConvergence.Shared;
using static System.Console;

namespace Inje.AIConvergence.GraphQL;

public class NorthwindQuery : ObjectGraphType
{
  public NorthwindQuery(NorthwindContext db)
  {
    Field<IntGraphType, int>("test").Resolve(_ => 123);
    Field<NonNullGraphType<StringGraphType>>("name")
      .Description("Argument name")
      .Resolve(context => db.Employees.FirstOrDefault<Employee>()?.EmployeeId.ToString());
    Field<ListGraphType<CategoryType>>("namesCategory")
      .Description("Argument names of Category")
      .Resolve(context => db.Categories);
    //WriteLine($"[DEBUG-hwlee]NorthwindQuery: db = {db}");
    Field<ListGraphType<CategoryType>>("categories")
      .Description("A query type that returns a list of all categories.")
      .Resolve(context => db.Categories.Include(c => c.Products));

    Field<CategoryType>("category")
      .Description("A query type that returns a category using its Id.")
      .Argument<IntGraphType>("categoryId", "id of the category")
      .Resolve(context =>
      {
        int id = context.GetArgument<int>("categoryId");
        //WriteLine($"[DEBUG-hwlee]NorthwindQuery: category, id = {id}");
        Category? category = db.Categories.Find(context.GetArgument<int>("categoryId"));
        if (category != null)
        {
          category.Products = db.Products.Where(p => p.CategoryId == id).ToArray<Product>();
        }
        return category;
      });

    Field<ListGraphType<ProductType>>("products")
      .Description("A query type that returns a products using if given category Id.")
      .Argument<IntGraphType>("categoryId", "id of the category")
      .Resolve(context =>
      {
        int id = context.GetArgument<int>("categoryId");
        //WriteLine($"[DEBUG-hwlee]NorthwindQuery: products, id = {id}");
        Product[] products = db.Products.Where(p => p.CategoryId == id).ToArray<Product>();
        return products;
      });
  }
}
