using ECSTest.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ECSTest.PageObjects
{
    public class BasePageObject : IPageObject
    {
        private const int DefaultTimeoutSeconds = 10;
        private const string BaseUrl = "http://localhost:3000";
        private readonly By _basePageIdentifier = By.Id("home");

        protected IWebDriver Driver { get; private set; }

        public BasePageObject(IWebDriver driver = null)
        {
            if (driver != null)
            {
                Driver = driver;
            }
            else
            {
                var driverPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
                var options = new ChromeOptions();
                options.AddArgument("--start-maximized");
                Driver = new ChromeDriver(driverPath, options);
                Driver.Navigate().GoToUrl(BaseUrl);
            }

            WaitForPageLoad(_basePageIdentifier);
        }

        public void QuitDriver()
        {
            Driver.Quit();
            Driver = null;
        }

        public T Get<T>() where T : IPageObject
        {
            return (T)Activator.CreateInstance(typeof(T), Driver);
        }

        public virtual void WaitForPageLoad(By pageIdentifer, int pageLoadSecondsTimeout = DefaultTimeoutSeconds)
        {
            FindVisibleElement(pageIdentifer, pageLoadSecondsTimeout);
        }
        
        public IWebElement FindVisibleElement(By by, int timeoutInSeconds = DefaultTimeoutSeconds)
        {
            return FindVisibleElements(by, timeoutInSeconds).First();
        }

        public IReadOnlyCollection<IWebElement> FindVisibleElements(By by, int timeoutInSeconds = DefaultTimeoutSeconds)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));

            return Driver.FindElements(by);
        }
    }
}
