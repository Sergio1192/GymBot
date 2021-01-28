using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebScrapper.Models;
using WebScrapper.Services;

namespace WebScrapper.Web
{
    public interface IWeb
    {
        string Name { get; }
        string BaseUrl { get; }

        string GetUrl(IDateTimeService dateTimeService);

        Task<IEnumerable<VideoModel>> GetVideosAsync(IDateTimeService dateTimeService);
    }
}
