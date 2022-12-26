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
    WriteLine($"[DEBUG-hwlee]NorthwindQuery: db = {db}");
    Field<ListGraphType<CategoryType>>("categories")
      .Description("A query type that returns a list of all categories.")
      .Resolve(context => db.Categories.Include(c => c.Products));

    Func<IResolveFieldContext, int, Category?> func = (context, id) =>
    {
      Category? category = db.Categories.Find(id);
      db.Entry(typeof(Category)).Collection("Products").Load();
      return category;
    };

    Field<CategoryType>("category")
      .Description("A query type that returns a category using its Id.")
      .Argument<IntGraphType>("categoryId", "id of the category")
      .ResolveDelegate(func);

    //Func<IResolveFieldContext, int, ListGraphType<ProductType>> func1 = (context, id) =>
    //{
    //  Category? category = db.Categories.Find(id);
    //  db.Entry(typeof(Category)).Collection("Products").Load();
    //  return category.Products;
    //};

    //Field<ListGraphType<ProductType>>("products")
    //  .Description("A query type that returns a category using its Id.")
    //  .Argument<IntGraphType>("categoryId", "id of the category")
    //  .ResolveDelegate(func1);
  }
}
