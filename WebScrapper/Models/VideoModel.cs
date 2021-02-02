namespace WebScrapper.Models
{
    public class VideoModel
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public VideoModel(string url)
        {
            this.Url = url;
        }
    }
}
