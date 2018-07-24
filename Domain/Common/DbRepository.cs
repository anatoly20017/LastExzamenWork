using AppContext;
using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Common
{
  public class DbRepository<T> : IDbRepository<T>
       where T : class, IDbEntity
  {
    private MyAppDBContext _context;

    public DbRepository(MyAppDBContext context)
    {
      _context = context;
    }

    public IQueryable<T> AllItems
    {
      get
      {
        return _context.Set<T>();
      }
    }

    public bool AddItem(T item)
    {
      _context.Set<T>().Add(item);
      return SaveChanges();
    }

    public bool AddItems(IEnumerable<T> items)
    {
      _context.Set<T>().AddRange(items);
      return SaveChanges();
    }

    public bool ChangeItem(T item)
    {
      T changed = GetItem(item.Id);
      if (changed == null) return false;
      changed = item;
      return SaveChanges();
    }

    public bool DeleteItem(Guid id)
    {
      T item = GetItem(id);
      if (item == null)
        return false;
      _context.Set<T>().Remove(item);
      return true;
    }

    public T GetItem(Guid id)
    {
      return AllItems.FirstOrDefault(x => x.Id.Equals(id));
    }

    public bool SaveChanges()
    {
      try
      {
        _context.SaveChanges();
        return true;
      }
#pragma warning disable 0168
      catch (Exception e)
#pragma warning restore 0168
      {
        return false;
      }
    }
  }
}
