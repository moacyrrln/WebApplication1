﻿namespace BookStore.Models;
using System.ComponentModel.DataAnnotations;

public class Author
{
    public int AuthorId { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
}

