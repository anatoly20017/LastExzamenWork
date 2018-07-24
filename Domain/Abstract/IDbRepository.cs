using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Abstract
{
  public interface IDbRepository<T>
        where T : class, IDbEntity
  {
    bool AddItem(T item);
    bool AddItems(IEnumerable<T> items);
    IQueryable<T> AllItems { get; }
    bool ChangeItem(T item);
    bool DeleteItem(Guid id);
    T GetItem(Guid id);
    bool SaveChanges();
  }
}
