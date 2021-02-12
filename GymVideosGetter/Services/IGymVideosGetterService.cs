using GymVideosGetter.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymVideosGetter.Services
{
    public interface IGymVideosGetterService
    {
        Task<IEnumerable<VideoModel>> GetVideosByWebNameAsync(string name, DateTime date);
    }
}
