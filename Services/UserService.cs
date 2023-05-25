using System;
using nosso_portifolio_api.Models;
using nosso_portifolio_api.Repositories;

namespace nosso_portifolio_api.Services
{
    public interface IUserService
    {
        List<User> GetAll();
        User GetById(int id);
        void Add(User user);
        void Update(User user);
        void Remove(int id);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public void Add(User user)
        {
            _userRepository.Add(user);
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public void Remove(int id)
        {
            _userRepository.Remove(id);
        }

        public void Update(User user)
        {
            _userRepository.Update(user);
        }
    }
}

