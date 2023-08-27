using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using TechTalk.SpecFlow;

namespace LamdaTestSpecFlowSelenium.Drivers
{
    public class SeleniumDriver
    {
        private IWebDriver driver;
        private string _ltUserName;
        private string _ltAppKey;

        private readonly ScenarioContext _scenarioContext;

        public SeleniumDriver(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _ltUserName = "munib.nexus";
            _ltAppKey = "CLAfMEKzswIDNKTgHPuA1Nuyl3TBPd8XiiFw12HobJvdqBJLCY";
        }

        public IWebDriver Setup(string os, int version, string browserName, string build)
        {
            //DriverOptions options = GetBrowserOptions(browserName);

            //// Set the desired capabilities based on input parameters
            //options.PlatformName = os;
            //options.BrowserVersion = version.ToString();
            //options.AddAdditionalOption("screenResolution", "1280x800");
            //options.AddAdditionalOption("user", _ltUserName);
            //options.AddAdditionalOption("accessKey", _ltAppKey);
            //options.AddAdditionalOption("build", build);
            //options.AddAdditionalOption("name", "Selenium Test");

            dynamic capablity = GetBrowserOptions(browserName);

            if (browserName != "Safari" && browserName != "MicrosoftEdge")
            {
                capablity.AddAdditionalCapability("platform", os, true);
                capablity.AddAdditionalCapability("version", version, true);
                capablity.AddAdditionalCapability("name", browserName, true);
                capablity.AddAdditionalCapability("build", build, true);
                capablity.AddAdditionalCapability("user", _ltUserName, true);
                capablity.AddAdditionalCapability("accessKey", _ltAppKey, true);
            }
            else
            {
                capablity.AddAdditionalCapability("platform", os);
                capablity.AddAdditionalCapability("version", version);
                capablity.AddAdditionalCapability("name", browserName);
                capablity.AddAdditionalCapability("build", build);
                capablity.AddAdditionalCapability("user", _ltUserName);
                capablity.AddAdditionalCapability("accessKey", _ltAppKey);
            }



            // driver = new RemoteWebDriver(new Uri($"https://{_ltUserName}:{_ltAppKey}@hub.lambdatest.com/wd/hub"), options);
            driver = new RemoteWebDriver(new Uri("http://192.168.1.6:4444/ui#/sessions"), capablity);
            // Set the driver
            _scenarioContext.Set(driver, "Webdriver");

            driver.Manage().Window.Maximize();

            return driver;
        }

        //private DriverOptions GetBrowserOptions(string browserName)
        //{
        //    DriverOptions options = browserName.ToLower() switch
        //    {
        //        "chrome" => new ChromeOptions(),
        //        "firefox" => new FirefoxOptions(),
        //        "edge" => new EdgeOptions(),
        //        "safari" => new SafariOptions(),
        //        _ => throw new WebDriverException($"Unsupported browser: {browserName}"),
        //    };
        //    return options;
        //}

        private dynamic GetBrowserOptions(string browserName)
        {
            if (browserName.ToLower() == "chrome")
                return new ChromeOptions();
            if (browserName.ToLower() == "firefox")
                return new EdgeOptions();
            if (browserName.ToLower() == "EdgeOptions")
                return new FirefoxOptions();
            if (browserName.ToLower() == "Safari")
                return new SafariOptions();

            return new ChromeOptions();
        }
    }
}
