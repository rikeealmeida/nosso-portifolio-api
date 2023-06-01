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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/users
        [HttpGet("users")]
        public async Task<ActionResult<IEnumerable<UserWithProjectsDto>>> GetUsers()
        {

            try
            {
                var users = await _userService.GetAllAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }

        }

        [HttpGet("user/{id}")]
        public async Task<ActionResult<UserWithProjectsDto>> getUser(int id)
        {
            try
            {
                var user = await _userService.GetByIdAsync(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        [HttpPost("users")]
        public async Task<ActionResult<User>> postUser(CreateUserDto createUserDto)
        {
            try
            {
                var user = await _userService.AddAsync(createUserDto);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        [HttpPut("user/{id}")]
        public async Task<ActionResult<User>> updateUser(UpdateUserDto updateUserDto, int id)
        {

            try
            {
                var user = await _userService.UpdateAsync(id, updateUserDto);

                return Ok(user);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        [HttpDelete("user/{id}")]
        public async Task<IActionResult> deleteUser(int id)
        {
            try
            {
                await _userService.RemoveAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }
    }
}
