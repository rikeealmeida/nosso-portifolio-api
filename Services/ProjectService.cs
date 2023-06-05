using System;
using nosso_portifolio_api.DTOs;
using nosso_portifolio_api.Models;
using nosso_portifolio_api.Repositories;

namespace nosso_portifolio_api.Services
{
    public interface IProjectService
    {
        Task<List<Project>> GetAllAsync();
        Task<Project> GetByIdAsync(int id);
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

        public async Task<Project> AddAsync(CreateProjectDto createProjectDto) => await _projectRepository.AddAsync(createProjectDto);

        public async Task<List<Project>> GetAllAsync() => await _projectRepository.GetAllAsync();

        public async Task<Project> GetByIdAsync(int id) => await _projectRepository.GetByIdAsync(id);

        public async Task RemoveAsync(int id) => await _projectRepository.RemoveAsync(id);

        public async Task<Project> UpdateAsync(int id, UpdateProjectDto updateProjectDto) => await _projectRepository.UpdateAsync(id, updateProjectDto);


    }
}

