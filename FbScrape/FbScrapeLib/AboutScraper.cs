using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Text.Json.Nodes;
namespace FbScrapeLib;

internal class AboutScraper : AbstractScraper
{

    private string _aboutClassName = "x1yztbdb";

    public AboutScraper(string baseUrl) : base(baseUrl)
    {
    }

    public override ScrapeResults GetScrapeResults()
    {
        try
        {
            _driver.Navigate().GoToUrl(_baseUrl);
            _wait.Until(driver => _driver.FindElement(By.TagName("body")));
            IWebElement element = _driver.FindElement(By.ClassName(_aboutClassName));
            return new ScrapeResults { Results = element.Text };
        }
        catch (NoSuchElementException ex)
        {
            Console.WriteLine("Element not found: " + ex.Message);
            return new ScrapeResults { Error = ex };
        }

    }
}