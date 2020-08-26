//-----------------------------------------------------------------------
// <copyright file="Base.cs" company="BridgeLabz">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using MakeMyTrip.BrowserFactory;
using MakeMyTrip.Email;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Configuration;
using System.Threading;

namespace MakeMyTrip
{
    // <summary>
    /// Initialization of Base classes
    /// </summary>                  
    public class Base
    {
        /// <summary>
        /// Initialization of web driver
        /// </summary>
        public IWebDriver driver;

        /// <summary>
        /// create object of BrowserFactoryMain
        /// </summary>
        BrowserFactoryMain browser = new BrowserFactoryMain();

        /// <summary>
        /// create instance of Extent report
        /// </summary>
        public static ExtentReports extent = ReportExtent.GetExtentReport();
        public static ExtentTest test;

        /// <summary>
        /// create instance of Log4net
        /// </summary>
        public static readonly log4net.ILog log =
        log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
         
        /// <summary>
        /// create one time setup
        /// </summary>
        [OneTimeSetUp]
        [Obsolete]
        public void Initilize()
        {
            driver = browser.InitBrowser("chrome"); 
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Window.Maximize();
            driver.Url = ConfigurationManager.AppSettings["URL"];
        }
        /// <summary>
        /// create One time tear down
        /// </summary>
        [OneTimeTearDown]
        public void Close()
        {
            Thread.Sleep(2000);
            driver.Quit();
        }

        /// <summary>
        /// create setup and check internet is connected or not
        /// </summary>
        [SetUp]
        public void StartingLog()
        {
            log.Info(TestContext.CurrentContext.Test.Name + "Started");
            try
            {
                CheckInternetConnection connection = new CheckInternetConnection();
                Console.WriteLine("Internet connection ---->" + connection.IsConnectedToInternet());
            }
            catch(BrowserFactoryException)
            {
                throw new BrowserFactoryException("Internet is not available", BrowserFactoryException.ExceptionType.INTERNET_NOT_AVAILABLE);
            }
        }

        /// <summary>
        /// Take screenshot,send mail and generate extent report
        /// </summary>
        [TearDown]
        public void ExtentFlush()
        {
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                var error = TestContext.CurrentContext.Result.Message;
                if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
                {
                    log.Error(TestContext.CurrentContext.Test.Name + "Failed");
                    test.Log(Status.Info, error);
                    string path = Screenshot.Capture(driver, TestContext.CurrentContext.Test.Name + "   " + "Failed");
                    test.AddScreenCaptureFromPath(path);
                    test.Fail(MarkupHelper.CreateLabel(TestContext.CurrentContext.Test.Name, ExtentColor.Red));
                    test.Log(Status.Fail, "Test Failed");
                    log.Error("Test Failed");
                    SendEmailMain.SendEmail(error, TestContext.CurrentContext.Result.StackTrace);
                }
                else if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed)
                {
                    log.Info(TestContext.CurrentContext.Test.Name + "Passed");
                    test.Pass(MarkupHelper.CreateLabel(TestContext.CurrentContext.Test.Name, ExtentColor.Green));
                    test.Log(Status.Pass, "Test pass");
                    log.Info(TestContext.CurrentContext.Test.Name + "Test Completed");
                }
                extent.Flush();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
