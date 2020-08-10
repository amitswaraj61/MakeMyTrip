using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Net;

namespace MakeMyTrip
{
  public class ReportExtent
    {
        public static ExtentReports extent;
        public static ExtentTest test;
        public static ExtentReports GetExtentReport()
        {

            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\Kis\source\repos\MakeMyTrip\MakeMyTrip\Report\index.html");
            extent.AttachReporter(htmlReporter);
            String hostname = Dns.GetHostName();
            OperatingSystem os = Environment.OSVersion;
            extent.AddSystemInfo("operating system", hostname);
            extent.AddSystemInfo("Host name", hostname);
            extent.AddSystemInfo("Browser", "Google Chrome");

            return extent;
        }
    }
}
