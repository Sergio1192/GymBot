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
            var dateTimeMock = new Mock<IDateTimeService>();
            dateTimeMock.Setup(service => service.GetToday()).Returns(DateTime.Today);

            // Act
            var videos = await _web.GetVideosAsync(dateTimeMock.Object);

            // Assert
            videos.Should().NotBeNullOrEmpty();
        }
    }
}
