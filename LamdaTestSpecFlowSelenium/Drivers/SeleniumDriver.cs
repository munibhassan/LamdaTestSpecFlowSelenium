using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Chromium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamdaTestSpecFlowSelenium.Drivers
{
    public class SeleniumDriver
    {
        private IWebDriver driver;

        private readonly ScenarioContext _scenarioContext;

        public SeleniumDriver(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        public IWebDriver Setup(string browserName)
        {
            dynamic capablity = GetBrowserOptions(browserName);
            driver = new RemoteWebDriver(new Uri("http://192.168.1.6:4444/ui#/sessions"), capablity.ToCapabilities());

            //Set the driver 
            _scenarioContext.Set(driver, "Webdriver");

            driver.Manage().Window.Maximize();

            return driver;
        }

        private dynamic GetBrowserOptions(string browserName)
        {
            if (browserName.ToLower() == "chrome")
                return new ChromeOptions();
            if (browserName.ToLower() == "firefox")
                return new FirefoxOptions();
            if (browserName.ToLower() == "EdgeOptions")
                return new FirefoxOptions();
            if (browserName.ToLower() == "Safari")
                return new SafariOptions();

            return new ChromeOptions();
        }

    }
}
