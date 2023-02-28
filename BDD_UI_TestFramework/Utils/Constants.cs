using System;
using System.Collections.Generic;
using System.Text;

namespace BDD_UI_TestFramework.Browser
{
    public static partial class Constants
    {
        /// <summary>
        /// The default amount of time to wait for an operation to complete by the Selenium driver.
        /// </summary>
        public static readonly TimeSpan DefaultTimeout = new TimeSpan(0, 0, 40);

        public const int DefaultRetryDelay = 5000;

        /// <summary>
        /// The default number of retry attempts for a command execution if it fails.
        /// </summary>
        public const int DefaultRetryAttempts = 2;

        /// <summary>
        /// The default tracing source for browser automation.
        /// </summary>
        public const string DefaultTraceSource = "BrowserAutomation";

        /// <summary>
        /// The default tracing source for browser automation.
        /// </summary>
        public const int DefaultThinkTime = 2000;

    }
}
