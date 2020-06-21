using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using ClassLibrary1.Utils;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Hooks.Report;
using OpenQA.Selenium;
using ClassLibrary1.Hooks;

namespace ClassLibrary1.Steps
{
    [Binding]
    public class RegisterPageSteps
    {
        LoginPage lgpage = new LoginPage();
        ExtentReport rp = new ExtentReport();

        [Given(@"I navigate to url")]
        public void GivenINavigateToUrl(Table table)
        {         
            rp.setupExtentreport("Selenium Framework", "Login Test");
            rp.createTest("Verify Test");
            var website = table.CreateInstance<Details>();
            string url = website.url;
            lgpage.website(url);
            string screenshotpath = ExtentReport.capture(Base.driver, "BrowserLunch");
            rp.LogReportStatements(Status.Info, "Opened ChromeBrowser", screenshotpath);
        }

        [Given(@"I enter (.*) and (.*)")]
        public void GivenIEnterAnd(string email, string password)
        {
            lgpage.emailAndpassword(email, password);
            string screenshotpath2 = ExtentReport.capture(Base.driver, "emailandpassword");
            rp.LogReportStatements(Status.Info, "Entered email and password", screenshotpath2);
           
        }


        /*[Given(@"I navigate to ""(.*)""")]
        public void GivenINavigateTo(string url)
        {

            lgpage.website(url);
        }*/
        /*
        [Given(@"I enter email")]
        public void GivenIEnterEmail()
        {
            lgpage.Enteremail();
        }
        
        [Given(@"I enter password")]
        public void GivenIEnterPassword()
        {
            lgpage.Enterpassword();
        }*/

        [Given(@"I enter email and password")]
        public void GivenIEnterEmailAndPassword(Table table)
        {
            dynamic emailandpassword = table.CreateInstance<Details>();
            string email = emailandpassword.Email;
            string password = emailandpassword.Password;
            lgpage.emailAndpassword(email, password);

            //or
            /*var emailAndpassword = table.CreateInstance<Details>();
            string email = emailAndpassword.Email;
            string password = emailAndpassword.Password;
            lgpage.emailAndpassword(email, password);*/
            string screenshotpath3 = ExtentReport.capture(Base.driver, "Email&Password");
            rp.LogReportStatements(Status.Info, "Entered email and password", screenshotpath3);
        }


        [Given(@"I click remenber me")]
        public void GivenIClickRemenberMe()
        {
            lgpage.Clickcheckbox();
            //string cheboximag = ExtentReport.capture(Base.driver, "Checkboximge");
            rp.LogReportStatements(Status.Info, "Clicked on checkbox");
        }
        
        [When(@"I press login")]
        public void WhenIPressLogin()
        {
            lgpage.Clickbutton();
            //string clickbuttonimg = ExtentReport.capture(Base.driver, "Clickbtnimage");
            rp.LogReportStatements(Status.Info, "Clicked on loginBtn");
            rp.LogReportStatements(Status.Pass, "Test Pass");
            rp.flushReport();
        }
    }
}
