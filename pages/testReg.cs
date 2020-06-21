using ClassLibrary1.Hooks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.pages
{
    
    class testReg
    {
        IWebDriver driver;
        DefaultWait<IWebDriver> fwait;
        public testReg(/*IWebDriver _driver*/)
        {
            driver = Base.driver;
            fwait = new DefaultWait<IWebDriver>(driver);
            fwait.Timeout = TimeSpan.FromSeconds(20);
            fwait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        }

            By emailinput = By.CssSelector("input#Email");
            By Passwordinput = By.CssSelector("input#Password");
            By checkbox = By.CssSelector("input#RememberMe");
            By loginbtn = By.CssSelector("input[type=submit]");

        public void SetEmail(string email)
        {
            driver.FindElement(emailinput).SendKeys(email);
            var EmailInput = fwait.Until(ExpectedConditions.ElementToBeClickable(emailinput));
            EmailInput.SendKeys(email);
        }

        public void SetPassword(string password)
        {
            driver.FindElement(Passwordinput).SendKeys(password);
            var PassInput = fwait.Until(ExpectedConditions.ElementToBeClickable(Passwordinput));
            PassInput.SendKeys(password);
        }

        public void ClickCheckbox()
        {
            
            var clickCbox = fwait.Until(ExpectedConditions.ElementToBeClickable(checkbox));
            clickCbox.Click();
        }

        public void ClickLiginBtn()
        {
            fwait.Until(x => x.FindElement(loginbtn)).Click();
        }
    }
}
