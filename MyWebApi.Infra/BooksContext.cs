using Microsoft.EntityFrameworkCore;
using MyWebApi.Infra.Models;
using System;

namespace MyWebApi.Infra
{
    public class BooksContext : DbContext
    {

        public BooksContext(DbContextOptions<BooksContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books => Set<Book>();
    }
}

