using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebScrapper.Models;
using WebScrapper.Web;

namespace WebScrapper.Services
{
    public class WebScrapperService : IWebScrapperService
    {
        private readonly IDateTimeService _dateTimeService;

        public WebScrapperService(IDateTimeService dateTimeService)
        {
            _dateTimeService = dateTimeService ?? throw new ArgumentNullException(nameof(dateTimeService));
        }

        public Task<IEnumerable<VideoModel>> GetVideosByWebNameAsync(string name)
        {
            return Webs.GetByName(name).GetVideosAsync(_dateTimeService);
        }
    }
}
