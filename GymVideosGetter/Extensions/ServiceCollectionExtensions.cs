using GymVideosGetter.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GymVideosGetter
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGymVideosGetter(this IServiceCollection services)
        {
            services.AddSingleton<IGymVideosGetterService, GymVideosGetterService>();

            return services;
        }
    }
}
