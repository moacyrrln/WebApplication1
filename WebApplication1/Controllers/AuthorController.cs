using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("authors")]
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository _repository;

        public AuthorController(IAuthorRepository repository) => _repository = repository;

        [HttpGet]
        public IActionResult GetAuthors() => Ok(_repository.GetAuthors());

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Policy = "admin")]
        public IActionResult AddAuthor([FromBody] Author author)
        {
            var token = HttpContext.User.Identity as ClaimsIdentity;
            var name = token.Claims;
            return Created("", _repository.AddAuthor(author));
        }

        [HttpPut("{authorId}")]
        public IActionResult UpdateAuthor([FromBody] Author author, int authorId) => Ok(_repository.UpdateAuthor(author, authorId));

        [HttpDelete("{authorId}")]
        public IActionResult DeleteAuthor(int authorId)
        {
            _repository.DeleteAuthor(authorId);
            return NoContent();
        }
    }
}
