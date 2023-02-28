using BDD_UI_TestFramework.PageAssembly;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace BDD_UI_TestFramework
{
    [Binding]
    public class ForexConversionsStepDefinitions
    {
        ScenarioContext scenarioContext;
        public ForexConversionsStepDefinitions(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [Given(@"User navigates to currency converter website")]
        public void GivenUserNavigatesToCurrencyConverterWebsite()
        {
            Page.forexConversionPage.NavigateToForexConversionPage();
        }

        [When(@"User able to enter the amount, source and target")]
        public void WhenUserShouldAbleToEnterTheAmountSourceAndTarget()
        {
            Page.forexConversionPage.FillTextBoxAmount("100");
            scenarioContext.Add("amount", "100");
            Page.forexConversionPage.FillddlFromCurrency("US Dollar");
            scenarioContext.Add("fromCurrency", "US Dollar");
            Page.forexConversionPage.FillddlToCurrency("Euro");
            scenarioContext.Add("toCurency", "Euro");
        }

        [Then(@"User clicks on convert button")]
        [When(@"User clicks on convert button")]
        public void WhenUserClicksOnConvertButton()
        {
            Page.forexConversionPage.ClickConvertForex();
        }

        [When(@"Page should display the full conversion amount")]
        [Then(@"Page should display the full conversion amount")]
        public void ThenPageShouldDisplayTheFullConversionAmount()
        {
            scenarioContext.Add("amount1", "100");
            scenarioContext.Add("fromCurrency1", "US Dollar");
            scenarioContext.Add("toCurency1", "Euro");

            Dictionary<String, String> conversionDetails = new Dictionary<string, string>();
            conversionDetails.Add("amount1", scenarioContext.Get<string>("amount1"));
            conversionDetails.Add("fromCurrency1", scenarioContext.Get<string>("fromCurrency1"));
            conversionDetails.Add("toCurency1", scenarioContext.Get<string>("toCurency1"));
            Page.forexConversionPage.VerifyAmountAndConversationRates(conversionDetails);
        }

        [When(@"conversion rate of a single unit for both currencies")]
        [Then(@"conversion rate of a single unit for both currencies")]
        public void ThenConversionRateOfASingleUnitForBothCurrencies()
        {
            scenarioContext.Add("fromCurrencyName", "USD");
            scenarioContext.Add("toCurencyName", "EUR");

            Dictionary<String, String> conversionDetails = new Dictionary<string, string>();
            conversionDetails.Add("fromCurrencyName", scenarioContext.Get<string>("fromCurrencyName"));
            conversionDetails.Add("toCurencyName", scenarioContext.Get<string>("toCurencyName"));
            Page.forexConversionPage.ConversionRateOfASingleUnitForBothCurrencies(conversionDetails);
        }

        [Then(@"Conversion value presented should be mathematically correct")]
        public void ThenConversionValuePresentedShouldBeMathematicallyCorrect()
        {
            Page.forexConversionPage.VerifyAmountMathematicallyCorrect();
        }

        [Then(@"User should able to enter the specify whole integers and decimal numeric (.*)")]
        public void ThenUserShouldAbleToEnterTheSpecifyWholeIntegersAndDecimalNumeric(string amount)
        {
            Page.forexConversionPage.FillTextBoxAmount(amount);
        }

        [Then(@"Convert button should be disabled")]
        public void ThenConvertButtonShouldBeDisabled()
        {
            Page.forexConversionPage.CheckDisabledConvertButton();
        }

        [When(@"User enters the (.*), source and target")]
        public void WhenUserEntersTheSourceAndTarget(string amount)
        {
            Assert.IsTrue(Convert.ToInt32(amount) < 0, "Amount is not negative value");
            Page.forexConversionPage.FillTextBoxAmount(amount);
            Page.forexConversionPage.FillddlFromCurrency("USD");
            Page.forexConversionPage.FillddlToCurrency("EUR");
        }

        [When(@"User enters the abc")]
        public void WhenUserEntersTheAbc()
        {
            Page.forexConversionPage.FillTextBoxAmount("abc");
            Page.forexConversionPage.FillddlFromCurrency("USD");
            Page.forexConversionPage.FillddlToCurrency("EUR");
        }

        [Then(@"Page should display the Error Message for NegativeAmount")]
        public void ThenPageShouldDisplayTheErrorMessageForNegativeAmount()
        {
            string errorMessgae = "Please enter an amount greater than 0";
            Page.forexConversionPage.VerifyErrorMessage(errorMessgae, "NegativeAmount");
        }

        [Then(@"Page should display the Error Message for NonNumericValue")]
        public void ThenPageShouldDisplayTheErrorMessageForNonNumericValue()
        {
            string errorMessgae = "Please enter a valid amount";
            Page.forexConversionPage.VerifyErrorMessage(errorMessgae, "NonNumericValue");
        }

        [Then(@"the page URI should be updated to reflect the amount, source and target currency for the conversion")]
        public void ThenThePageURIShouldBeUpdatedToReflectTheAmountSourceAndTargetCurrencyForTheConversion()
        {
            scenarioContext.Add("amount2", "100");
            scenarioContext.Add("fromCurrency2", "USD");
            scenarioContext.Add("toCurency2", "EUR");

            Dictionary<String, String> conversionDetails = new Dictionary<string, string>();
            conversionDetails.Add("amount2", scenarioContext.Get<string>("amount2"));
            conversionDetails.Add("fromCurrency2", scenarioContext.Get<string>("fromCurrency2"));
            conversionDetails.Add("toCurency2", scenarioContext.Get<string>("toCurency2"));
            Page.forexConversionPage.VerifyCurrencyDetailsInURI(conversionDetails);
        }

        [Given(@"User navigates to currency converter website with url with query string parameters")]
        public void GivenUserNavigatesToCurrencyConverterWebsiteWithUrlWithQueryStringParameters()
        {
            Page.forexConversionPage.NavigateToForexConversionPageWithQueryParameters();
        }

        [When(@"Invert currencies button is clicked")]
        public void WhenInvertCurrenciesButtonIsClicked()
        {
            Page.forexConversionPage.ClickInvertCurrency();
        }

        [Then(@"Page should display the reverse conversions correctly")]
        public void ThenPageShouldDisplayTheRevreseConversionsCorrectly()
        {
            Page.forexConversionPage.VerifyInvertCurrencyDetails();
        }
    }
}
