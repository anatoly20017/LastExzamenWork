using AppContext;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
  public class SalesService
  {
    MyAppDBContext db;
    public SalesService(MyAppDBContext context)
    {
      db = context;
    }

    public List<Sales> GetAllSales()
    {
      return db.Saleses.ToList();
    }
    public void CreateSales(Sales sales)
    {
      db.Saleses.Add(sales);
      db.SaveChanges();
    }

    public Sales UpdateSales(Sales sales)
    {
      db.Saleses.Update(sales);
      return sales;
    }

    public async Task DeleteSalesAsync(int? id)
    {
      if (id.HasValue)
      {
        db.Saleses.Remove(new Sales { Id = id.Value });
        await db.SaveChangesAsync();
      }
    }
    public IEnumerable<Sales> GetSalesBySeller(int sellerId)
    {
      return db.Saleses.Where(s => s.Seller.Id == sellerId).ToList();
    }
  }
}
