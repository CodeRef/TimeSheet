using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace AutomateTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new FirefoxDriver();

            //Notice navigation is slightly different than the Java version
            //This is because 'get' is a keyword in C#
            driver.Navigate().GoToUrl("http://www.google.com/");
            IWebElement query = driver.FindElement(By.Name("q"));
            query.SendKeys("Asp.net MVC");
            System.Console.WriteLine("Page title is: " + driver.Title);
            query.Submit();
            driver.Quit();

            IWebDriver cdriver = new ChromeDriver(@"C:\selenium\net40\Driver\");

            //Notice navigation is slightly different than the Java version
            //This is because 'get' is a keyword in C#
            cdriver.Navigate().GoToUrl("http://www.google.com/");
            IWebElement cquery = cdriver.FindElement(By.Name("q"));
            cquery.SendKeys("Asp.net MVC");
            System.Console.WriteLine("Page title is: " + cdriver.Title);
            cquery.Submit();
            cdriver.Quit();

            Console.ReadKey();
        }
    }
}
