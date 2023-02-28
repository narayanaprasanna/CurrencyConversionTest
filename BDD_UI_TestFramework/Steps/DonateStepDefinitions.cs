using BDD_UI_TestFramework.Browser;
using BDD_UI_TestFramework.PageAssembly;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace BDD_UI_TestFramework
{
    [Binding]
    public class DonateStepDefinitions
    {
        [Given(@"user is on uk version of site savethechildren")]
        public void GivenUserIsOnUkVersionOfSiteSavethechildren()
        {
            //Page.homePage.NavigateToForexConversionPage();
        }

        [When(@"user search with keyword ""([^""]*)""")]
        public void WhenUserSearchWithKeyword(string keyWord)
        {
            //Page.homePage.Search(keyWord);
        }

        [When(@"select the first link of search search result")]
        public void WhenSelectTheFirstLinkOfSearchSearchResult()
        {
            //Page.homePage.SelectFirstResult();
        }

        [Then(@"user is navigated to donation page")]
        public void ThenUserIsNavigatedToDonationPage()
        {
            Assert.IsTrue(Driver.Current.Url.Contains("donate"), "Unable to Navigate to donate page");
        }
    }
}
