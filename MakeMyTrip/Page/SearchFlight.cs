using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MakeMyTrip.Page
{
  public class SearchFlight
    {
        public IWebDriver driver;
        public SearchFlight(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//li[contains(text(),'Round Trip')]")]

        public IWebElement roundTrip;

        [FindsBy(How = How.XPath, Using = "//body/div/div/div/div/div/div/div/div[1]/label[1]")]

        public IWebElement fromCity;

        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'Mumbai, India')]")]

        public IWebElement mumbai;

        [FindsBy(How = How.XPath, Using = "//html//body//div//div//div//div//div//div//div//div//div//div//div//div//input")]

        public IWebElement toCity;

        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'Bengaluru, India')]")]

        public IWebElement bengaluru;

        [FindsBy(How = How.XPath, Using = "//div//div//div//div//div//div//div//div//div//div//div//div//div//div//div[1]//div[3]//div[4]//div[2]//div[1]//p[1]")]
        public IWebElement selectDate;

        [FindsBy(How = How.XPath, Using = "//div//div//div//div//div//div//div//div//div//div//div//div//div//div//div[1]//div[3]//div[5]//div[2]//div[1]//p[1]")]
        public IWebElement returnSelectDate;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Search')]")]

        public IWebElement search;

        [FindsBy(How = How.XPath, Using = "//body/div/div/div/div/div/div/p[1]")]

        public IWebElement validation;


        public void Search()
        {
            roundTrip.Click();
            Thread.Sleep(3000);
            fromCity.SendKeys(ConfigurationManager.AppSettings["fromCity"]);
            Thread.Sleep(3000);
            mumbai.Click();
            Thread.Sleep(3000);
            toCity.SendKeys(ConfigurationManager.AppSettings["toCity"]);
            bengaluru.Click();
            Thread.Sleep(2000);

            selectDate.Click();
            Thread.Sleep(2000);

            returnSelectDate.Click();
            Thread.Sleep(2000);
            search.Click();
            Thread.Sleep(5000);
        }
    
        public string SearchFlightValidation()
        {
            return validation.Text;
        }
    }
}

