using Abigo.Domain.Models;
using Abigo.Domain.Repositories;
using Abigo.Infrastructure.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Abigo.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection service)
        {
            AddRepositories(service);
        }

        private static void AddRepositories(IServiceCollection service)
        {
            service.AddScoped<IUnitOfWork, UnitOfWork>();
            service.AddScoped<IAccountablesRepository, AccountablesRepository>();
            service.AddScoped<IAvailableLocalesRepository, AvailableLocalesRepository>();
        }
    }

}