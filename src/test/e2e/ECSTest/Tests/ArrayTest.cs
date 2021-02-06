using ECSTest.PageObjects;
using ECSTest.Tests;
using System.Linq;
using Xunit;

namespace ECSTest
{
    public class ArrayTest : BaseTest
    {
        [Fact]
        public void ArrayChallenge()
        {
            BasePageObject.Get<HomePageObject>()
                .RenderChallengeButtonElement
                .Click();

            int[] firstRowValues = BasePageObject.Get<ArrayChallengePageObject>()
                .FirstRowValues;

            int[] secondRowValues = BasePageObject.Get<ArrayChallengePageObject>()
                .SecondRowValues;

            int[] thirdRowValues = BasePageObject.Get<ArrayChallengePageObject>()
                .ThirdRowValues;

            int? firstRowAnswer = ArrayIndexWhereLeftEqualsRight(firstRowValues);
            int? secondRowAnswer = ArrayIndexWhereLeftEqualsRight(secondRowValues);
            int? thirdRowAnswer = ArrayIndexWhereLeftEqualsRight(thirdRowValues);

            BasePageObject.Get<ArrayChallengePageObject>()
                .PopulateAnswerForm(new DTOs.AnswerForm
                {
                    FirstAnswer = firstRowAnswer.ToString(),
                    SecondAnswer = secondRowAnswer.ToString(),
                    ThirdAnswer = thirdRowAnswer.ToString(),
                    Name = "Thomas Shipley"
                })
                .SubmitAnswerForm()
                .Get<DialogPageObject>()
                .WaitForSuccessMessage()
                .CloseButtonElement
                .Click();
        }

        private int? ArrayIndexWhereLeftEqualsRight(int[] array)
        {
            // Depending on project context and use of exceptions / exception handling
            // could also return an ArgumentException in this case.
            if (array == null || array.Length <= 2)
            {
                // No need to do comparison - save effort
                return null;
            }

            int? indexToReturn = null;

            // Skip first and last middle indexes as nothing exists to left or right
            // respectively to compare to.
            for (int middleIndex = 1; middleIndex < array.Length - 1; middleIndex++)
            {
                int leftTotal = array.Take(middleIndex).ToArray().Sum();
                int rightTotal = array.Skip(middleIndex + 1).ToArray().Sum();
                int middleValue = array[middleIndex];

                if(leftTotal == rightTotal)
                {
                    indexToReturn = middleIndex;
                    break;
                }
            }

            return indexToReturn;
        }

    }
}
