using Application.QueryHandlers;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence.Configuration;
using Persistence.Contexts;
using Persistence.Repositories;
using Persistence.RepositoryInterfaces;

namespace UsersAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // DIs for UsersDb (EF)
            services.AddScoped<IUserRepository, UserRepository>();
            services.Configure<BlogConfiguration>(options =>
            {
                options.IdentityDatabaseConnection = Configuration
                    .GetSection("ConnectionStrings:IdentityDatabaseConnection").Value;
            });
            services.AddMediatR(typeof(GetUsersQueryHandler).Assembly);
            services.AddDbContext<BlogContext>(options => options
                .UseSqlServer(Configuration.GetSection("ConnectionStrings:IdentityDatabaseConnection").Value));

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
