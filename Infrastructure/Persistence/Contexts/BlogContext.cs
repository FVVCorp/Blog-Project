using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Persistence.Settings;

namespace Persistence.Contexts
{
    public class BlogContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        private readonly UserDbConfig _configuration;

        public BlogContext()
        {

        }

        public BlogContext(DbContextOptions<BlogContext> options, IOptions<UserDbConfig> configOptions) 
            : base(options)
        {
            _configuration = configOptions.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.BlogConnection);
        }
    }
}