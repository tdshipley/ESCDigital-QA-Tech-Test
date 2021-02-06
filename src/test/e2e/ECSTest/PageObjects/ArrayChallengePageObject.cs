using ECSTest.DTOs;
using OpenQA.Selenium;

namespace ECSTest.PageObjects
{
    public class ArrayChallengePageObject : BasePageObject
    {
        public int[] FirstRowValues
        {
            get
            {
                return ParseRow(1);
            }
        }

        public int[] SecondRowValues
        {
            get
            {
                return ParseRow(2);
            }
        }

        public int[] ThirdRowValues
        {
            get
            {
                return ParseRow(3);
            }
        }

        public IWebElement FirstAnswerTextbox
        {
            get
            {
                return Driver.FindElement(By.CssSelector("[data-test-id='submit-1']"));
            }
        }

        public IWebElement SecondAnswerTextbox
        {
            get
            {
                return Driver.FindElement(By.CssSelector("[data-test-id='submit-2']"));
            }
        }

        public IWebElement ThirdAnswerTextbox
        {
            get
            {
                return Driver.FindElement(By.CssSelector("[data-test-id='submit-3']"));
            }
        }

        public IWebElement NameTextbox
        {
            get
            {
                return Driver.FindElement(By.CssSelector("[data-test-id='submit-4']"));
            }
        }

        public IWebElement SubmitAnswersButton
        {
            get
            {
                return Driver.FindElement(By.CssSelector("[data-test-id='submit-btn']"));
            }
        }

        public ArrayChallengePageObject(IWebDriver driver = null) : base(driver)
        {
        }

        public override void WaitForPageLoad(By pageIdentifer, int pageLoadSecondsTimeout = 10)
        {
            var arrayChallengePageIdentifier = By.Id("challenge");
            base.WaitForPageLoad(arrayChallengePageIdentifier, pageLoadSecondsTimeout);
        }

        public ArrayChallengePageObject PopulateAnswerForm(AnswerForm answerForm)
        {
            FirstAnswerTextbox.SendKeys(answerForm.FirstAnswer);
            SecondAnswerTextbox.SendKeys(answerForm.SecondAnswer);
            ThirdAnswerTextbox.SendKeys(answerForm.ThirdAnswer);
            NameTextbox.SendKeys(answerForm.Name);
            return this;
        }

        public ArrayChallengePageObject SubmitAnswerForm()
        {
            SubmitAnswersButton.Click();
            return this;
        }

        private int[] ParseRow(int rowIndex, int totalColumns = 9)
        {
            int[] rowValues = new int[totalColumns];

            for (int columnIndex = 0; columnIndex < totalColumns; columnIndex++)
            {
                var columnSelector = By.CssSelector($"[data-test-id='array-item-{rowIndex}-{columnIndex}']");
                string columnText = Driver.FindElement(columnSelector).Text;
                rowValues[columnIndex] = int.Parse(columnText);
            }

            return rowValues;
        }
    }
}
