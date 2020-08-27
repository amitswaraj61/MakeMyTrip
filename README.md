## Project Title



MakeMyTrip Website Automation




## Description

* The project is to automate MakeMyTrip.com which is an Indian Online travel company, company provides online travel services including flight,hotel,bus tickets etc.

## Prerequisites

* Visual Studio 2019  

* Chrome Browser  

* Firefox Browser

* Internet Connection

## Technology Used

* C#

## Frameworks

* .Net Framework  

* Nunit  

* Selenium  

* Data Driven 

## Design Pattern

* Page Object Model

## Packages

* DotNetSeleniumExtras.PageObjects- For Page object Model  

* ExtentReports- To generate Test Reports   

* NUnit- To define test cases, assertion  

* NUnit3Adapter- Running test cases in Visual Studio  

* Selenium.WebDriver- .Net Binding for selenium webdriver API  

* Selenium.WebDriver.ChromeDriver- Driver for Google Chrome  

* Selenium.Firefox.WebDriver-Driver for Firefox browser

* DNSClient- In this project it is uesd to get Host name

* Log4Net-Logging Test steps to log file

* Newtonsoft.Json-To access data from json file


## Test scenario covered

    #First- Positive scenario of Book Flight

* Login to MakeMyTrip application  

* Navigates to Home page  

* Click on flight 

* Click on round trip

* Enter from city 
* Enter to city
* Enter departure date
* Enter return date  

* Click on search flight button 
* Click on non stop and 1 stop box
* print all the flight in the console
* select flight and verify the price at the button in page
* click on logout button

## Running the tests


* Navigate to tool bar and Click on Test  

* Click on run all Test


## Author



* Amit kumar