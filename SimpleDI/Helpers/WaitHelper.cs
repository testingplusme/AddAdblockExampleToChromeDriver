using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SimpleDI.Helpers
{
    class WaitHelper
    {
        private IWebDriver driver;
        public WaitHelper(IWebDriver driver)
        {
            this.driver = driver;
        }

        public WebDriverWait Wait()
        {
            return new WebDriverWait(driver,TimeSpan.FromSeconds(15));
        }
    }
}
