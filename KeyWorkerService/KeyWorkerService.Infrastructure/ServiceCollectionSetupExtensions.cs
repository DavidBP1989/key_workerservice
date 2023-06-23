using KeyWorkerService.Application.UseCases.Default;
using KeyWorkerService.Application.UseCases.LoadCUtoQS;
using KeyWorkerService.Infrastructure.Data;
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
                options.UseSqlServer(configuration.GetConnectionString("Default"))
            );
            services.AddDbContext<TblSexteContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("TblSEXTE"))
            );
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<Domain.Abstractions.Default.IRequestUsuarioRepository, Repositories.Default.UsuarioRepository>();
            services.AddScoped<Domain.Abstractions.TblSEXTE.IRequestUsuarioRepository, Repositories.TblSEXTE.UsuarioRepository>();
        } 

        public static void AddUseCaseServices(this IServiceCollection services)
        {
            services.AddSingleton<IUsuario, UsuarioUseCase>();
            services.AddSingleton<ILoadCUtoQS, LoadCUtoQSUseCase>();
        }
    }
}
