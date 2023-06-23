using KeyWorkerService.Application.UseCases.Local;
using KeyWorkerService.Domain.Abstractions.Local;
using KeyWorkerService.Infrastructure.Data;
using KeyWorkerService.Infrastructure.Repositories.Local;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KeyWorkerService.Infrastructure
{
    public static class ServiceCollectionSetupExtensions
    {
        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DefaultContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Local"))
            );
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRequestUsuarioRepository, UsuarioRepository>();
        } 

        public static void AddUseCaseServices(this IServiceCollection services)
        {
            services.AddSingleton<IUsuario, UsuarioUseCase>();
        }
    }
}
