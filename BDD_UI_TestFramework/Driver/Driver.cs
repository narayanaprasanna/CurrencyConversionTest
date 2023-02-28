using BDD_UI_TestFramework.Utils.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Events;
using System;

namespace BDD_UI_TestFramework.Browser
{
    public static class Driver
    {
        [ThreadStatic]
        public static IWebDriver driver;
        /// <summary>
        /// This method will a launch a browser with option that you can set in testsetting file in your test project
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public static void CreateWebDriver(BrowserOptions options)
        {
            switch (options.BrowserType)
            {
                case BrowserType.Chrome:
                    var chromeService = ChromeDriverService.CreateDefaultService();
                    chromeService.HideCommandPromptWindow = options.HideDiagnosticWindow;
                    driver = new ChromeDriver(chromeService, options.ToChrome(), TimeSpan.FromMinutes(5));
                    driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 15);
                    driver.Manage().Window.Maximize();
                    break;
                case BrowserType.IE:
                    var ieService = InternetExplorerDriverService.CreateDefaultService(options.DriversPath);
                    ieService.SuppressInitialDiagnosticInformation = options.HideDiagnosticWindow;
                    driver = new InternetExplorerDriver(ieService, options.ToInternetExplorer(), TimeSpan.FromMinutes(20));
                    driver.Manage().Window.Maximize();
                    break;
                case BrowserType.Firefox:
                    var ffService = FirefoxDriverService.CreateDefaultService();
                    ffService.HideCommandPromptWindow = options.HideDiagnosticWindow;
                    driver = new FirefoxDriver(ffService, options.ToFireFox(), TimeSpan.FromMinutes(3));
                    driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 5);
                    driver.Manage().Window.Maximize();
                    break;
                case BrowserType.Edge:
                    var edgeService = EdgeDriverService.CreateDefaultService(options.DriversPath);
                    edgeService.HideCommandPromptWindow = options.HideDiagnosticWindow;
                    driver = new EdgeDriver(edgeService, options.ToEdge(), TimeSpan.FromMinutes(20));
                    driver.Manage().Window.Maximize();
                    break;
                case BrowserType.Remote:
                    ICapabilities capabilities = null;
                    ChromeOptions option = new ChromeOptions();
                    switch (options.RemoteBrowserType)
                    {
                        case BrowserType.Chrome:

                            option.AddAdditionalCapability("os", options.Os.ToString(), true);
                            option.AddAdditionalCapability("os_version", options.Os_version.ToString(), true);
                            option.AddAdditionalCapability("browser_version", options.Browser_version.ToString(), true);
                            option.AddAdditionalCapability("browserstack.user", options.Browserstackuser.ToString(), true);
                            option.AddAdditionalCapability("browserstack.key", options.browserstackkey.ToString(), true);
                            option.AddAdditionalCapability("name", "FirstTest", true);
                            option.AddAdditionalCapability("browser", options.RemoteBrowserType.ToString(), true);
                            capabilities = option.ToCapabilities();
                            break;
                        case BrowserType.Firefox:
                            capabilities = options.ToFireFox().ToCapabilities();
                            break;
                    }
                    driver = new RemoteWebDriver(options.RemoteHubServer, option);
                    break;
                default:
                    throw new InvalidOperationException(
                        $"The browser type '{options.BrowserType}' is not recognized.");
            }

            driver.Manage().Timeouts().PageLoad = options.PageLoadTimeout;

            // StartMaximized overrides a set width & height
            if (options.StartMaximized && options.BrowserType != BrowserType.Chrome) //Handle Chrome in the Browser Options
                driver.Manage().Window.Maximize();

            if (options.FireEvents || options.EnableRecording)
            {
                // Wrap the newly created driver.
                driver = new EventFiringWebDriver(driver);
            }
        }
        public static IWebDriver Current => driver ?? throw new NullReferenceException("_driver is null");
    }
}
