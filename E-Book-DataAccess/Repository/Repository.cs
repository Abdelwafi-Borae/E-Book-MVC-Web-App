using E_Book_DataAccess.Data;
using E_Book_DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Book_DataAccess.Repository;

public class Repository<T> : IRepository<T> where T : class

{private readonly  AppDbContext _context;
    internal DbSet<T> DbSet;
    public Repository(AppDbContext context)
    {
        _context = context;
        this.DbSet = _context.Set<T>();

    }

    public IEnumerable<T> GetAll(string[]? include = null)
    {
        IQueryable<T> query = DbSet;
        if (include!=null)
        {
            foreach(var item in include)
            {
                query = query.Include(item);
            }
        }
        
        return query.ToList();
    }

    public T GetFirstOrDefault(Expression<Func<T, bool>> filter, string[]? include = null)
    {
        IQueryable<T> query = DbSet;
        query = query.Where(filter);
        if (include != null)
        {
            foreach (var item in include)
            {
                query = query.Include(item);
            }
        }
        return query.FirstOrDefault();
    }
    public void Add(T entity)
    {
        DbSet.Add(entity);
    }

    public void Remove(T entity)
    {
   DbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
       DbSet.RemoveRange(entities);
    }
}


