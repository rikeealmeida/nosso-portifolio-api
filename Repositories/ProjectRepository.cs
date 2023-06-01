using System;
using Microsoft.EntityFrameworkCore;
using nosso_portifolio_api.Context;
using nosso_portifolio_api.DTOs;
using nosso_portifolio_api.Models;

namespace nosso_portifolio_api.Repositories
{

    public interface IProjectRepository
    {
        Task<List<ProjectWithUserDto>> GetAllAsync();
    }
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _context;

        public ProjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProjectWithUserDto>> GetAllAsync()
        {
            if (_context.Project == null)
            {
                throw new Exception("Nenhum projeto encontrado!");
            }
            var projects = await _context.Project.Include(p => p.User).ToListAsync();

            var projectsWithUser = projects.Select(p => new ProjectWithUserDto
            {
                Id = p.Id,
                Images = p.Images,
                Name = p.Name,
                Resume = p.Resume,
                Stacks = p.Stacks,
                Website = p.Website,
                User = new UserWithoutProjectsDto
                {
                    Id = p.User.Id,
                    Resume = p.User.Resume,
                    Email = p.User.Resume,
                    FirstName = p.User.FirstName,
                    GithubUrl = p.User.GithubUrl,
                    ImageUrl = p.User.ImageUrl,
                    InstagramUrl = p.User.InstagramUrl,
                    LastName = p.User.LastName,
                    LinkedinUrl = p.User.LinkedinUrl,
                    TelNumber = p.User.TelNumber,
                    Title = p.User.Title
                },
            }).ToList();
            return projectsWithUser;
        }
    }
}

