using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nosso_portifolio_api.Context;
using nosso_portifolio_api.DTOs;
using nosso_portifolio_api.Models;
using nosso_portifolio_api.Services;

namespace nosso_portifolio_api.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProjectController : ControllerBase
    {

        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        // GET: api/Project
        [HttpGet("projects")]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        {

            try
            {
                var projects = await _projectService.GetAllAsync();

                return Ok(projects);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        // GET: api/Project/5
        [HttpGet("project/{id}")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
            try
            {
                var project = await _projectService.GetByIdAsync(id);
                return Ok(project);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        // POST: api/Project
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("projects")]
        public async Task<ActionResult<Project>> PostProject(CreateProjectDto createProjectDto)
        {
            try
            {
                var newProject = await _projectService.AddAsync(createProjectDto);
                return Ok(newProject);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }


        // PUT: api/Project/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("project/{id}")]
        public async Task<IActionResult> PutProject(int id, UpdateProjectDto updateProjectDto)
        {
            try
            {
                var newProject = await _projectService.UpdateAsync(id, updateProjectDto);
                return Ok(newProject);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }


        // DELETE: api/Project/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            try
            {
                await _projectService.RemoveAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }
    }
}
