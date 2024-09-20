using DemoWayni.Application.Common;
using DemoWayni.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWayni.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository UserRepository { get; private set; }

        private readonly ApplicationDbContext db;

        public UnitOfWork(ApplicationDbContext _db)
        {
            db = _db;
            UserRepository = new UserRepository(db);
        }

        public async Task Save()
        {
            await db.SaveChangesAsync();
        }
    }
}
