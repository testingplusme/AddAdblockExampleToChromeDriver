using System.Linq;
using OpenQA.Selenium;

namespace SimpleDI.Helpers
{
    public class SeleniumHelper
    {
        private IWebDriver driver;
        private WaitHelper waitHelper;
        public SeleniumHelper(IWebDriver driver)
        {
            this.driver = driver;
            waitHelper=new WaitHelper(driver);
        }

        public void CloseSecondTabFromPlugin()
        {
            waitHelper.Wait().Until(x => driver.WindowHandles);
            var webDriverCurrentWindowHandle = driver.WindowHandles;
            if (webDriverCurrentWindowHandle.Count() <= 1) return;
            driver.SwitchTo().Window(webDriverCurrentWindowHandle[1]).Close();
            driver.SwitchTo().Window(webDriverCurrentWindowHandle[0]);
        }
    }
}
