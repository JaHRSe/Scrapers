using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace FbScrapeLib;


public class FbScrape
{


    public static void Test(string url){
        string className = "x1yztbdb";
        ChromeOptions options = ConfigureChromeOptions();
        using (IWebDriver driver = new ChromeDriver(options)){
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            try{
                driver.Navigate().GoToUrl(url);
                wait.Until(drv => drv.FindElement(By.TagName("body")));
                IWebElement element = driver.FindElement(By.ClassName(className));
                string text = element.Text;
                Console.WriteLine(text);
            } catch (NoSuchElementException ex){
                Console.WriteLine("Element not found: " + ex.Message);
            }
        }
    }

    private static ChromeOptions ConfigureChromeOptions(){
        ChromeOptions options = new ChromeOptions();
        options.AddArgument("--disable-notifications");
        options.AddArgument("--disable-infobars");
        options.AddArgument("--start-maximized");
        options.AddArgument("headless");
        return options;
    }
}
