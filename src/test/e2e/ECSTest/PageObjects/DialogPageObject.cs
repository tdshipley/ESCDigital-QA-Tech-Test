using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace ECSTest.PageObjects
{
    public class DialogPageObject : BasePageObject
    {
        private const string SuccessMessage = "Congratulations you have succeeded";

        public IWebElement CloseButtonElement
        {
            get
            {
                return Driver.FindElement(By.CssSelector("[data-test-id='close-btn']"));
            }
        }

        public IWebElement DialogMessage
        {
            get
            {
                return Driver.FindElement(By.ClassName("dialog"));
            }
        }

        public DialogPageObject(IWebDriver driver = null) : base(driver)
        {
        }

        public override void WaitForPageLoad(By pageIdentifer, int pageLoadSecondsTimeout = 10)
        {
            var dialogPageIdentifer = By.CssSelector("[data-test-id='close-btn']");
            base.WaitForPageLoad(dialogPageIdentifer, pageLoadSecondsTimeout);
        }

        public DialogPageObject WaitForSuccessMessage(int timeoutSeconds = 10)
        {
            var message = DialogMessage.Text;
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(DialogMessage, SuccessMessage));

            return this;
        }
    }
}
