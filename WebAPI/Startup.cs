using Application.Dependency_Injection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Persistence.Repositories;
using Persistence.Repository_Interfaces;
using Persistence.Setting_Interfaces;
using Persistence.Settings;

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
            services.AddSingleton<IArticleRepository, ArticleRepository>();

            services.Configure<ArticlesDatabaseSettings>(Configuration.GetSection(nameof(ArticlesDatabaseSettings)));

            services.AddSingleton<IArticlesDatabaseSettings>(sp => sp.GetRequiredService<IOptions<ArticlesDatabaseSettings>>().Value);

            services.AddApplication();

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
