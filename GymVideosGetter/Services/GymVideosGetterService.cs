using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GymVideosGetter.Models;
using GymVideosGetter.Web;

namespace GymVideosGetter.Services
{
    public class GymVideosGetterService : IGymVideosGetterService
    {
        private readonly IDateTimeService _dateTimeService;

        public GymVideosGetterService(IDateTimeService dateTimeService)
        {
            _dateTimeService = dateTimeService ?? throw new ArgumentNullException(nameof(dateTimeService));
        }

        public Task<IEnumerable<VideoModel>> GetVideosByWebNameAsync(string name)
        {
            return Webs.GetByName(name).GetVideosAsync(_dateTimeService);
        }
    }
}
