using BookStore.Models;

namespace BookStore.Repository
{
    public interface IAuthorRepository
    {
        Author AddAuthor(Author author);
        IEnumerable<Author> GetAuthors();
        Author UpdateAuthor(Author author, int AuhtorId);
        void DeleteAuthor(int Author);
    }
}
