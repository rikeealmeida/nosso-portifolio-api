using System;
using nosso_portifolio_api.DTOs;
using nosso_portifolio_api.Models;
using nosso_portifolio_api.Repositories;

namespace nosso_portifolio_api.Services
{
    public interface IProjectService
    {
        Task<List<ProjectWithUserDto>> GetAllAsync();
        Task<ProjectWithUserDto> GetByIdAsync(int id);
        Task<Project> AddAsync(CreateProjectDto createProjectDto);
        Task<Project> UpdateAsync(int id, UpdateProjectDto updateProjectDto);
        Task RemoveAsync(int id);

    }
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public Task<Project> AddAsync(CreateProjectDto createProjectDto)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProjectWithUserDto>> GetAllAsync()
        {
            var projects = _projectRepository.GetAllAsync();

            return projects;
        }

        public Task<ProjectWithUserDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Project> UpdateAsync(int id, UpdateProjectDto updateProjectDto)
        {
            throw new NotImplementedException();
        }
    }
}

