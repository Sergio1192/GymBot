using System;

namespace WebScrapper.Models
{
    public class VideoModel
    {
        public Uri Url { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public VideoModel(string url)
        {
            this.Url = new Uri(url);
        }
    }
}
