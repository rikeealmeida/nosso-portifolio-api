using System;
using nosso_portifolio_api.Models;

namespace nosso_portifolio_api.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetById(int id);
        void Add(User user);
        void Update(User user);
        void Remove(int id);
    }

    public class UserRepository : IUserRepository
    {
        public void Add(User user)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}

