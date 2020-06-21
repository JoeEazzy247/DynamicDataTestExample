using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using OpenQA.Selenium;

namespace Hooks.Report
{
    public class ExtentReport
    {
        public static ExtentReports exRepDrv;
        //private ExtentReports extent;
        //ExtentReports report;
        ExtentHtmlReporter htmlReporter;
        private static ExtentTest test;


        public object logstatus { get; set; }

        public void setupExtentreport(string reportName, string documenttile)
        {
           /* string currentTime = DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss");
            string path = System.Reflection.Assembly.GetEntryAssembly().CodeBase;
            string actualpath = path.Substring(0, path.LastIndexOf("bin"));
            string projectpath = new Uri(actualpath).LocalPath;

            htmlReporter = new ExtentHtmlReporter(projectpath);*/
            //or
            htmlReporter = new ExtentHtmlReporter(@"C:\Users\joseph.ekeleme\source\repos\ClassLibrary1\report\rp.html");
            htmlReporter.Configuration().Theme = Theme.Dark;
            htmlReporter.Configuration().DocumentTitle = documenttile;
            htmlReporter.Configuration().ReportName = reportName;

            var extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            exRepDrv = extent;

        }

        public static string capture(IWebDriver driver, string screenshotname)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string path2 = path.Substring(0, path.LastIndexOf("bin")) + "\\report\\Screenshot\\" + screenshotname + ".png";
            string locapath = new Uri(path2).LocalPath;
            screenshot.SaveAsFile(locapath, ScreenshotImageFormat.Png);
            return locapath;
        
        }

        public void createTest(string testName)
        {
            test = exRepDrv.CreateTest(testName);
        }

        public void LogReportStatements(Status status, string message, string screenshots)
        {
            test.Log(status, message);
            test.AddScreenCaptureFromPath(screenshots);
        }

        public void LogReportStatements(Status status, string message)
        {
            test.Log(status, message);
         
        }

        public void flushReport()
        {
            exRepDrv.Flush();
        }

    }
}