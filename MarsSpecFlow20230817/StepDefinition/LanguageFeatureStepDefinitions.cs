using MarsSpecFlow20230817.Page;
using MarsSpecFlow20230817.Utilites;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Diagnostics.Contracts;
using System.Reflection.Emit;
using TechTalk.SpecFlow;
using static System.Net.Mime.MediaTypeNames;

namespace MarsSpecFlow20230817.StepDefinition
{

    [Binding]
    public class LanguageFeatureStepDefinitions : CommonDriver
    {
        LanguagePage languagePageObj = new LanguagePage();

        [Given(@"User logged into Mars application successfully")]
        public void GivenUserLoggedIntoMarsApplicationSuccessfully()
        {
            // Assert username Identity 
            Thread.Sleep(1000);
            IWebElement loginName = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span/div"));
            if (loginName.Text == "Hi Peggy")
            {
                Console.WriteLine("user has logged in successfully");
            }
            else
            {
                Console.WriteLine("user failed to login");
            }
        }

        [When(@"I navigte to language page")]
        public void WhenINavigteToLanguagePage()
        {
            LanguagePage languagePageObj = new LanguagePage();
            languagePageObj.GoToLangTab();
        }

        [When(@"I create a new '([^']*)' with '([^']*)' record")]
        public void WhenICreateANewWithRecord(string language, string level)
        {
            //create a new language
            LanguagePage languagePageObj = new LanguagePage();
            languagePageObj.addLanguage(language, level);
        }

        [Then(@"New  '([^']*)' with '([^']*)' record should be added successfully")]
        public void ThenNewWithRecordShouldBeAddedSuccessfully(string language, string level)
        {
            //create local variables to simply the obj for validation
            LanguagePage languagePageObj = new LanguagePage();
            string newLanguage = languagePageObj.getAddLang();
            string newLanguageLevel = languagePageObj.getAddLangLevel();

            if (language == newLanguage && level == newLanguageLevel)
            {
                Assert.AreEqual(language, newLanguage, "Actual language and expected language do not match.");
                Assert.AreEqual(level, newLanguageLevel, "Actual language level and expected language level do not match.");
                //Assert.That(newLanguage == language, "Actual language and expected language do not match.");
                //Assert.That(condition: newLanguageLevel == level, "actual language level and expected level do not match");
            }
            else
            {
                Console.WriteLine("Please check the error.");
            }
        }
        //=============================EDIT======================
        //Edit the existing language records

        [When(@"I edit the existing '([^']*)' and/or '([^']*)' record and udpate wit the new value '([^']*)' & '([^']*)'")]
        public void WhenIEditTheExistingAndOrRecordAndUdpateWitTheNewValue(string languageToBeUpdated, string levelToBeUpdated, string language, string level)
        {
            //edit an existing language record in the language list
            LanguagePage languagePageObj = new LanguagePage();
            languagePageObj.editLanguage(languageToBeUpdated, levelToBeUpdated, language, level);
        }

        [Then(@"Edited  '([^']*)' with '([^']*)' record should be edited successfully")]
        public void ThenEditedWithRecordShouldBeEditedSuccessfully(string language, string level)
        {
            //create local variables to simply the obj for validation
            LanguagePage languagePageObj = new LanguagePage();
            string expectedLanguage = languagePageObj.getAddLang();
            string expectedLanguageLevel = languagePageObj.getEditLangLevel();

            if (language == expectedLanguage && level == expectedLanguageLevel)
            {
                Assert.AreEqual(language, expectedLanguage, "Actual language and expected language do not match.");
                Assert.AreEqual(level, expectedLanguageLevel, "Actual language level and expected language level do not match.");
                //Assert.That(newLanguage == language, "Actual language and expected language do not match.");
                //Assert.That(condition: newLanguageLevel == level, "actual language level and expected level do not match");
            }
            else
            {
                Console.WriteLine("Please check the error.");
            }

        }
        


            //============================DELETE================================
            //[When(@"I delete the existing '([^']*)' && '([^']*)' record")]
            //public void WhenIDeleteTheExistingRecord(string language, string level)
            //{
            //LanguagePage languagePageObj = new LanguagePage();
            //languagePageObj.deleteLanguage(language, level);

            //}
            //[Then(@"I deleted record for '([^']*)' && '([^']*)' sucessfully")]
            //public void ThenIDeletedRecordForSucessfully(string language, string level)
            //{
            //create local variables to simply the obj for validation
            //LanguagePage languagePageObj = new LanguagePage();
            //string actualLanguage = languagePageObj.getDeletedLang();
            //string actualLanguageLevel = languagePageObj.getDeletedLangLevel();
            //}
        
    }
}
