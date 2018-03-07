using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using SimpleDI.Helpers;
using TechTalk.SpecFlow;

namespace SimpleDI.TestSettings
{
    [Binding]
    public sealed class TestSettings
    {
        private readonly IObjectContainer objectContainer;
        private WebDriverHelper webDriverHelper;
        private readonly ScenarioContext scenarioContext;

        public TestSettings(IObjectContainer objectContainer,ScenarioContext scenario)
        {
            this.objectContainer = objectContainer;
            this.scenarioContext = scenario;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var options = new ChromeOptions();
            options.AddArguments("load-extension=C:\\Users\\WhatAdmin\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Extensions\\gighmmpiobklfepjocnamgkkbiglidom\\3.26.1_0");
            var capabilities = new DesiredCapabilities();
            capabilities.SetCapability(ChromeOptions.Capability, options);
            var driver = new ChromeDriver(options);
            objectContainer.RegisterInstanceAs<IWebDriver>(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var remoteWebDriver = objectContainer.Resolve<IWebDriver>();
            remoteWebDriver.Close();
            remoteWebDriver.Dispose();
        }
    }
}
