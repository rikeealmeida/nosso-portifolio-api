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
        public async Task<ActionResult<IEnumerable<ProjectWithUserDto>>> GetProjects()
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


            //if (_context.Project == null)
            //{
            //    return NotFound();
            //}
            //var projects = await _context.Project.Include(p => p.User).ToListAsync();

            //var projectsWithUser = projects.Select(p => new ProjectWithUserDto
            //{
            //    Id = p.Id,
            //    Images = p.Images,
            //    Name = p.Name,
            //    Resume = p.Resume,
            //    Stacks = p.Stacks,
            //    Website = p.Website,
            //    User = new UserWithoutProjectsDto
            //    {
            //        Id = p.User.Id,
            //        Resume = p.User.Resume,
            //        Email = p.User.Resume,
            //        FirstName = p.User.FirstName,
            //        GithubUrl = p.User.GithubUrl,
            //        ImageUrl = p.User.ImageUrl,
            //        InstagramUrl = p.User.InstagramUrl,
            //        LastName = p.User.LastName,
            //        LinkedinUrl = p.User.LinkedinUrl,
            //        TelNumber = p.User.TelNumber,
            //        Title = p.User.Title
            //    },
            //});
            //return Ok(projectsWithUser);
        }

        // GET: api/Project/5
        [HttpGet("project/{id}")]
        public async Task<ActionResult<ProjectWithUserDto>> GetProject(int id)
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

            //if (_context.Project == null)
            //{
            //    return NotFound();
            //}
            //var project = await _context.Project.FindAsync(id);

            //if (project == null)
            //{
            //    return NotFound();
            //}

            //return project;
        }

        // POST: api/Project
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("projects")]
        public async Task<ActionResult<ProjectWithUserDto>> PostProject(CreateProjectDto createProjectDto)
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

            //if (_context.Project == null)
            //{
            //    return Problem("Entity set 'AppDbContext.Project'  is null.");
            //}
            //var user = _context.User.FirstOrDefault(u => u.Id == createProjectDto.UserId);
            //if (user == null)
            //{
            //    return BadRequest("Id de usuário inválido");
            //}
            //var newProject = new Project
            //{
            //    Images = createProjectDto.Images,
            //    Name = createProjectDto.Name,
            //    Resume = createProjectDto.Resume,
            //    Stacks = createProjectDto.Stacks,
            //    User = user,
            //    UserId = createProjectDto.UserId,
            //    Website = createProjectDto.Website
            //};

            //_context.Project.Add(newProject);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetProject", new { id = newProject.Id }, newProject);
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
            //if (id != project.Id)
            //{
            //    return BadRequest();
            //}

            //_context.Entry(project).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!ProjectExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return NoContent();
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
            //if (_context.Project == null)
            //{
            //    return NotFound();
            //}
            //var project = await _context.Project.FindAsync(id);
            //if (project == null)
            //{
            //    return NotFound();
            //}

            //_context.Project.Remove(project);
            //await _context.SaveChangesAsync();

            //return NoContent();
        }

        //private bool ProjectExists(int id)
        //{
        //    return (_context.Project?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
