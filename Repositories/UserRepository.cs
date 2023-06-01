using System;
using Microsoft.EntityFrameworkCore;
using nosso_portifolio_api.Context;
using nosso_portifolio_api.DTOs;
using nosso_portifolio_api.Models;

namespace nosso_portifolio_api.Repositories
{
    public interface IUserRepository
    {
        Task<List<UserWithProjectsDto>> GetAllAsync();
        Task<UserWithProjectsDto> GetByIdAsync(int id);
        Task<User> AddAsync(CreateUserDto createUserDto);
        Task<User> UpdateAsync(int id, UpdateUserDto updateUserDto);
        Task RemoveAsync(int id);
    }



    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddAsync(CreateUserDto createUserDto)
        {

            var user = new User
            {
                FirstName = createUserDto.FirstName,
                LastName = createUserDto.LastName,
                Email = createUserDto.Email,
                Title = createUserDto.Title,
                Password = createUserDto.Password,
                ImageUrl = createUserDto.ImageUrl,
                GithubUrl = createUserDto.GithubUrl,
                InstagramUrl = createUserDto.InstagramUrl,
                LinkedinUrl = createUserDto.LinkedinUrl,
                Resume = createUserDto.Resume,
                TelNumber = createUserDto.TelNumber,
            };

            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<List<UserWithProjectsDto>> GetAllAsync()
        {
            var users = await _context.User.Include(u => u.Projects).ToListAsync();

            var usersWithProjects = users.Select(user => new UserWithProjectsDto
            {
                Id = user.Id,
                Email = user.Email,
                Resume = user.Resume,
                TelNumber = user.TelNumber,
                Title = user.Title,
                FirstName = user.FirstName,
                LastName = user.LastName,
                GithubUrl = user.GithubUrl,
                ImageUrl = user.ImageUrl,
                InstagramUrl = user.InstagramUrl,
                LinkedinUrl = user.LinkedinUrl,
                Projects = user.Projects.Select(p => new ProjectWithoutUserDto
                {
                    Id = p.Id,
                    Images = p.Images,
                    Name = p.Name,
                    Resume = p.Resume,
                    Stacks = p.Stacks,
                    Website = p.Website

                }).ToList()

            }).ToList();
            return usersWithProjects;
        }

        public async Task<UserWithProjectsDto> GetByIdAsync(int id)
        {

            var user = await _context.User.Include(u => u.Projects).FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
                throw new Exception("Usuário não encontrado!");
            var userWithProjects = new UserWithProjectsDto
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                GithubUrl = user.GithubUrl,
                ImageUrl = user.ImageUrl,
                InstagramUrl = user.InstagramUrl,
                LastName = user.LastName,
                LinkedinUrl = user.LinkedinUrl,
                Resume = user.Resume,
                TelNumber = user.TelNumber,
                Title = user.Title,
                Projects = user.Projects.Select(p => new ProjectWithoutUserDto
                {
                    Id = p.Id,
                    Resume = p.Resume,
                    Images = p.Images,
                    Name = p.Name,
                    Stacks = p.Stacks,
                    Website = p.Website
                }).ToList()
            };
            return userWithProjects;
        }

        public async Task RemoveAsync(int id)
        {
            var userToDelete = await _context.User.FindAsync(id);
            if (userToDelete == null)
                throw new Exception("Usuário não encontrado!");
            _context.User.Remove(userToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<User> UpdateAsync(int id, UpdateUserDto updateUserDto)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                throw new Exception("Usuário não encontrado");
            };

            user.FirstName = updateUserDto.FirstName ?? user.FirstName;
            user.LastName = updateUserDto.LastName ?? user.LastName;
            user.Email = updateUserDto.Email ?? user.Email;
            user.Title = updateUserDto.Title ?? user.Title;
            user.Password = updateUserDto.Password ?? user.Password;
            user.ImageUrl = updateUserDto.ImageUrl ?? user.ImageUrl;
            user.GithubUrl = updateUserDto.GithubUrl ?? user.GithubUrl;
            user.InstagramUrl = updateUserDto.InstagramUrl ?? user.InstagramUrl;
            user.LinkedinUrl = updateUserDto.LinkedinUrl ?? user.LinkedinUrl;
            user.Resume = updateUserDto.Resume ?? user.Resume;
            user.TelNumber = updateUserDto.TelNumber ?? user.TelNumber;

            _context.Entry(user).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return user;
        }
    }
}

