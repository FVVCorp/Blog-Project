using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence.Repositories;
using Persistence.RepositoryInterfaces;
using Persistence.Settings;
using Application.QueryHandlers;
using Persistence.ContextInterfaces;
using Persistence.Contexts;

namespace WebAPI
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
            services.Configure<ArticlesDbSettings>(options =>
            {
                options.Connection = Configuration.GetSection("ArticlesDbSettings:Connection").Value;
                options.DatabaseName = Configuration.GetSection("ArticlesDbSettings:DatabaseName").Value;
                options.CollectionName = Configuration.GetSection("ArticlesDbSettings:CollectionName").Value;
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}