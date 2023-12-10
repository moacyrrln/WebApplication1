using BookStore.Models;

namespace BookStore.Repository
{
    public class UserRepository : IUserRepository
    {
        protected readonly BookStoreContext _context;
        public UserRepository(BookStoreContext context) => _context = context;
        public User Get(User user)
        {
            var foundedUser = _context.Users.First(userList => userList.Name == user.Name);
            if (foundedUser == null) throw new Exception("usuário não encontrado");
            return foundedUser;
        }
        public User Singup(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
    }
}
