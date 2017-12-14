using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Support.UI;


namespace WebDriverDemo
{
    class CASEMIS_Errors
    {
        public static void ErrorCheck(string url, int sec)

        {
            IWebDriver driver = new ChromeDriver();

            //Redirecting to SEIS.org
            driver.Url = url;

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            //Clicking the Log in button at SEIS.org
            var loginSEIS = driver.FindElement(By.LinkText("Login"));
            loginSEIS.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(sec);


            //Logging in as stateforms
            var username = driver.FindElement(By.Id("username"));
            username.SendKeys("stateforms");

            var password = driver.FindElement(By.Id("password"));
            password.SendKeys("Password1!");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(sec);

            var seisSubmit = driver.FindElement(By.Id("loginForm"));
            var seisLogin = seisSubmit.FindElement(By.TagName("button"));
            seisLogin.Click();



            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(sec);
            Console.WriteLine(driver.Url);

            if (driver.Url.Contains("https://beta.seis.org/dashboard"))
            {
                Console.WriteLine("Ha I told you i would get it");

            }
            else
            {
                Console.WriteLine("Log in Unsuccesful");
            }
            


            //Selecting to fix CASEMIS Errors
            var fixErrors = driver.FindElement(By.Id("casemisErrors"));
            var selectFixErrors = fixErrors.FindElement(By.TagName("button"));
            selectFixErrors.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(sec);


            //Selecting first Student to Fix Errors
            var firstStudent = driver.FindElement(By.ClassName("odd"));
            var selectFirstStudent = firstStudent.FindElements(By.TagName("a"))[0];
            selectFirstStudent.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(sec);

            //Clicking the save button then returning to homepage
            var errorSave = driver.FindElement(By.Name("form"));
            var selectSave = errorSave.FindElement(By.TagName("button"));
            selectSave.Click();

            Console.WriteLine("CASEMIS Error Saved Correctly");
            

        }
    }
}