using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
            // DIs for ArticlesDb (MongoDB)
            services.Configure<ArticlesDbSettings>(options =>
            {
                options.Connection = Configuration
                    .GetSection("ArticlesDbSettings:Connection").Value;
                options.DatabaseName = Configuration
                    .GetSection("ArticlesDbSettings:DatabaseName").Value;
                options.CollectionName = Configuration
                    .GetSection("ArticlesDbSettings:CollectionName").Value;
            });
            services.AddMediatR(typeof(GetAllArticlesQueryHandler).Assembly);
            services.AddScoped<IArticlesDbContext, ArticlesDbContext>();
            services.AddScoped<IArticleRepository, ArticleRepository>();

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