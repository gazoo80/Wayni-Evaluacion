using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DemoWayni.Application.Common
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAll(Expression<Func<T, bool>>? filter = null, bool tracked = false);

        Task<T?> Get(Expression<Func<T, bool>>? filter = null, bool tracked = false);

        Task<bool> Exists(Expression<Func<T, bool>>? filter = null);

        Task<T> Create(T entity);

        T Remove(T entity);
    }
}
