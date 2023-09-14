using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using MarsSpecFlow20230817.Utilites;

namespace MarsSpecFlow20230817.Page
{
    public class LoginPage : CommonDriver
    {
        public void LoginSteps()
        {
            //launch local host 5000
            driver.Navigate().GoToUrl("http://localhost:5000");
            //Thread.Sleep(1000); - try to use wait (follow the below path)
            //Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"home\"]/div/div/div[1]/div/a", 5);

            //---------------LOGIN TO THE MARS APPLICATION---------
            IWebElement signInText = driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
            signInText.Click();
            Thread.Sleep(2000);

            //identify the user email textbox and enter valid password
            IWebElement userEmailTexbox = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
            userEmailTexbox.SendKeys("peggyli@email.com");
            Thread.Sleep(2000);

            //Identify the password textbox and enter
            IWebElement userPasswordTextbox = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
            userPasswordTextbox.SendKeys("123123");
            Thread.Sleep(2000);

            //click the login button
            IWebElement loginButton = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
            loginButton.Click();
            Thread.Sleep(2000);
        }
    }
}
//public static void Login() - code provided from onboarding tasks
//{
//    Driver.NavigateUrl();

//    //Enter Url
//    Driver.driver.FindElement(By.XPath("//A[@class='item'][text()='Sign In']")).Click();

//    //Enter Username
//    Driver.driver.FindElement(By.XPath("(//INPUT[@type='text'])[2]")).SendKeys("");

//    //Enter password
//    Driver.driver.FindElement(By.XPath("//INPUT[@type='password']")).SendKeys("");

//    //Click on Login Button
//    Driver.driver.FindElement(By.XPath("//BUTTON[@class='fluid ui teal button'][text()='Login']")).Click();

////}
