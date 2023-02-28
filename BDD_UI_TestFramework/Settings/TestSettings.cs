using BDD_UI_TestFramework.Browser;
using BDD_UI_TestFramework.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD_UI_TestFramework.Settings
{
    public static class TestSettings
    {

        private static readonly string Type = "Chrome";
        private static readonly string RemoteType = "Chrome";
        private static readonly string RemoteHubServerURL = "https://www.xe.com/currencyconverter/";
        private static readonly string browserstack_user = "browserstackUser";
        private static readonly string browserstack_Key = "browserstackkey";
        // Create a new options instance, copy of the share, to use just in the current test, modifications in test will not affect other tests
        public static BrowserOptions Options => new BrowserOptions
        {
            BrowserType = (BrowserType)Enum.Parse(typeof(BrowserType), Type),
            PrivateMode = false,
            FireEvents = false,
            Headless = false,
            UserAgent = false,
            DefaultThinkTime = 2000,
            UCITestMode = true,
            UCIPerformanceMode = true,
            DisableExtensions = true,
            DisableFeatures = false,
            DisablePopupBlocking = true,
            DisableSettingsWindow = true,
            EnableJavascript = false,
            NoSandbox = false,
            DisableGpu = false,
            DumpDom = false,
            EnableAutomation = false,
            DisableImplSidePainting = false,
            DisableDevShmUsage = false,
            DisableInfoBars = false,
            TestTypeBrowser = false,
            RemoteHubServer = new Uri(RemoteHubServerURL),
            browserstackkey = browserstack_Key,
            Browserstackuser = browserstack_user,
            Os = "Windows",
            Os_version = "10",
            Browser_version = "85.0",
            RemoteBrowserType = (BrowserType)Enum.Parse(typeof(BrowserType), RemoteType),
            Width = 969,
            Height = 1903,
            StartMaximized = false,
            EnableCosoleLogging = true,
            DisableNotification = true,
            Enviornment = "staging",
            ExecutionMode="api"
        };
    }
}
