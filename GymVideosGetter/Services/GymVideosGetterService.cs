using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GymVideosGetter.Models;
using GymVideosGetter.Web;

namespace GymVideosGetter.Services
{
    public class GymVideosGetterService : IGymVideosGetterService
    {
        public Task<IEnumerable<VideoModel>> GetVideosByWebNameAsync(string name, DateTime? date = null)
        {
            return Webs.GetByName(name).GetVideosAsync(date ?? DateTime.Today);
        }
    }
}
