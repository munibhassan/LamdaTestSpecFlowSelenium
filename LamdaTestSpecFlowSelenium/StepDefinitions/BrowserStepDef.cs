using LamdaTestSpecFlowSelenium.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow.Assist;

namespace LamdaTestSpecFlowSelenium.StepDefinitions
{
    [Binding]
    public sealed class BrowserStepDef
    {
        IWebDriver _driver;
        String itemName = "MI";

        private readonly ScenarioContext _scenarioContext;
        public BrowserStepDef(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        [Given(@"I navigate to LamdaTest App on Following environment")]
        public void GivenINavigateToLamdaTestAppOnFollowingEnvironment(Table table)
        {
            dynamic data = table.CreateDynamicInstance();

            //For Local
            _driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Setup((string)data.Browser);

            _driver.Url = "https://lambdatest.github.io/sample-todo-app/"; 
        }

        [Then(@"select the first item")]
        public void ThenSelectTheFirstItem()
        {
            // Click on First Check box
            _driver.FindElement(By.Name("li1")).Click();

        }

        [Then(@"select the second item")]
        public void ThenSelectTheSecondItem()
        {
            // Click on Second Check box
            IWebElement secondCheckBox = _driver.FindElement(By.Name("li2"));
            secondCheckBox.Click();
        }

        [Then(@"find the text box to enter the new value")]
        public void ThenFindTheTextBoxToEnterTheNewValue()
        {
            // Enter Item name
            IWebElement textfield = _driver.FindElement(By.Id("sampletodotext"));
            textfield.SendKeys(itemName);
        }

        [Then(@"click the Submit button")]
        public void ThenClickTheSubmitButton()
        {
            // Click on Add button
            IWebElement addButton = _driver.FindElement(By.Id("addbutton"));
            addButton.Click();
        }

        [Then(@"verify whether the item is added to the list")]
        public void ThenVerifyWhetherTheItemIsAddedToTheList()
        {
            // Verified Added Item name
            IWebElement itemtext = _driver.FindElement(By.XPath("/html/body/div/div/div/form/input[1]"));
            String getText = itemtext.Text;

            // Check if the newly added item is present or not using
            // Condition constraint (Boolean)
            Assert.That((itemName.Contains(getText)), Is.True);

            /* Perform wait to check the output */
            System.Threading.Thread.Sleep(2000);

            Console.WriteLine("Firefox - Test Passed");
        }




    }
}