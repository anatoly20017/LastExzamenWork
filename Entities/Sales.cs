using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
   public class Sales
    {
    public int Id { get; set; }
    public virtual Product Product { get; set; }
    public virtual Seller Seller { get; set; }
    public int Count { get; set; }
    public decimal Price { get; set; }
    public DateTime? Data { get; set; }
  }
}
