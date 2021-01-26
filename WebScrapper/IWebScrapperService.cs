using System.Collections.Generic;
using System.Threading.Tasks;
using WebScrapper.Models;

namespace WebScrapper
{
    public interface IWebScrapperService
    {
        Task<IEnumerable<VideoModel>> GetVideosByWebNameAsync(string name);
    }
}
