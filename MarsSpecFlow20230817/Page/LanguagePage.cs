using MarsSpecFlow20230817.Utilites;
using Microsoft.VisualBasic.FileIO;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V113.CSS;
using OpenQA.Selenium.DevTools.V113.Debugger;
using OpenQA.Selenium.DevTools.V113.Network;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace MarsSpecFlow20230817.Page
{
    public class LanguagePage : CommonDriver
    {
        //*****************************Declare ADD method******************
        //add button level 1 
        private IWebElement AddNewLangButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
        //add button level 2 
        private IWebElement addLangButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
        //cancel button
        private IWebElement cancelLangButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[2]"));
        //New lanaguage text box
        private IWebElement addNewLangTextbox => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
        //dropdownbox language level
        private IWebElement dropdown => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select"));


        //*****************************Declare EDIT method******************
        
        private IWebElement levelToBeUpdatedDropdown = driver.FindElement(By.XPath($"//option[text() = '{levelToBeUpdated}')]//Parent::td//following-sibling::td[2]"));
        //private IWebElement editPencilIcon => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[1]/i"));
        //private IWebElement editUpdateButton => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[2]/tr/td[3]/span[1]/i"));
        private IWebElement editCancelButton => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/span/input[2]"));

        //private IWebElement editPencilIcon = driver.FindElement(By.XPath($"//[Text() ='{languageToBeUpdated}')]"))//Parent::td//following-sibling::td[3]//.click();
        //private IWebElement editUpdateButton = driver.FindElement(By.XPath(//a[Text(), '{languageToBeUpdated}')]//Parent::td//following-sibling::td[3]//.click();
        //private IWebElement CancelButton = driver.FindElement(By.XPath(//a[Text(), '{languageToBeUpdated}')]//Parent::td//following-sibling::td[4]//.click();


        // **********Go to language tab**********
        public void GoToLangTab()
            {
                IWebElement LanguageTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]"));
                Thread.Sleep(1000);
                LanguageTab.Click();
            }

            //************ADD NEW LANGUAGE***************
            public void addLanguage(string language, string level)
            {
                AddNewLangButton.Click();
                Thread.Sleep(2000);

                //identify the text box(declare at the beg) and enter the language 
                addNewLangTextbox.SendKeys(language);
                Thread.Sleep(2000);

                //select the desired language level
                IWebElement option = dropdown.FindElement(By.XPath($"//option[text()='{level}']"));
                option.Click();
                Thread.Sleep(2000);

                //identify the add button and click on add to save
                addLangButton.Click();
                Thread.Sleep(4000);

                //verify the result if it is on the last row of the table new record same as expected record
                IWebElement newLang = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
                Assert.That(newLang.Text == language, "Actual language is different from expected.");
            }

            public string getAddLang()
            {
                //get the value from web Table and return - create a new name in last row column1
                IWebElement actualdAddLang = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
                return actualdAddLang.Text;
            }

            public string getAddLangLevel()
            {
                //get the language level text from the drop down box in last row column 2
                IWebElement actualAddLangLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
                return actualAddLangLevel.Text;
            }

            //******************************************EDIT RECORD*************************************
                   
            public void editLanguage(string languageToBeUpdated, string levelToBeUpdated, string language, string level)
            {
                  //case1:  if languageToBeUpdated found 
               
                //---------updating language-----
                Wait.WaitToBeClickable(driver, "XPath", "//a[text()='languageToBeUpdated']", 5);
                //Click on "language" tab.
                LanguageTab.Click();
                Wait.WaitToExist(driver, "XPath", "//th[text()='languageToBeUpdated']//ancestor::thead//following-sibling::tbody[last()]", 5);
                
                // Find all rows in the table
                IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//th[text()='languageToBeUpdated']//ancestor::thead/following-sibling::tbody/tr"));
                foreach (IWebElement row in rows)
                {
                    // Get the text of the language and level column in the row
                    IWebElement languageToBeUpdated = row.FindElement(By.XPath("./td[1]"));
                    IWebElement levelToBeUpdated = row.FindElement(By.XPath("./td[2]"));
                    string languageTobeUpdateText = languageToBeUpdated.Text;
                    string levelToBeUpdatedText = levelToBeUpdated.Text;
                    
                    // Check if the language matches the provided text
                    if (languageTobeUpdateText.Equals(language, StringComparison.OrdinalIgnoreCase) && levelToBeUpdatedText.Equals(level, StringComparison.OrdinalIgnoreCase))
                    {
                        //Click on update icon button of desired row
                        IWebElement editPencilIcon = row.FindElement(By.XPath("./td[3]/span[1]/i"));
                        editPencilIcon.Click();
                        Thread.Sleep(1000);

                        //Clear & update language textbox
                        languageTobeUpdateText.Clear();
                        languageTobeUpdateText.SendKeys(language);
                                         
                        //update the language level
                        IWebElement levelToBeUpdated = levelToBeUpdatedDropdown.FindElement(By.XPath($"//levelToBeUpdatedOption[text()='{level}']"));
                        levelToBeUpdated.Click();
                        Thread.Sleep(2000);

                        //Click on "Update" button
                        UpdateButton.Click();
                        
                        ////Saving error or success message
                        //Wait.WaitToExist(driver, "XPath", "//div[@class='ns-box-inner']", 5);
                        //Message = MessageWindow.Text;
                        //if (GetMessage() == "Please enter skill and experience level")
                        //{
                        //    CancelButton.Click();
                        //}
                        break;
                    }
                }
            }
                 // case 2a: duplicate record msg - "This language is already added to your language list." + click cancel button
                // case 2b: empty or not input - 'Please enter language and level' + cancel

                    

            //method 1:
            // //step 2:• Iterate row and column and get the cell value.  td(column) tr(row)
            // //get the table size
            //int rowCount = driver.FindElement(By.XPath("*[@id="account - profile - section"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody]//tr")).size();
            //int colCount = driver.FindElement(By.XPath("*[@id="account - profile - section"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody]//th")).size();

            ////if spec flow table language = table column 1 then update
            //for(int i=1; i<rowCount: i++) 
            //    {
            //    for (int j = 1; j<colCount; j++)
            //    {
            //    //check each row and column for data
            //    driver.FindElement(By.XPath(*[@id = "account-profile-section"] / div / section[2] / div / div / div / div[3] / form / div[2] / div / div[2] / div / table / tbody / tr / td[1]))

            //     //Get the language & language level from spec flow table
            //        string actualValue = driver.FindElement(By.XPath("*[@id="account - profile - section"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr[" + i + "]/td[" + j + "])).getText();
            //        if (actualValue.eqauals(language))
            //        //update the new language
            //        private IWebElement editIcon => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr[" + i + "]/td[3]/span[1]/i"))
            //        editIcon.click();
            //        private IWebElement editLangTextbox => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
            //        editLangTextbox.SendKeys(language);

            //        //select the desired option using XPATH
            //        IWebElement option = dropdown.FindElement(By.XPath($"//option[text()='{level}']"));
            //        option.Click();
            //        //click update button
            //        private IWebElement updateLangButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[+i+]/tr/td/div/span/input[1]"));
            //        updateLangButton.click();
            //        else
            //        Thread.wait(1000);
            //        Message = MessageWindow.text;
            //        if GetMessage() == "Please enter skill and experience level")

            //        {
            //        //click cancel button
            //         private IWebElement cancelLangButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[2]"));
            //        cancelLangButton.click();
            //        }
            //        //exit the loop and go to the next search
            //        break;


            public string getEditLang()
            {
                //get the edited/latest language
                IWebElement actualdEditLang = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
                return actualdEditLang.Text;
            }

            public string getEditLangLevel()
            {
                //get the latest/updated language level text 
                IWebElement actualEditLangLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
                return actualEditLangLevel.Text;
            }

            //******************************************DELETE RECORD*************************************


            //public void deleteLanguage(string language, string level)
            //{
                // Find all rows in the table
              //  IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr"));
                //Thread.Sleep(2000);
                //oreach (IWebElement row in rows)
                //{
                    // Get the text of the first column (language column) in the row
                    //IWebElement languageElement = row.FindElement(By.XPath("./td[1]"));
                    //IWebElement languageLevel = row.FindElement(By.XPath("./td[2]"));
                    //string languageText = languageElement.Text;
                    //string languageLevelText = languageLevel.Text;
                    //Thread.Sleep(2000);

                    //// Check if the language matches the provided text
                    //if (languageText.Equals(language, StringComparison.OrdinalIgnoreCase) && languageLevelText.Equals(level, StringComparison.OrdinalIgnoreCase))
                    //{
                    //    // Find and click the delete icon in the row
                    //    IWebElement deleteIcon = row.FindElement(By.XPath("./td[3]/span[2]/i"));
                    //    deleteIcon.Click();
                    //    Thread.Sleep(2000);
                    //    break;
                    //}


                    //public string getDeleteLang()
                    //{
                    //    //assertion - get and return the deleted language - check first colunn and 2nd column have the exact match

                    //    IWebElement actualdDeleteLang = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
                    //    return actualDeleteLang.Text;
                    //}

                    //public string getDeleteLangLevel()
                    //{
                    //    //get and return the deleted language
                    //    IWebElement actualDeleteLangLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
                    //    return actualDeleteLangLevel.Text;
                    //}
                }
            
        }
