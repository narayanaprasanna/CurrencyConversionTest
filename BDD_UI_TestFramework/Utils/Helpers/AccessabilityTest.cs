using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using System.IO;
using System.Reflection;
using Selenium.Axe;

namespace BDD_UI_TestFramework.Utils.Configurations
{
    public static class AccessabilityTest
    {
        /// <summary>
        /// This method will perform the acceabilty test of the 
        /// web page and generate the report you need to pass the page name for reportinga nd current driver instance to perform accessability tests
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static AxeResult AnalyzePage(IWebDriver driver,string PageName)
        {
            var result = new AxeBuilder(driver).WithTags("wcag21aa", "wcag2aa").Analyze();
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            outPutDirectory = outPutDirectory.Substring(0, outPutDirectory.IndexOf("bin"));
            outPutDirectory = outPutDirectory.Substring(outPutDirectory.IndexOf("\\") + 1);
            String path = Path.Combine(outPutDirectory, "Reports\\AccessabiltyReport\\" + PageName + "-AxeReport.html");
            driver.CreateAxeHtmlReport(result, path);
            return result;
        }

    }
}
