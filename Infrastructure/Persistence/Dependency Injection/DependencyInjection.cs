using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;
using Persistence.Repository_Interfaces;

namespace Persistence.Dependency_Injection
{
    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection services)
        {
            services.AddScoped<IArticleRepository, ArticleRepository>();
        }
    }
}