//-----------------------------------------------------------------------
// <copyright file="Logout.cs" company="BridgeLabz">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

namespace MakeMyTrip.Page
{
    /// <summary>
    /// create Logout class
    /// </summary>
    public class Logout
    {
        /// <summary>
        /// create IWebDriver
        /// </summary>
        public IWebDriver driver;

        /// <summary>
        /// create Logout constructor
        /// </summary>
        /// <param name="driver"></param>
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

        /// <summary>
        /// create Logout to Makemytrip method
        /// </summary>
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
