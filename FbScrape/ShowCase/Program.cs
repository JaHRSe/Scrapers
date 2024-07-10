using FbScrapeLib;
using OpenQA.Selenium.DevTools.V124.Storage;

class Program
{
    static void Main(string[] args)
    {
        string url = "https://www.facebook.com/NintendoAmerica";
        Dictionary<string, ScrapeResults> aboutData = [];
        using (FbScraper scraper = new FbScraper(url))
        {
            aboutData = scraper.ScrapeAbout();

        }

        foreach (var result in aboutData)
        {
            if (result.Value.IsSuccess)
            {
                Console.WriteLine($"{result.Key}: {result.Value.Results}");
            }
            else
            {
                Console.WriteLine($"Error: " + result.Value.Error);
            }
        }

    }
}