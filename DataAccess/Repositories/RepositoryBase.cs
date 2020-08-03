using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class RepositoryBase<T> where T : class
    {
        protected AppDbContext dbContext;
        protected DbSet<T> dbSet;
        public RepositoryBase(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<T>();
        }
        public bool Create(T item)
        {
            dbSet.Add(item);
            return Save();
        }
        public bool Update(T item)
        {
            dbSet.Update(item);
            return Save();
        }
        public bool Delete(T item)
        {
            dbSet.Remove(item);
            return Save();
        }
        public bool Save()
        {
            int saved = dbContext.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
