# CurrencyConversionTest
Hi Team,

Thank you for giving this opportunity to complete the test. 
I am really enjoyed and completed the test in normal way and which might be required some more effort to make the application in a way dynamic, robust, reusable.

The following Areas can be improved if given more time
1) Assertions
2) Better way to write scenarios in Feature file
3) Passing Multiple examples for each scenario 
4) Test Data from the CSV file
5) Reports
6) Screenshots of each step after and save in the specific folder.
7) Devops pipeline set up


InOrder to run the Tests, please follow the instruction bottom of this file.

Acceptance Criteria
1)User should be able to specify numeric amount, source and target currency, and obtain conversion amount.

 COMPLETED

2)Users should be able to specify whole integers and decimal numeric amounts.

COMPLETED

3)Whenever system provides conversion results, it should display the full conversion amount for the value specified as well as the conversion rate of a single unit for both currencies.

COMPLETED

4)The conversion values presented for the amount specified (e.g. 10 USD = 8.90909 EUR) and the 1 unit values should be mathematically correct. i.e. if 1 USD = 0.890909 EUR, then 10 USD should equate to 8.90909 EUR.

COMPLETED

5)The source and target currency dropdowns should list the most popular currencies at the top of the dropdown, and then list all other currencies in alphabetical order.
# Scenario 5: XE the current source and target dropdowns are not sorted as you stated so this cannot be validated.

6)If users specify negative numeric values, an error message should be displayed but conversion happens anyway.

COMPLETED
# Scenario 6: Validated the Negative numeric values but If user enters the negative numeric values then convert button is disabled. Requirement need to be updated.

7)If users specify non numeric values, the system should give an error.

COMPLETED

8)User should be able to swap source and target currencies by clicking the ‘Invert Currencies’ button. Once the button is clicked on, the conversion is made.

COMPLETED

9)Whenever user performs a conversion (or reverses it), the page URI should be updated to reflect the amount, source and target currency for the conversion.

COMPLETED

10)Users should be able to access a conversion page directly by specifying the right query string parameters.

COMPLETED

The following versions are currenctly using to implement this application:

All versions are availble in the packages.config file

1)sula Studio - version : 17+
2).NET Framework - version : 4.8 
3)Need to follow the instructions to install and set up the SpecFlow, SpecFlow.NUnit, and SpecFlow.Tools.MsBuild.Generation, Gherkin, Selenium, Selenium Support, Selenium WebDriver Chromedriver.
https://www.lambdatest.com/blog/specflow-tutorial-for-automation-testing/
4)Once the set is completed and then go to Visual studio  -> Test -> Test Explore, then All tests are availble to run them.
5) Right click on ForexConversions tag tests and run all 11 tests.
![image](https://user-images.githubusercontent.com/126391657/221844046-0a4efe9d-f519-49e2-b0b3-8f63251565f9.png)
6) Tests reports
![image](https://user-images.githubusercontent.com/126391657/221845101-7fe53a0e-409e-4a1c-9069-7de11451d493.png)







