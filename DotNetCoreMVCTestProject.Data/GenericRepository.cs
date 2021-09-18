using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DotNetCoreMVCTestProject.Data
{
    public class GenericRepository<T> where T : class
    {
        private readonly DbContext context;
        private readonly DbSet<T> table;

        public GenericRepository(DbContext context)
        {
            this.context = context;
            table = context.Set<T>();
        }

        public async Task<T> Insert(T entity)
        {
            await table.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(T entity, Expression<Func<T, bool>> predicate)
        {
            T value = await table.Where(predicate).FirstOrDefaultAsync();
            context.Entry(value).CurrentValues.SetValues(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async void Delete(Expression<Func<T, bool>> predicate)
        {
            T value = await table.Where(predicate).FirstOrDefaultAsync();
            context.Remove(value);
            await context.SaveChangesAsync();
        }

        public async Task<List<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await table.Where(predicate).ToListAsync();
        }

        public async Task<T> FindOne(Expression<Func<T, bool>> predicate)
        {
            return await table.Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAll()
        {
            return await table.ToListAsync();
        }

        public async Task<List<T>> FindUsingSP(string query, SqlParameter[] param)
        {
            if (param.Any())
            {
                return await context.Set<T>().FromSqlRaw(query, param).ToListAsync();
            }
            else
            {
                return await context.Set<T>().FromSqlRaw(query).ToListAsync();
            }
        }
    }
}
