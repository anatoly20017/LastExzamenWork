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
  public class SellerService
  {

    MyAppDBContext db;
    public SellerService(MyAppDBContext context)
    {
      db = context;
    }

    public List<Seller> GetAllSeller()
    {
      return db.Sellers.ToList();
    }
    public void CreateSeller(Seller seller)
    {
      db.Sellers.Add(seller);
      db.SaveChanges();
    }

    public Seller UpdateSeller(Seller seller)
    {
      db.Sellers.Update(seller);
      return seller;
    }

    public async Task DeleteSellerAsync(int? id)
    {
      if (id.HasValue)
      {
        db.Sellers.Remove(new Seller { Id = id.Value });
        await db.SaveChangesAsync();
      }
    }

    public decimal? Premia(int id)
    {
      var sallerSalesCount = (db.Saleses.Where(s => s.Seller.Id == id).ToList()).Count;
      var saller = db.Sellers.FirstOrDefault(s => s.Id == id);
      return saller?.Reward * sallerSalesCount;
    }

  }
}
