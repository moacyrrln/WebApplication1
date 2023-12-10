using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
    }
}
