using Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace AppContext
{

  public class MyAppDBContext : DbContext
  {
    public DbSet<Product> Products { get; set; }
    public DbSet<Sales> Saleses { get; set; }
    public DbSet<Seller> Sellers { get; set; }

    public MyAppDBContext(DbContextOptions<MyAppDBContext> options)
        : base(options)
    {
      Database.EnsureCreated();
    }
  }
}
