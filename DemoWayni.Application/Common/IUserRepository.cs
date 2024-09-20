using DemoWayni.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWayni.Application.Common
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User Update(User entity);
    }
}
