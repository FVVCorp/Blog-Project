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
using Persistence.Settings;
using Persistence.ContextInterfaces;
using Application.QueryHandlers;

namespace WebAPI
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMediatR(typeof(GetAllArticlesQueryHandler).Assembly);
            services.AddScoped<IArticlesDbContext, ArticlesDbContext>();
            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();


            services.Configure<ArticlesDbSettings>(options =>
            {
                options.Connection = Configuration
                    .GetSection("ArticlesDbSettings:Connection").Value;
                options.DatabaseName = Configuration
                    .GetSection("ArticlesDbSettings:DatabaseName").Value;
                options.CollectionName = Configuration
                    .GetSection("ArticlesDbSettings:CollectionName").Value;
            });

            services.Configure<BlogConfiguration>(options =>
            {
                options.IdentityDatabaseConnection = Configuration
                    .GetSection("ConnectionStrings:BlogConnection").Value;
            });
            services.AddDbContext<BlogContext>(options => options
                .UseSqlServer(Configuration.GetSection("ConnectionStrings:BlogConnection").Value));

            var connectionString1 = Configuration.GetSection("ConnectionStrings:BlogConnection").Value;
            var connectionString2 = Configuration.GetConnectionString("BlogConnection");

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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}