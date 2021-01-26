using System;

namespace WebScrapper.Web
{
    public interface IWeb : IWebScrapperService
    {
        string Name { get; }
        Uri BaseUrl { get; }
        Uri Url { get; }
    }
}
