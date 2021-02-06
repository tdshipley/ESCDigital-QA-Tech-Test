using ECSTest.PageObjects;
using System;

namespace ECSTest.Tests
{
    public class BaseTest : IDisposable
    {
        protected BasePageObject BasePageObject { get; }

        public BaseTest()
        {
            BasePageObject = new BasePageObject();
        }

        #region IDisposable Support
        private bool _disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (_disposedValue) return;

            BasePageObject?.QuitDriver();
            _disposedValue = true;
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }
        #endregion
    }
}
