using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

namespace MakeMyTrip.Page
{
    public class Logout
    {
        public IWebDriver driver;
        public Logout(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//body//ul//div//div//div//span[1]")]

        public IWebElement AdminButton;

        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'Logout')]")]

        public IWebElement LogoutButton;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Okay, got it')]")]

        public IWebElement Gotit;

        public void LogoutToMakeMyTrip()
        {
            Thread.Sleep(2000);
            AdminButton.Click();
            Thread.Sleep(2000);
            LogoutButton.Click();
            Thread.Sleep(2000);
            Gotit.Click();
        }
    }
}

        
