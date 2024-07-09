using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.ComponentModel;
namespace FbScrapeLib;


public abstract class AbstractScraper : IDisposable
{

    protected string _baseUrl = "";

    protected IWebDriver _driver;
    protected WebDriverWait _wait;

    private bool disposed = false;

    public AbstractScraper(string baseUrl)
    {
        _baseUrl = baseUrl;
        ChromeOptions options = ConfigureChromeOptions();
        _driver = new ChromeDriver(options);
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
    }

    private static ChromeOptions ConfigureChromeOptions()
    {
        ChromeOptions options = new ChromeOptions();
        options.AddArgument("--disable-notifications");
        options.AddArgument("--disable-infobars");
        options.AddArgument("--start-maximized");
        options.AddArgument("--headless");
        return options;
    }

    public abstract ScrapeResults GetScrapeResults();

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            Console.WriteLine("Stopping the driver");
            _driver.Quit();
            disposed = true;
        }
    }

}
