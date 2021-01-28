using System.Threading.Tasks;
using WebScrapper.Services;
using WebScrapper.Web;
using Xunit;

namespace WebScrapperTests
{
    public class GymVitualWebTest
    {
        [Fact]
        public async Task Ok()
        {
            var videos = await new GymVirtualWeb().GetVideosAsync(new DateTimeService());
        }
    }
}
