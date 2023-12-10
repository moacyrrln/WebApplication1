using BookStore.Models;

namespace BookStore.Repository
{
    public interface IUserRepository
    {
        User Singup(User user);
        User Get(User user);
    }
}
