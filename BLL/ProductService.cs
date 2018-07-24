using AppContext;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL
{
  public class ProductService
  {
    MyAppDBContext db;

    public ProductService(MyAppDBContext context)
    {
      db = context;
    }

    public List<Product> GetAllProduct()
    {
      return db.Products.ToList();
    }

    public void CreateProduct(Product product)
    {
      db.Products.Add(product);
      db.SaveChanges();
    }

    public Product UpdateProduct(Product product)
    {
      db.Products.Update(product);
      return product;
    }

    public async Task DeleteProductAsync(int? id)
    {
      if (id.HasValue)
      {
        db.Products.Remove(new Product { Id = id.Value });
        await db.SaveChangesAsync();
      }
    }
  }
}
