using FluentAssertions;
using GymVideosGetter.Services;
using GymVideosGetter.Web;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace WebScrapperTests
{
    public class GymVitualWebTest
    {
        private static readonly DateTime DATE = new DateTime(2021, 2, 12);

        private readonly IWeb _web;

        public GymVitualWebTest()
        {
            _web = new GymVirtualWeb();
        }

        [Fact]
        public async Task Get_Videos_For_Today()
        {
            // Arrange
            var date = DATE;

            // Act
            var videos = await _web.GetVideosAsync(date);

            // Assert
            videos.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task Get_Videos_For_Today_By_Name()
        {
            // Arrange
            var date = DATE;
            var webScrapperService = new GymVideosGetterService();

            // Act
            var videos = await webScrapperService.GetVideosByWebNameAsync(Webs.GYM_VIRTUAL.Name, date);

            // Assert
            videos.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task Videos_Not_Repeated()
        {
            // Arrange
            var date = DATE;

            // Act
            var videos = await _web.GetVideosAsync(date);

            // Assert
            videos.Select(v => v.Url).Should().OnlyHaveUniqueItems();
        }
    }
}
