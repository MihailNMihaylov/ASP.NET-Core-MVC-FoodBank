using System;
using System.Linq;
using System.Threading.Tasks;
using FoodBank.Web.Models;
using Microsoft.EntityFrameworkCore;
using FoodBank.Data.Common;
namespace FoodBank.Data
{
    public class DbRepository<TEntity> : IRepository<TEntity>, IDisposable
            where TEntity : class
    {
        private readonly FoodBankContext context;
        private DbSet<TEntity> dbSet;

        public DbRepository(FoodBankContext context)
        {
            this.context = context;
            this.dbSet = this.context.Set<TEntity>();
        }

        public Task AddAsync(TEntity entity)
        {
            return this.dbSet.AddAsync(entity);
        }

        public IQueryable<TEntity> All()
        {
            return this.dbSet;
        }

        public void Delete(TEntity entity)
        {
            this.dbSet.Remove(entity);
        }

        public Task<int> SaveChangesAsync()
        {
            return this.context.SaveChangesAsync();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}
