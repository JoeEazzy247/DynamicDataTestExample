using ClassLibrary1.Hooks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class LoginPage
    {
        IWebDriver driver;
        DefaultWait<IWebDriver> fluentwait;
        public LoginPage()
        {
            this.driver = Base.driver;
            fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(15);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        }

        IWebElement email => driver.FindElement(By.CssSelector("input#Email"));
        IWebElement password => driver.FindElement(By.CssSelector("input#Password"));
        IWebElement checkbox => driver.FindElement(By.CssSelector("input#RememberMe"));
        IWebElement login => driver.FindElement(By.CssSelector("input[type=submit]"));

        public void website(string url)
        {
            driver.Url = url;
            
        }

       /* public void Enteremail()
        {
            fluentwait.Until(ExpectedConditions.ElementToBeClickable(email)).SendKeys("ABC@abc.com");
        }

        public void Enterpassword()
        {
            fluentwait.Until(ExpectedConditions.ElementToBeClickable(password)).SendKeys("123456");
        }*/

        public void Clickcheckbox()
        {
           var click= fluentwait.Until(ExpectedConditions.ElementToBeClickable(checkbox));
            click.Click();
        }

        public void emailAndpassword(string Email, string Password)
        {
            fluentwait.Until(ExpectedConditions.ElementToBeClickable(email)).SendKeys(Email);
            fluentwait.Until(ExpectedConditions.ElementToBeClickable(password)).SendKeys(Password);
           
        }

        public void Clickbutton()
        {
            fluentwait.Until(ExpectedConditions.ElementToBeClickable(login)).Click();
        }

    }
}
