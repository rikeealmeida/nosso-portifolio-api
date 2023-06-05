using System;
using Microsoft.EntityFrameworkCore;
using nosso_portifolio_api.Context;
using nosso_portifolio_api.DTOs;
using nosso_portifolio_api.Models;

namespace nosso_portifolio_api.Repositories
{

    public interface IProjectRepository
    {
        Task<List<Project>> GetAllAsync();
        Task<Project> GetByIdAsync(int id);
        Task<Project> AddAsync(CreateProjectDto createProjectDto);
        Task<Project> UpdateAsync(int id, UpdateProjectDto updateProjectDto);
        Task RemoveAsync(int id);
    }
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _context;

        public ProjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Project> AddAsync(CreateProjectDto createProjectDto)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Id == createProjectDto.UserId);
            if (user == null)
            {
                throw new Exception("Usuário não encontrado!");
            }

            var project = new Project
            {
                Images = createProjectDto.Images,
                Name = createProjectDto.Name,
                Resume = createProjectDto.Resume,
                Stacks = createProjectDto.Stacks,
                UserId = createProjectDto.UserId,
                Website = createProjectDto.Website,
                User = user,
            };

            await _context.Project.AddAsync(project);
            await _context.SaveChangesAsync();

            return project;
        }

        public async Task<List<Project>> GetAllAsync()
        {
            if (_context.Project == null)
            {
                throw new Exception("Nenhum projeto encontrado!");
            }
            var projects = await _context.Project.Include(p => p.User).ToListAsync();

            return projects;
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            if (_context.Project == null)
            {
                throw new Exception("Nenhum projeto encontrado!");
            }
            var project = await _context.Project.Include(p => p.User).FirstOrDefaultAsync(p => p.Id == id);

            if (project == null)
            {
                throw new Exception("Projeto não encontrado!");
            }

            return project;
        }

        public async Task RemoveAsync(int id)
        {
            if (_context.Project == null)
            {
                throw new Exception("Nenhum projeto encontrado!");
            }
            var project = await _context.Project.FirstOrDefaultAsync(p => p.Id == id);
            if (project == null)
            {
                throw new Exception("Projeto não encontrado!");
            }
            _context.Project.Remove(project);
            await _context.SaveChangesAsync();
        }

        public async Task<Project> UpdateAsync(int id, UpdateProjectDto updateProjectDto)
        {
            if (_context.Project == null)
            {
                throw new Exception("Nenhum projeto encontrado!");
            }

            var project = await _context.Project.FirstOrDefaultAsync(p => p.Id == id);

            if (project == null)
            {
                throw new Exception("Projeto não encontrado!");
            }

            var user = await _context.User.FirstOrDefaultAsync(u => u.Id == updateProjectDto.UserId);

            project.Images = updateProjectDto.Images ?? project.Images;
            project.Name = updateProjectDto.Name ?? project.Name;
            project.Resume = updateProjectDto.Resume ?? project.Resume;
            project.Stacks = updateProjectDto.Stacks ?? project.Stacks;
            project.UserId = updateProjectDto.UserId ?? project.UserId;
            project.Website = updateProjectDto.Website ?? project.Website;
            project.UserId = updateProjectDto.UserId ?? project.UserId;
            project.User = user ?? project.User;

            _context.Entry(project).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return project;
        }
    }
}

