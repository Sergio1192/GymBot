using HtmlAgilityPack;
using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using WebScrapper.Models;
using WebScrapper.Services;

namespace WebScrapper.Web
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
            try
            {
                var kk = await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);

                using (var browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = false }))
                {
                    using (var page = await browser.NewPageAsync())
                    {
                        await page.GoToAsync(this.GetUrl(dateTimeService), WaitUntilNavigation.DOMContentLoaded);

                        await page.WaitForSelectorAsync(".semana > .today .elementsDia .titleElemCalendar");
                        var list = await page.QuerySelectorAllAsync(".semana > .today.elementsDia.titleElemCalendar");

                        //var kk = await page.WaitForSelectorAsync(".semana > .today > .elementsDia > .titleElemCalendar > b");
                        //await kk.ClickAsync();

                        //await page.ClickAsync(".semana > .today > .elementsDia > .titleElemCalendar > b")
                        //await page.WaitForNavigationAsync();

                        //await page.ClickAsync("input[name='btnK']");
                        //await Task.Delay(1000);

                        /*await page.TypeAsync("input[name='q']", ".NET Fiddle"); //enter what to search for

                        //await page.ClickAsync("input[name='btnK']"); //press google search button
                        //The code above doesn't actually work since there are 2 same buttons for running search
                        //luckily I can just execute JS to click the first button
                        string jsScript = "document.querySelector(\"input[name='btnK']\").click()";

                        await page.EvaluateExpressionAsync(jsScript);

                        //Wait for results to render
                        await Task.Delay(2000);*/

                        string htmlContent = await page.GetContentAsync();

                        Console.WriteLine("Press any key to close browser and program.");
                        Console.ReadKey();

                        await browser.CloseAsync();

                        var htmlDocument = new HtmlDocument();
                        htmlDocument.LoadHtml(htmlContent);

                        return null;
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
