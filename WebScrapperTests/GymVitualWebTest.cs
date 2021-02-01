using FluentAssertions;
using Moq;
using System;
using System.Threading.Tasks;
using WebScrapper.Services;
using WebScrapper.Web;
using Xunit;

namespace WebScrapperTests
{
    public class GymVitualWebTest
    {
        private readonly IWeb _web;

        public GymVitualWebTest()
        {
            _web = new GymVirtualWeb();
        }

        [Fact]
        public async Task Get_Videos_For_Today_Ok()
        {
            // Arrange
            var dateTimeMock = GetTodayIDateTimeService();

            // Act
            var videos = await _web.GetVideosAsync(dateTimeMock);

            // Assert
            videos.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task Get_Videos_For_Today_By_Name_Ok()
        {
            // Arrange
            var dateTimeMock = GetTodayIDateTimeService();
            var webScrapperService = new WebScrapperService(dateTimeMock);

            // Act
            var videos = await webScrapperService.GetVideosByWebNameAsync(Webs.GYM_VIRTUAL.Name);

            // Assert
            videos.Should().NotBeNullOrEmpty();
        }

        private IDateTimeService GetTodayIDateTimeService()
        {
            var dateTimeMock = new Mock<IDateTimeService>();
            dateTimeMock.Setup(service => service.GetToday()).Returns(DateTime.Today);

            return dateTimeMock.Object;
        }
    }
}
