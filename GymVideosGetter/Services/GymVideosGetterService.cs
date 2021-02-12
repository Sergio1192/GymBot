using GymVideosGetter.Models;
using GymVideosGetter.Web;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymVideosGetter.Services
{
    public class GymVideosGetterService : IGymVideosGetterService
    {
        public Task<IEnumerable<VideoModel>> GetVideosByWebNameAsync(string name, DateTime date)
        {
            return Webs.GetByName(name).GetVideosAsync(date);
        }
    }
}
