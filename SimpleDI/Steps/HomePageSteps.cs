using BoDi;
using SimpleDI.Helpers;
using TechTalk.SpecFlow;

namespace SimpleDI.Steps
{
    [Binding]
    public sealed class HomePageSteps:BaseStep
    {
        private SeleniumHelper seleniumHelper;
        public HomePageSteps(IObjectContainer objectContainer,SeleniumHelper seleniumHelper) : base(objectContainer)
        {
            this.seleniumHelper = seleniumHelper;
        }
        [Given(@"I entered to ""(.*)""")]
        public void GivenIEnteredTo(string url)
        {
            seleniumHelper.CloseSecondTabFromPlugin();
            WebDriver.Navigate().GoToUrl(url);
        }
    }
}
