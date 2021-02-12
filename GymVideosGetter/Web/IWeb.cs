using GymVideosGetter.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymVideosGetter.Web
{
    public interface IWeb
    {
        string Name { get; }
        string BaseUrl { get; }

        string GetUrl(DateTime date);

        Task<IEnumerable<VideoModel>> GetVideosAsync(DateTime date);
    }
}
