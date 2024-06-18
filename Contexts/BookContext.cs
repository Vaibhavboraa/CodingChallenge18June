using CodingChallenge18June.Models;
using Microsoft.EntityFrameworkCore;

namespace CodingChallenge18June.Contexts
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Books>? Books { get; set; }
       

    }
}
