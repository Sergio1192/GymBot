using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GymVideosGetter.Models;
using GymVideosGetter.Services;

namespace GymVideosGetter.Web
{
    public interface IWeb
    {
        string Name { get; }
        string BaseUrl { get; }

        string GetUrl(IDateTimeService dateTimeService);

        Task<IEnumerable<VideoModel>> GetVideosAsync(IDateTimeService dateTimeService);
    }
}
