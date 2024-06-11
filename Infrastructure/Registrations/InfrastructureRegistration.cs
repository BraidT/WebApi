using Core.Repositories;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Registrations {
    public static class InfrastructureRegistration {
        public static IServiceCollection InfrastructureRegistrations(this IServiceCollection services, IConfiguration configuration) {
            services.AddDbContext<ApiContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                sqlOptions => sqlOptions.MigrationsAssembly(typeof(ApiContext).Assembly.FullName)));
            services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IBusinessParticipantRepository, BusinessParticipantRepository>();
            services.AddScoped<IEventBusinessParticipantRepository, EventBusinessParticipantRepository>();
            services.AddScoped<IPrivateParticipantRepository, PrivateParticipantRepository>();
            services.AddScoped<IEventPrivateParticipantRepository, EventPrivateParticipantRepository>();
            return services;
        }
    }
}
