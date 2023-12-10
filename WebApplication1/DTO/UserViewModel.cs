using BookStore.Models;

namespace BookStore.DTO
{
    public class UserViewModel
    {
        public User? User { get; set; }
        public string? Token { get; set; }
    }
}
