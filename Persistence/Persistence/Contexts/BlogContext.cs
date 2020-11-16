using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Persistence.Configuration;

namespace Persistence.Contexts
{
    public sealed class BlogContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        private readonly BlogConfiguration _configuration;

        public BlogContext()
        {
        }

        public BlogContext(DbContextOptions<BlogContext> options,
            IOptions<BlogConfiguration> configOptions) : base(options)
        {
            _configuration = configOptions.Value;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.IdentityDatabaseConnection);
        }
    }
}