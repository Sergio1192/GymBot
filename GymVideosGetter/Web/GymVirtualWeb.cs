using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using GymVideosGetter.Models;
using GymVideosGetter.Services;

namespace GymVideosGetter.Web
{
    public sealed class GymVirtualWeb : IWeb
    {
        public string Name => "Gym virtual";

        public string BaseUrl => "http://gymvirtual.com/post_calendar";

        public string GetUrl(IDateTimeService dateTimeService)
        {
            DateTime today = dateTimeService.GetToday();

            return $"{BaseUrl}/calendario-{today.ToString("MMMM", CultureInfo.CreateSpecificCulture("es-ES"))}-{today.Year}";
        }

        public async Task<IEnumerable<VideoModel>> GetVideosAsync(IDateTimeService dateTimeService)
        {
            const string SELECTOR_LIST_LINKS = ".semana > .today .elementsDia .titleElemCalendar";
            const string SELECTOR_VIDEO = ".modalCalendario > .contentModalCalendar .video iframe";
            const string SELECTOR_CLOSE_VIDEO = ".modalCalendario > .cerrarModal";
            const string SELECTOR_COOKIE = ".sra-layout .sra-panel__aside__buttons a";

            const string PROPERTY_NAME_VIDEO_URL = "src";

            const string YOUTUBE_ROUTE_EMBED = "embed/";
            const string YOUTUBE_ROUTE_NORMAL = "watch?v=";

            // Download de browser
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);

            using (var browser = await Puppeteer.LaunchAsync(new LaunchOptions() { Headless = false }))
            {
                using (var page = await browser.NewPageAsync())
                {
                    // Go to the page
                    await page.GoToAsync(this.GetUrl(dateTimeService), WaitUntilNavigation.Networkidle0);

                    // Acept Cookies
                    var cookieButtons = await page.WaitAndQuerySelectorAllAsync(SELECTOR_COOKIE);
                    await cookieButtons.First().ClickAsync();

                    // Video links
                    var links = await page.WaitAndQuerySelectorAllAsync(SELECTOR_LIST_LINKS);

                    var videos = new List<VideoModel>();
                    foreach (var link in links)
                    {
                        await link.HoverAsync();
                        await link.ClickAsync();
                        await page.WaitForTimeoutAsync(1000);

                        // Get video url
                        var videoUrl = await page.GetAttributeFromQuerySelectorAsync<string>(SELECTOR_VIDEO, PROPERTY_NAME_VIDEO_URL);
                        videoUrl = videoUrl?.Replace(YOUTUBE_ROUTE_EMBED, YOUTUBE_ROUTE_NORMAL);

                        // Close dialog
                        var closeDialog = await page.WaitForSelectorAsync(SELECTOR_CLOSE_VIDEO);
                        await closeDialog.ClickAsync();
                        await page.WaitForTimeoutAsync(1000);

                        // Create model
                        var video = new VideoModel(videoUrl);
                        videos.Add(video);
                    }

                    await page.CloseAsync();
                    await browser.CloseAsync();

                    return videos;
                }
            }
        }
    }
}
