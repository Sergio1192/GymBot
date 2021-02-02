using Microsoft.Extensions.DependencyInjection;
using WebScrapper.Services;

namespace WebScrapper
{
    public static class WebScrapperExtensions
    {
        public static IServiceCollection AddWebScrapper(this IServiceCollection services)
        {
            services.AddSingleton<IDateTimeService, DateTimeService>();
            services.AddSingleton<IWebScrapperService, WebScrapperService>();

            return services;
        }
    }
}
