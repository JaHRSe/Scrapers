using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
namespace FbScrapeLib;


public class FbScrape
{

    private string _baseUrl = "";

    private string _aboutClassName = "x1yztbdb";
    private IWebDriver _driver;
    private ChromeOptions _chromeOptions;

    private WebDriverWait _wait;

    public FbScrape(string baseUrl){
        _baseUrl = baseUrl;
        _chromeOptions = new ChromeOptions();
        _driver = new ChromeDriver(_chromeOptions);
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
    }

    private static ChromeOptions ConfigureChromeOptions(){
        ChromeOptions options = new ChromeOptions();
        options.AddArgument("--disable-notifications");
        options.AddArgument("--disable-infobars");
        options.AddArgument("--start-maximized");
        options.AddArgument("headless");
        return options;
    }

    public ScrapeResults getAboutInfo(){
        try{
            _driver.Navigate().GoToUrl(_baseUrl);
            _wait.Until(driver => _driver.FindElement(By.TagName("body")));
            IWebElement element = _driver.FindElement(By.ClassName(_aboutClassName));
            return new ScrapeResults{Results=element.Text};
        } catch (NoSuchElementException ex){
            Console.WriteLine("Element not found: "+ex.Message);
            return new ScrapeResults{Error=ex};
        }

    }

    // public static void Test(string url){
    //     string className = "x1yztbdb";
    //     ChromeOptions options = ConfigureChromeOptions();
    //     using (IWebDriver driver = new ChromeDriver(options)){
    //         WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
    //         try{
    //             driver.Navigate().GoToUrl(url);
    //             wait.Until(drv => drv.FindElement(By.TagName("body")));
    //             IWebElement element = driver.FindElement(By.ClassName(className));
    //             string text = element.Text;
    //             Console.WriteLine(text);
    //         } catch (NoSuchElementException ex){
    //             Console.WriteLine("Element not found: " + ex.Message);
    //         }
    //     }
    // }

  
}
