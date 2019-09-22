## What we are trying to do ?
The Unit test is a block of code that help us in verifying the expected behaviour of the other code in isolation i.e. there is no dependency between the tests. This is good way to test the application code before it goes for quality assurance (QA). There are three different test frameworks for Unit Testing supported by ASP.NET Core: MSTest, xUnit, and NUnit. All Unit test frameworks, offer a similar end goal and help us to write unit tests that are simpler, easier and faster.

## And how do you do it
let's go run the tests and see what happens:

    $ dotnet test
    Build started, please wait...
    Build completed.

    Test run for C:\src\MyFirstUnitTests\bin\Debug\netcoreapp2.1\MyFirstUnitTests.dll(.NETCoreApp,Version=v2.1)
    Microsoft (R) Test Execution Command Line Tool Version 15.7.0
    Copyright (c) Microsoft Corporation.  All rights reserved.

    Starting test execution, please wait...
    [xUnit.net 00:00:01.8833990]     MyFirstUnitTests.Class1.FailingTest [FAIL]
    Failed   MyFirstUnitTests.Class1.FailingTest
    Error Message:
     Assert.Equal() Failure
    Expected: 5
    Actual:   4
    Stack Trace:
       at MyFirstUnitTests.Class1.FailingTest() in C:\src\MyFirstUnitTests\Class1.cs:line 16

    Total tests: 2. Passed: 1. Failed: 1. Skipped: 0.
    Test Run Failed.
    Test execution time: 3.9954 Seconds

## Write your first theory
 You may have wondered why your first unit tests use an attribute named [Fact] rather than one with a more traditional name like Test. xUnit.net includes support for two different major types of unit tests: facts and theories. When describing the difference between facts and theories, we like to say:
 * <b>Facts</b> are tests which are always true. They test invariant conditions.
 * <b>Theories</b> are tests which are only true for a particular set of data.

## Running tests with Visual Studio
Make sure Test Explorer is visible (go to Test > Windows > Test Explorer). Depending on the version of Visual Studio you have, you may need to build your test assembly before tests are discovered. After a moment of discovery, you should see the list of discovered tests, then Click the Run All link in the Test Explorer window, and you should see the results update in the Test Explorer window as the tests are run.


![sc1](https://user-images.githubusercontent.com/24621701/44303735-80dcf980-a340-11e8-8917-941b0b46d970.png)

