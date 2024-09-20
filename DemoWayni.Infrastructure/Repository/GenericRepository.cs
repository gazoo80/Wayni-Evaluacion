using DemoWayni.Application.Common;
using DemoWayni.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DemoWayni.Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext db;
        internal DbSet<T> dbSet;

        public GenericRepository(ApplicationDbContext _db)
        {
            db = _db;
            this.dbSet = db.Set<T>();
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>>? filter = null, bool tracked = false)
        {
            IQueryable<T> query = dbSet;

            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            if (filter is not null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();
        }

        public async Task<T?> Get(Expression<Func<T, bool>>? filter = null, bool tracked = false)
        {
            IQueryable<T> query = dbSet;

            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            if (filter is not null)
            {
                query = query.Where(filter);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> Exists(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = dbSet;

            if (filter is not null)
            {
                query = query.Where(filter);
            }

            return await query.AnyAsync();
        }

        public async Task<T> Create(T entity)
        {
            await dbSet.AddAsync(entity);
            return entity;
        }

        public T Remove(T entity)
        {
            dbSet.Remove(entity);
            return entity;
        }

    }
}
