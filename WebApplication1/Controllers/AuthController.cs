using BookStore.DTO;
using BookStore.Models;
using BookStore.Repository;
using BookStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserRepository _repository;
        public AuthController(IUserRepository repository) => _repository = repository;
        [HttpPost("signup")]
        public IActionResult Signup([FromBody] User user)
        {
            var newUser = _repository.Singup(user);
            var response = new UserViewModel
            {
                User = newUser,
                Token = new TokenManager().Generate(newUser)
            };
            response.User.Password = string.Empty;
            return Created("", user);
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            try
            {
                var existinUser = _repository.Get(user);
                if (existinUser == null) return NotFound(new { message = "usuário não encontrado" });
                var response = new UserViewModel
                {
                    User = existinUser,
                    Token = new TokenManager().Generate(existinUser)
                };
                response.User.Password = string.Empty;
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
