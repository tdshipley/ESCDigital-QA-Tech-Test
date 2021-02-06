using OpenQA.Selenium;
using System.Collections.Generic;

namespace ECSTest.Interfaces
{
    public interface IPageObject
    {
        T Get<T>() where T : IPageObject;

        void WaitForPageLoad(By pageIdentifer, int pageLoadSecondsTimeout);

        IWebElement FindVisibleElement(By by, int timeoutInSeconds = 10);

        IReadOnlyCollection<IWebElement> FindVisibleElements(By by, int timeoutInSeconds = 10);
    }
}
