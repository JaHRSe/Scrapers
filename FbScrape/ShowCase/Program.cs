using FbScrapeLib;

class Program{
    static void Main(string[] args){
        string url = "https://www.facebook.com/NintendoAmerica/about";
        FbScrape scraper = new FbScrape(url);
        ScrapeResults results = scraper.getAboutInfo();
        if(results.IsSuccess){
            Console.WriteLine(results.Results);
        }else{
            Console.WriteLine(results.Error);
        }
    }
}