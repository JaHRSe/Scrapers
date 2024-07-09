using FbScrapeLib;

class Program
{
    static void Main(string[] args)
    {
        string url = "https://www.facebook.com/NintendoAmerica/about";
        using (FbScraper scraper = new FbScraper(url))
        {
            ScrapeResults aboutData = scraper.ScrapeAbout();
            if (aboutData.IsSuccess)
            {
                Console.WriteLine(aboutData.Results);
            }
            else
            {
                Console.WriteLine(aboutData.Error);
            }

        }

    }
}