# ECSTest E2E

This is my implementation of the E2E tests for the [ECS Digital QA Tech Test](https://github.com/ecsdigital/qa-tech-test).
The test framework uses a typical page object pattern and is written in C# using [XUnit](https://xunit.net/) and dotnet core.

## Running the Test

First make sure the application is running as noted in the test README.md file. From the root of the project this can
be done with docker:

```bash
docker build -t ecsd-tech-test .
docker run -it -p 3000:3000 ecsd-tech-test:latest
```

### Via the dotnet command

To run the tests via the dotnet command:

```
dotnet restore
dotnet build
dotnet test
```

The test will then start in the command line.

### Via Visual Studio

* Open the solution file with Visual Studio.
* Build the solution.
* Run the test in `.\Tests\ArrayTest.cs` using Test Explorer.

## Design Decisions

### Fluent API

The framework makes use of a fluent API style this is supported by the BasePageObject _Get_ method on line 44.
Having this get method allows me to get PageObjects without interrupting my call chain and adds some readability to my
code instead of having a BDD framework in place (see below).

You can read a bit more about how it works on this [Stackoverflow Answer](https://stackoverflow.com/a/731637)

### BDD

I decided not to use BDD for two main reasons.

#### The Context of the Task

The task as given doesn't contain a major element of user interaction or stories. It is much more focused around
testing knowledge of Selenium, Software Development and Problem Solving. So, instead of presenting a list of user
stories to test the task instead asks the candidate to use Selenium to enable them to complete an algorithm style task.

So given this context, I decided that a BDD framework such as Specflow would introduce complexity with little benefit.

#### Avoiding Complexity

More generally I try to work as simply as possible and only adding extra complexity when required. In this task, the trade-off did not seem in favour of BDD. BDD frameworks can without proper attention become difficult to manage as abstraction
struggles to manage the task of providing readable spec or feature files v.s. having an easy to understand codebase.

While this is possible to manage I prefer to understand the project context and ways of working case first before 
recommending it.

I have written a little bit about this tradeoff before on my blog
[QA Interview Tip - Everything is Not Awesome](https://tomdriven.dev/interviewing/2020/02/12/interview-you-dont-like-everything.html)

### Adding extra data-test-id attributes to the application

While not strictly needed to complete the test I added some extra test-id data attributes to the application src code.
This made the application easier to test as rather than writing more complex CSS selectors I was able to use simpler
ones while maintaining consistency with the rest of my test framework.

In a client situation, I would be happy to add these extra test hooks to application code to make it easier to test.
But I would also look to pair with the developers within the team and use that pairing as an opportunity to ensure
testability of the source code had been considered and any attributes like this needed had been added.

#### Adding ArrayChallenge Logic as a Private Method in the ArrayTest Class

The task requires the candidate to solve an algorithm style question to find the index of the array where the elements to the
left or right of that index equal each other. This logic in a more typical application would probably exist in its own class
rather than the ArrayTest class as I have done here for clarity. Some examples of Unit Test cases that could be covered:

* A array with > 2 items where the left and right sums match and return the correct index.
* A array with > 2 items where the left and right sums don't match and return null.
* A array with <= 2 items where null is returned.
* A null array which causes null to be returned.

As noted in my code comment the last two cases could also be changed to throw an _ArgumentException_ rather than return null
but that is a programing style question which would be best left to the team.
