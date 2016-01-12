using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestProject1.Utils;

namespace UnitTestProject1.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeScenario]
        public void BeforeScenario()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability(CapabilityType.BrowserName, "firefox");
            capabilities.SetCapability(CapabilityType.Version, "43.0");
            capabilities.SetCapability(CapabilityType.Platform, "OS X 10.10");
            capabilities.SetCapability("username", Environment.GetEnvironmentVariable("SAUCE_USERNAME"));
            capabilities.SetCapability("accessKey", Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY"));
            capabilities.SetCapability("name", ScenarioContext.Current.ScenarioInfo.Title);

            CustomRemoteWebDriver webDriver = new CustomRemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"), capabilities, TimeSpan.FromSeconds(600));
            webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
            webDriver.Manage().Cookies.DeleteAllCookies();
            ScenarioContext.Current["driver"] = webDriver;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            IWebDriver driver = (IWebDriver)ScenarioContext.Current["driver"];
            bool passed = ScenarioContext.Current.TestError == null;
            //bool passed = true;
            ((IJavaScriptExecutor)driver).ExecuteScript("sauce:job-result=" + (passed ? "passed" : "failed"));
            driver.Quit();
        }
    }
}
