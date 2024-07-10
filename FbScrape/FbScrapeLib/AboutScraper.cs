using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Text.Json.Nodes;
namespace FbScrapeLib;

internal class AboutScraper : AbstractScraper
{

    private string aboutBlockClassName = "x19xhxss";

    public AboutScraper(string baseUrl) : base(baseUrl + "/about")
    {
    }

    public override Dictionary<string, ScrapeResults> GetScrapeResults()
    {
        var results = new Dictionary<string, ScrapeResults> { };
        try
        {
            Console.WriteLine($"Scraping: {_baseUrl}");
            _driver.Navigate().GoToUrl(_baseUrl);
            _wait.Until(driver => _driver.FindElement(By.TagName("body")));
            results.Add("aboutBlock", TryFindElementTextByClass(aboutBlockClassName));

        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine("Element not found: " + ex.Message);
        }
        return results;
    }
}