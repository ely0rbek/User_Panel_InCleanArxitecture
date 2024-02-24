using CleanProj.Application.Services.UserProfileServices;
using CleanProj.Infrastructure;
using CleanProj.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanProj.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserProfileService, UserProfileService>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
