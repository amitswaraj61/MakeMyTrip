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
    public class PrintTotalFlight
    {
        public IWebDriver driver;
        public PrintTotalFlight(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div//div//div//div//div[3]//div[1]//div[1]//div[1]//span[1]//label[1]//span[1]//span[1]")]

        public IWebElement nonStop;

        [FindsBy(How = How.XPath, Using = "//div[4]//div[1]//div[1]//div[1]//span[2]//label[1]//span[1]//span[1]")]

        public IWebElement firstStop;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'7,013')]")]

        public IWebElement validation;



        public void PrintFlight()
        {
            //Not Active flight 
            IList<IWebElement> header = driver.FindElements(By.XPath("//div[@class='fli-list splitVw-listing ']"));
            Console.WriteLine("Total numbe of Non Active flight is ---->" + header.Count);
            Thread.Sleep(5000);
            for (var i = 0; i < header.Count; i++)
            {
                Console.WriteLine("Non Active Flight----------->" + header[i].Text);
            }
            //Active flight
            IList<IWebElement> header1 = driver.FindElements(By.XPath("//div[@class='fli-list splitVw-listing active']"));
            Console.WriteLine("Total numbe of Active flight is ---->" + header1.Count);
            for (var i = 0; i < header1.Count; i++)
            {
                Console.WriteLine("Active Flight is ----->" + header1[i].Text);
            }

            Thread.Sleep(3000);
            nonStop.Click();
            Thread.Sleep(3000);
            firstStop.Click();
            Thread.Sleep(3000);

            //After Filter Non Active Flight
            IList<IWebElement> header3 = driver.FindElements(By.XPath("//div[@class='fli-list splitVw-listing ']"));
            Thread.Sleep(5000);
            Console.WriteLine("Atter Filter Zero and First Stop Flight list as shown below");
            Console.WriteLine("Total numbe of Non Active flight After Filter is ---->" + header3.Count);
            for (var i = 0; i < header3.Count; i++)
            {
                Console.WriteLine("Non Active Flight After Filter is ----------->" + header3[i].Text);
            }
            //After filter Active flight
            IList<IWebElement> header4 = driver.FindElements(By.XPath("//div[@class='fli-list splitVw-listing active']"));
            Console.WriteLine("Total numbe of Active flight After Filter is ---->" + header4.Count);
            for (var i = 0; i < header4.Count; i++)
            {
                Console.WriteLine("Active Flight After Filter is ----->" + header4[i].Text);
            }
        }
        public string Validation()
        {
            return validation.Text;
        }
    }
}
