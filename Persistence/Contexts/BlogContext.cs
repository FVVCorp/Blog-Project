using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts
{
    public sealed class BlogContext : IdentityDbContext<ApplicationUser>
    {
        public BlogContext()
        {
            
        }

        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=sonnov;Database=BlogIdentityDatabase;Trusted_Connection=true;"
            );
        }
    }
}