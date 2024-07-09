using System.Collections.Generic;
namespace FbScrapeLib;

public class FbScraper : IDisposable
{
    private readonly string _baseUrl;
    private readonly AboutScraper _aboutScraper;
    private bool disposed = false;
    public FbScraper(string baseUrl)
    {
        _baseUrl = baseUrl;
        _aboutScraper = new AboutScraper(baseUrl);
    }

    public ScrapeResults ScrapeAbout()
    {
        return _aboutScraper.GetScrapeResults();
    }

    public Dictionary<string, ScrapeResults> ScrapeAll()
    {
        var results = new Dictionary<string, ScrapeResults>
        {
            {"About", ScrapeAbout()},
        };
        return results;
    }


    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                _aboutScraper.Dispose();
            }
            disposed = true;
        }
    }

    ~FbScraper()
    {
        Dispose(disposing: false);
    }
}