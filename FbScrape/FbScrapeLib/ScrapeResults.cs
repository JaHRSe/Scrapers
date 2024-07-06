using OpenQA.Selenium;
namespace FbScrapeLib;

public class ScrapeResults{
    public string? Results { get; set; } = null;
    public NoSuchElementException? Error { get; set; } = null;
    public bool IsSuccess => Error == null;

}