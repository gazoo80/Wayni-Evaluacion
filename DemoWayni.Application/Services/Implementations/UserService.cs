using AutoMapper;
using DemoWayni.Application.Common;
using DemoWayni.Application.Services.Interfaces;
using DemoWayni.Application.ViewModels;
using DemoWayni.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWayni.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public UserService(IUnitOfWork _uow, IMapper _mapper)
        {
            uow = _uow;
            mapper = _mapper;
        }

        public async Task<List<UserDTO>> GetAll()
        {
            var users = await uow.UserRepository.GetAll();
            var usersDTO = mapper.Map<List<UserDTO>>(users);
            return usersDTO;
        }

        public async Task<UserDTO?> Get(int? id)
        {
            ArgumentNullException.ThrowIfNull(id);
            var user = await uow.UserRepository.Get(u => u.Id == id);
            
            if (user is not null)
            {
                var userDTO = mapper.Map<UserDTO>(user);
                return userDTO;
            }

            return null;
        }

        public async Task<bool> Create(UserDTO userDTO)
        {
            ArgumentNullException.ThrowIfNull(userDTO);
            var user = mapper.Map<User>(userDTO);
            await uow.UserRepository.Create(user);
            await uow.Save();
            return user.Id != 0;
        }

        public async Task<bool> Update(UserDTO userDTO)
        {
            ArgumentNullException.ThrowIfNull(userDTO);
            var user = mapper.Map<User>(userDTO);
            var exists = await uow.UserRepository.Exists(u => u.Id == user.Id);
            
            if (exists)
            {
                uow.UserRepository.Update(user);
                await uow.Save();
            }

            return exists;
        }

        public async Task<bool> Remove(int id)
        {
            var user = await uow.UserRepository.Get(u => u.Id == id);

            if (user != null)
            {
                uow.UserRepository.Remove(user);
                await uow.Save();
                return true;
            }

            return false;
        }      
    }
}
