using Microsoft.EntityFrameworkCore;
using MyWebApi.Infra.Models;
using System;

namespace MyWebApi.Application
{
	public class BooksContext : DbContext
	{

        public BooksContext(DbContextOptions<BooksContext> options)
            : base(options)
        {
        }

        public DbSet<BookDto> Books { get; set; } = default!;
    }
}

