using DemoWayni.Application.Common;
using DemoWayni.Domain.Models;
using DemoWayni.Infrastructure.Data;

namespace DemoWayni.Infrastructure.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext db;

        public UserRepository(ApplicationDbContext _db) : base(_db)
        {
            db = _db;
        }

        public User Update(User entity)
        {
            db.Users.Update(entity);
            return entity;
        }
    }
}
