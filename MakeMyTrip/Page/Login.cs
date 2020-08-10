using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MakeMyTrip.Page
{
   public class Login
    {
        public IWebDriver driver;
        public Login(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#SW > div.landingContainer > div.makeFlex.hrtlCenter.prependTop5.appendBottom40 > ul > li.makeFlex.hrtlCenter.font10.makeRelative.lhUser > div.autopop__wrap.makeFlex.column.defaultCursor > div > div.makeFlex.socialBtnContainer.appendBottom15.vrtlCenter > div.makeFlex.googleLoginBtn.flexOne")]

        public IWebElement google;

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/div[2]/div/div[2]/div/div/div[2]/div/div[1]/div/form/span/section/div/div/div[1]/div/div[1]/div/div[1]/input")]

        public IWebElement userName;

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/div[2]/div/div[2]/div/div/div[2]/div/div[1]/div/form/span/section/div/div/div[1]/div[1]/div/div/div/div/div[1]/div/div[1]/input")]

        public IWebElement password;

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/div[2]/div/div[2]/div/div/div[2]/div/div[2]/div/div[1]/div/div/button/div[2]")]
        public IWebElement userNext;

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/div[2]/div/div[2]/div/div/div[2]/div/div[2]/div/div[1]/div/div/button/div[2]")]
        public IWebElement passNext;

        [FindsBy(How = How.XPath, Using = "//li[6]//div[1]//p[1]")] 

        public IWebElement validation;

        [FindsBy(How = How.XPath, Using = "//div[@class='o6cuMc']")] 

        public IWebElement wrongUserName;

        public void LoginToMakeMyTrip(String email, String Password)
        {
            Thread.Sleep(2000);
            string mainWindow = driver.CurrentWindowHandle;
            Thread.Sleep(2000);
            google.Click();
            Thread.Sleep(2000);
            List<string> lstWindow = driver.WindowHandles.ToList();
            foreach (var handle in lstWindow)
            {
             driver.SwitchTo().Window(handle);
            }
            Thread.Sleep(2000);
            userName.SendKeys(email);
            Thread.Sleep(2000);
            userNext.Click();
            Thread.Sleep(2000);
            password.SendKeys(Password);
            Thread.Sleep(5000);
            passNext.Click();
            Thread.Sleep(5000);
            driver.SwitchTo().Window(mainWindow);
            Thread.Sleep(5000);
        }

        public string UserNameValidation()
        {
            return validation.Text;
        }

        public string UserNameValidation1()
        {
            return wrongUserName.Text;
        }
    }
}
