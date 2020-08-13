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
    public class Base
    {
        public IWebDriver driver;

        //create Instance of Browser Factory
        BrowserFactoryMain browser = new BrowserFactoryMain();

        //create Instance of Extent Report
        public static ExtentReports extent = ReportExtent.GetExtentReport();
        public static ExtentTest test;

        //craete instance of Log4net
        public static readonly log4net.ILog log =
        log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        [OneTimeSetUp]
        public void Initilize()
        {

            driver = browser.InitBrowser("chrome"); //Initialize chrome driver

            //Using implicitly wait 
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            //Maximizing the window
            driver.Manage().Window.Maximize();

            //Enter the url
            driver.Url = ConfigurationManager.AppSettings["URL"];
        }
        [OneTimeTearDown]
        public void Close()
        {
            Thread.Sleep(2000);

            driver.Quit();
        }

        [SetUp]
        public void StartingLog()
        {
            log.Info(TestContext.CurrentContext.Test.Name + "Started");
            //checking the internet connection 
            try
            {
                CheckInternetConnection connection = new CheckInternetConnection();
                Console.WriteLine("Internet connection ---->" + connection.IsConnectedToInternet());
            }
            catch(BrowserFactoryException exception)
            {
                throw new BrowserFactoryException("Internet is not available", BrowserFactoryException.ExceptionType.INTERNET_NOT_AVAILABLE);
            }
        }

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
             // driver.Navigate().Refresh(); // every test must refresh the webpage ..use in negative test
                extent.Flush();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
