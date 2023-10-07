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
            //--------------LAUNCH LOCAL HOST-----------------------
            driver.Navigate().GoToUrl("http://localhost:5000");
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"home\"]/div/div/div[1]/div/a", 5);

            //---------------LOGIN TO THE MARS APPLICATION---------
            IWebElement signInText = driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
            signInText.Click();
            Wait.WaitToBeClickable(driver, "XPath", "/html/body/div[2]/div/div/div[1]/div/div[1]/input", 3);


            //identify the user email textbox and enter valid password
            IWebElement userEmailTexbox = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
            userEmailTexbox.SendKeys("peggyli@email.com");
            Wait.WaitToBeClickable(driver, "XPath", "/html/body/div[2]/div/div/div[1]/div/div[2]/input", 3);


            //Identify the password textbox and enter
            IWebElement userPasswordTextbox = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
            userPasswordTextbox.SendKeys("123123");
            Wait.WaitToBeClickable(driver, "XPath", "/html/body/div[2]/div/div/div[1]/div/div[4]/button", 3);
                       

            //click the login button
            IWebElement loginButton = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
            loginButton.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]", 3);
        }
    }
}
