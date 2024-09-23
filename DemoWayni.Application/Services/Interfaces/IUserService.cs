using DemoWayni.Application.ViewModels;
using DemoWayni.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWayni.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetAll();
        Task<UserDTO?> Get(int? id);
        Task<bool> DniExists(string dni);
        Task<bool> Create(UserDTO userDTO);
        Task<bool> Update(UserDTO userDTO);
        Task<bool> Remove(int id);
    }
}
