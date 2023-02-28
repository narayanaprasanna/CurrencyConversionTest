using BDD_UI_TestFramework.Browser;
using BDD_UI_TestFramework.Settings;
using HIS_UITests.Support.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;

namespace BDD_UI_TestFramework.Pages
{
    public class BasePage
    {
        /// <summary>
        /// Click the Element and wait until the element is not clickable
        /// </summary>
        /// <param name="locator"></param>
        protected void Click(By locator)
        {
            Driver.Current.WaitUntilClickable(locator, TimeSpan.FromSeconds(20), "Element is not clickable");
            Find(locator).Click();
        }

        protected IWebElement Find(By locator)
        {
            Driver.Current.WaitUntilAvailable(locator);
            return Driver.Current.FindElement(locator);
        }

        protected void GoTo(String path)
        {
            Driver.Current.Navigate().GoToUrl(ConfigurationManager.AppSettings[TestSettings.Options.Enviornment] + path);
        }

        /// <summary>
        /// clear and Sendkeys to the textboxes and wait until the element is not available
        /// </summary>
        /// <param name="inputText"></param>
        /// <param name="locator"></param>
        protected void Type(String inputText, By locator)
        {
            Thread.Sleep(1000);
            Find(locator).Clear();
            Find(locator).SendKeys(inputText);
        }
        protected List<IWebElement> GetList(By by)
        {
            return Driver.Current.FindElements(by).ToList();
        }

        protected string GetText(By by)
        {
            return Driver.Current.FindElement(by).Text;
        }
        protected void NavigateToForexConversionPageWithQueryParameters(string queryUrl)
        {
            Driver.Current.Navigate().GoToUrl(queryUrl);
        }
        protected void VerifyCurrencyDetails(Dictionary<String, String> detail)
        {
            string url = Driver.Current.Url;
            if (string.IsNullOrEmpty(url))
            {
                Assert.IsTrue(url.Contains(detail["amount2"]));
                Assert.IsTrue(url.Contains(detail["fromCurrency2"]));
                Assert.IsTrue(url.Contains(detail["toCurency2"]));
            }
        }

        protected void ExecuteJavaScript(String script)
        {
            Driver.Current.ExecuteScript(script);
        }

        protected void ExecuteJavaScript(String script, IWebElement element)
        {
            Driver.Current.ExecuteScript(script, element);
        }
    }
}
