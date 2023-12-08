using BookStore.Models;

namespace BookStore.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        protected readonly BookStoreContext _context;

        public AuthorRepository(BookStoreContext context)
        {
            _context = context;
        }

        public Author AddAuthor(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
            return author;
        }

        public void DeleteAuthor(int AuthorId)
        {
            var myAuthor = _context.Authors.Find(AuthorId);
            if (myAuthor != null)
            {
                _context.Authors.Remove(myAuthor);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Author> GetAuthors()
        {
            return _context.Authors;
        }

        public Author UpdateAuthor(Author author, int AuthorId)
        {
            var myAuthor = _context.Authors.Find(AuthorId);
            if (myAuthor != null)
            {
                myAuthor.AuthorId = AuthorId;
                myAuthor.Name = author.Name;
                myAuthor.Email  = author.Email;
                _context.SaveChanges();
            }
            return myAuthor;
        }
    }
}
