using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("authors")]
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository _repository;

        public AuthorController(IAuthorRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            return Ok(_repository.GetAuthors());
        }

        [HttpPost]
        public IActionResult AddAuthor([FromBody] Author author)
        {
            return Created("", _repository.AddAuthor(author));
        }

        [HttpPut("{authorId}")]
        public IActionResult UpdateAuthor([FromBody] Author author, int authorId)
        {
            return Ok(_repository.UpdateAuthor(author, authorId));
        }

        [HttpDelete("{authorId}")]
        public IActionResult DeleteAuthor(int authorId)
        {
            _repository.DeleteAuthor(authorId);
            return NoContent();
        }
    }
}
