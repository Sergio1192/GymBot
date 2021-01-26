using System;
using System.Collections.Generic;
using System.Globalization;
using WebScrapper.Models;

namespace WebScrapper.Web
{
    public sealed class GymVirtualWeb : IWeb
    {
        public string Name => "Gym virtual";

        public Uri BaseUrl => new Uri("http://gymvirtual.com/post_calendar/");

        public Uri Url
        {
            get
            {
                return new Uri($"{BaseUrl.ToString()}/calendario-{DateTime.Today.ToString("MMMM", CultureInfo.CreateSpecificCulture("es-ES"))}-{DateTime.Today.Year}");
            }
        }

        public IEnumerable<VideoModel> GetVideosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
