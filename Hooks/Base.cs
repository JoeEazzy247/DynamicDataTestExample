using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace ClassLibrary1.Hooks
{
    [Binding]
    public  class Base
    {
        public static IWebDriver driver { get; set; }
        public static ExtentReports extent = new ExtentReports();
        public static ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(
            @"C:\Users\joseph.ekeleme\source\repos\ClassLibrary1\report\repo.html");
        
        /*private static ExtentTest FeatureName;
        private static ExtentTest Scenerio;
        private static ExtentReports extent;*/

        /*[BeforeTestRun]
        public static void initialiseReport()
        {
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\joseph.ekeleme\source\repos\ClassLibrary1\report\extentreport.html");
            htmlReporter.Configuration().Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }*/
/*
        [AfterTestRun]
        public static void TearDownReport()
        {
            extent.Flush();
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            FeatureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
 
        }

        [AfterStep]
        public void InsertReportingsteps()
        {
            var steptype = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            if (ScenarioContext.Current.TestError==null)
            {
            if (steptype=="Given")
                 Scenerio.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if (steptype=="When")
                    Scenerio.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (steptype=="Then")
                    Scenerio.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                else if (steptype == "And")
                    Scenerio.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
            }
            else if (ScenarioContext.Current.TestError != null)
            {
                if (steptype == "Given")
                    Scenerio.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                else if (steptype == "When")
                    Scenerio.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                else if (steptype == "Then")
                    Scenerio.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                else if (steptype == "And")
                    Scenerio.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
            }

        }
*/

        [BeforeFeature]
        public static void setupReport()
        {
            extent.AttachReporter(htmlReporter);
        }
        [BeforeScenario]
        public void BeforeScenario()
        {
            driver = new ChromeDriver();
            //Scenerio = FeatureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);

        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        
        }
        [AfterTestRun]
        public static void flushReport()
        {
            extent.Flush();
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
    }
}
