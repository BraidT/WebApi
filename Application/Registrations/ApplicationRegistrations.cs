using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.Registrations {
    public static class ApplicationRegistrations {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) {
            var executingAssembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(executingAssembly);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(executingAssembly));
            return services;
        }
    }
}
