using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using WebScrapper.Models;
using WebScrapper.Services;

namespace WebScrapper.Web
{
    public sealed class GymVirtualWeb : IWeb
    {
        public string Name => "Gym virtual";

        public Uri BaseUrl => new Uri("http://gymvirtual.com/post_calendar/");

        public Uri GetUrl(IDateTimeService dateTimeService)
        {
            DateTime today = dateTimeService.GetToday();

            return new Uri($"{BaseUrl}/calendario-{today.ToString("MMMM", CultureInfo.CreateSpecificCulture("es-ES"))}-{today.Year}");
        }

        public Task<IEnumerable<VideoModel>> GetVideosAsync()
        {
            
        }
    }
}
