using BDD_UI_TestFramework.Browser;
using BDD_UI_TestFramework.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD_UI_TestFramework.PageAssembly
{
    /// <summary>
    /// Any New page will be added in this class to intialize it 
    /// </summary>
    public class Page
    {
        [ThreadStatic]
        public static ForexConversionPage forexConversionPage;

        public static void InitPages()
        {
            forexConversionPage = new ForexConversionPage();
        }

    }
}

