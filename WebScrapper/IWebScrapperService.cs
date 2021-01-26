using System.Collections.Generic;
using WebScrapper.Models;

namespace WebScrapper
{
    public interface IWebScrapperService
    {
        IEnumerable<VideoModel> GetVideosAsync();
    }
}
