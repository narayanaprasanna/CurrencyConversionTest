using BDD_UI_TestFramework.Utils.Extensions;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using TechTalk.SpecFlow;

namespace BDD_UI_TestFramework.Pages
{
    public class ForexConversionPage : BasePage
    {
        #region Locators
        readonly By btnAccept = By.CssSelector("button.haqezJ");
        readonly By txtBoxAmount = By.CssSelector("input.eIuRdk");
        readonly By ddlFromCurrency = By.Id("midmarketFromCurrency");
        readonly By ddlToCurrency = By.Id("midmarketToCurrency");
        readonly By btnConvert = By.XPath("//button[text()='Convert']");
        readonly By btnInvert = By.ClassName("dYwyct");
        readonly By btnClsoeIcon = By.ClassName("yie-outer-element");
        readonly By lblConversion1 = By.ClassName("gwvOOF");
        readonly By lblConversion2 = By.ClassName("iGrAod");
        readonly By lblConversion3 = By.CssSelector("div[class*='unit-rates'] p:nth-child(1)");
        readonly By lblConversion4 = By.CssSelector("div[class*='unit-rates'] p:nth-child(2)");
        readonly By negativeAmountErrorMessage = By.ClassName("dkXbBF");
        #endregion

        #region PageActions
        public ForexConversionPage NavigateToForexConversionPage()
        {
            GoTo("/");
            Find(btnAccept).ElementClick();
            PopupClick(btnClsoeIcon); 
            return this;
        }

        public ForexConversionPage FillTextBoxAmount(String searchKeyWords)
        {
            Type(searchKeyWords, txtBoxAmount);
            return this;
        }
        public void CheckDisabledConvertButton()
        {
            Assert.IsFalse(Find(btnConvert).Enabled);
        }

        public ForexConversionPage FillddlFromCurrency(String currency)
        {
            Type(currency + Environment.NewLine, ddlFromCurrency);
            return this;
        }

        public ForexConversionPage FillddlToCurrency(String currency)
        {
            Type(currency + Environment.NewLine, ddlToCurrency);
            return this;
        }

        internal void VerifyAmountAndConversationRates(Dictionary<String, String> details)
        {
            Thread.Sleep(3000);
            Assert.True(GetText(lblConversion1).Contains(details["amount1"]));
            Assert.True(GetText(lblConversion1).Contains(details["fromCurrency1"]));
            Assert.True(GetText(lblConversion2).Contains(details["toCurency1"]));
        }

        public void VerifyInvertCurrencyDetails()
        {
            Thread.Sleep(3000);
            Assert.True(GetText(lblConversion1).Contains("100.00 Euros"));
            Assert.True(GetText(lblConversion2).Contains("US Dollars"));
        }

        internal void ConversionRateOfASingleUnitForBothCurrencies(Dictionary<String, String> details)
        {
            Thread.Sleep(3000);
            Assert.True(GetText(lblConversion3).Contains(details["fromCurrencyName"]));
            Assert.True(GetText(lblConversion4).Contains(details["toCurencyName"]));
        }
        internal void VerifyAmountMathematicallyCorrect()
        {
            Thread.Sleep(3000);
            string amount1 = GetText(lblConversion2).Split(' ')[0];
            double convertedAmount = Convert.ToDouble(amount1) / 100;
            double expectedAmount = Math.Round(convertedAmount, 6);
            Assert.True(GetText(lblConversion3).Contains(expectedAmount.ToString()));
        }

        public ForexConversionPage ClickConvertForex()
        {
            Thread.Sleep(2000);
            Click(btnConvert);
            Thread.Sleep(2000);
            return this;
        }

        public ForexConversionPage ClickInvertCurrency()
        {
            Thread.Sleep(2000);
            Click(btnInvert);
            Thread.Sleep(2000);
            return this;
        }

        public void VerifyCurrencyDetailsInURI(Dictionary<String, String> details)
        {
            VerifyCurrencyDetails(details);
        }

        public void VerifyErrorMessage(string errorMessage, string errorMessgaeType)
        {
            switch (errorMessgaeType)
            {
                case "NegativeAmount":
                    Assert.AreEqual(errorMessage, GetText(negativeAmountErrorMessage), "Expected Error Message is not correct");
                    break;
                case "NonNumericValue":
                    Assert.AreEqual(errorMessage, GetText(negativeAmountErrorMessage), "Expected Error Message is not correct");
                    break;
            }
        }
        public void NavigateToForexConversionPageWithQueryParameters()
        {
            string queryUrl = "https://www.xe.com/currencyconverter/convert/?Amount=100&From=USD&To=EUR";
            NavigateToForexConversionPageWithQueryParameters(queryUrl);
            Thread.Sleep(2000);
        }

        public void PopupClick(By btnClsoeIcon)
        {
            bool isclickable = true;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (isclickable && stopwatch.Elapsed.Seconds < 20)
            {
                try
                {
                    ExecuteJavaScript("arguments[0].parentNode.removeChild(arguments[0])", Find(btnClsoeIcon));
                    isclickable = false;
                    stopwatch.Stop();
                    break;
                }
                catch (Exception ex)
                {
                    isclickable = true;
                    Console.WriteLine("Click Log" + ex);
                }
            }
        }
        #endregion
    }
}
