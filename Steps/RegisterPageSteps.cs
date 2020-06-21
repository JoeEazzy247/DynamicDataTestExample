using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using ClassLibrary1.Utils;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ClassLibrary1.Steps
{
    [Binding]
    public class RegisterPageSteps
    {
        LoginPage lgpage = new LoginPage();

        [Given(@"I navigate to url")]
        public void GivenINavigateToUrl(Table table)
        {
            var website = table.CreateInstance<Details>();
            string url = website.url;
            lgpage.website(url);
        }

        [Given(@"I enter (.*) and (.*)")]
        public void GivenIEnterAnd(string email, string password)
        {
            lgpage.emailAndpassword(email, password);
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
        }


        [Given(@"I click remenber me")]
        public void GivenIClickRemenberMe()
        {
            lgpage.Clickcheckbox();
        }
        
        [When(@"I press login")]
        public void WhenIPressLogin()
        {
            lgpage.Clickbutton();
        }
    }
}
