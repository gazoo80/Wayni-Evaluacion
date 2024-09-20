using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWayni.Application.Common
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        Task Save();
    }
}
