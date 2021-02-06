using OpenQA.Selenium;

namespace ECSTest.PageObjects
{
    public class HomePageObject : BasePageObject
    {
        public IWebElement RenderChallengeButtonElement
        {
            get
            {
                return Driver.FindElement(By.CssSelector("[data-test-id='render-challenge']"));
            }
        }

        public HomePageObject(IWebDriver driver = null) : base(driver)
        {
        }

        public override void WaitForPageLoad(By pageIdentifer, int pageLoadSecondsTimeout = 10)
        {
            var homePageIdentifier = By.CssSelector("[data-test-id='render-challenge']");
            base.WaitForPageLoad(homePageIdentifier, pageLoadSecondsTimeout);
        }
    }
}
