namespace BookStore.Repository;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;

public interface IBookStoreContext
{
    public DbSet<Author> Authors { get; set; }
    public int SaveChanges();
}

