using Microsoft.Extensions.DependencyInjection;
using GymVideosGetter.Services;

namespace GymVideosGetter
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGymVideosGetter(this IServiceCollection services)
        {
            services.AddSingleton<IDateTimeService, DateTimeService>();
            services.AddSingleton<IGymVideosGetterService, GymVideosGetterService>();

            return services;
        }
    }
}
