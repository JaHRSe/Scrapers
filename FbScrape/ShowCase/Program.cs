using FbScrapeLib;

class Program{
    static void Main(string[] args){
        string url = "https://www.facebook.com/NintendoAmerica/about";
        FbScrapeLib.FbScrape.Test(url);
    }
}