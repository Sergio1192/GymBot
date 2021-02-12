using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GymVideosGetter.Models;

namespace GymVideosGetter.Services
{
    public interface IGymVideosGetterService
    {
        Task<IEnumerable<VideoModel>> GetVideosByWebNameAsync(string name, DateTime? date = null);
    }
}
