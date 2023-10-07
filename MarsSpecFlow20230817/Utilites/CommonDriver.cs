using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using MarsSpecFlow20230817.Page;
using OpenQA.Selenium.Edge;

namespace MarsSpecFlow20230817.Utilites
{
    
    public class CommonDriver
    {
        public static IWebDriver driver;
               
        public void Initialize()
        {
            //****Initalization driver
            driver = new EdgeDriver();

            //***Maximize the window
            driver.Manage().Window.Maximize();
            Thread.Sleep(1000);
       }
      
        public void Close()
        {
            driver.Close();
        }
    }
}
