using Microsoft.EntityFrameworkCore;
using TV_Show_Database.Models.Entities;

namespace TV_Show_Database.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            /*
             * This constructor is used by the dependency injection container to create an instance of the DbContext.
             * The options parameter contains the configuration for the database connection.
             */
        }

        public DbSet<Show> Shows { get; set; } // This property represents the collection of 'Show' entities in the database.

    }
}
