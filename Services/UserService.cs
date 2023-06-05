using System;
using nosso_portifolio_api.DTOs;
using nosso_portifolio_api.Models;
using nosso_portifolio_api.Repositories;

namespace nosso_portifolio_api.Services
{
    public interface IUserService
    {
        Task<List<UserWithProjectsDto>> GetAllAsync();
        Task<UserWithProjectsDto> GetByIdAsync(int id);
        Task<User> AddAsync(CreateUserDto createUserDto);
        Task<User> UpdateAsync(int id, UpdateUserDto updateUserDto);
        Task RemoveAsync(int id);
    }


    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> AddAsync(CreateUserDto createUserDto) => await _userRepository.AddAsync(createUserDto);

        public async Task<List<UserWithProjectsDto>> GetAllAsync() => await _userRepository.GetAllAsync();

        public async Task<UserWithProjectsDto> GetByIdAsync(int id) => await _userRepository.GetByIdAsync(id);

        public async Task RemoveAsync(int id) => await _userRepository.RemoveAsync(id);

        public async Task<User> UpdateAsync(int id, UpdateUserDto updateUserDto) => await _userRepository.UpdateAsync(id, updateUserDto);
    }
}

