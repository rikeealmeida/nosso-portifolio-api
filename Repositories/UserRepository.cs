using System;
using Microsoft.EntityFrameworkCore;
using nosso_portifolio_api.Context;
using nosso_portifolio_api.Models;

namespace nosso_portifolio_api.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task<User> AddAsync(User user);
        Task<User> UpdateAsync(User user);
        Task RemoveAsync(int id);
    }



    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddAsync(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
                throw new Exception("Usuário não encontrado!");
            return user;
        }

        public async Task RemoveAsync(int id)
        {
            var userTodDelete = await _context.User.FindAsync(id);
            if (userTodDelete == null)
                throw new Exception("Usuário não encontrado!");
            _context.User.Remove(userTodDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<User> UpdateAsync(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return user;
        }
    }
}

