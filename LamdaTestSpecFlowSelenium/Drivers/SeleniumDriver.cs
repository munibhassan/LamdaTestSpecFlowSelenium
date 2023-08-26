using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
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

        public IWebDriver Setup()
        {
            var firefoxOptions = new FirefoxOptions();
            driver = new RemoteWebDriver(new Uri("http://192.168.1.6:4444/ui#/sessions"), firefoxOptions.ToCapabilities());

            //Set the driver
            _scenarioContext.Set(driver, "Webdriver");

            driver.Manage().Window.Maximize();

            return driver;
        }
    }
}
