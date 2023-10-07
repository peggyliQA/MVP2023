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
        //declare objects
        LanguagePage LanguagePageObj;
        LoginPage LoginPageObj;
        LanguagePage languagePageObj = new LanguagePage();


        public LanguageFeatureStepDefinitions()
        {   
            LanguagePageObj = new LanguagePage();
            LoginPageObj = new LoginPage();
        }       

        [Given(@"User logged into Mars application successfully")]
        public void GivenUserLoggedIntoMarsApplicationSuccessfully()
        {
            //go to login steps
            LoginPageObj.LoginSteps();
        }

        [When(@"I create a new '([^']*)' with '([^']*)' record")]
        public void WhenICreateANewWithRecord(string language, string level)
        {
            //create a new language
            LanguagePageObj.addLanguage(language, level);
        }

        [Then(@"New  '([^']*)' with '([^']*)' record should be added successfully")]
        public void ThenNewWithRecordShouldBeAddedSuccessfully(string language, string level)
        {
            //create local variables to simply the obj for validation
            //LanguagePage languagePageObj = new LanguagePage();
            string newLanguage = languagePageObj.getAddLang();
            string newLanguageLevel = languagePageObj.getAddLangLevel();

            if (language == newLanguage && level == newLanguageLevel)
            {
                Assert.AreEqual(language, newLanguage, "Actual language and expected language do not match.");
                Assert.AreEqual(level, newLanguageLevel, "Actual language level and expected language level do not match.");
            }
            else
            {
                Console.WriteLine("Please check the error.");
            }
        }
        //=============================EDIT======================

        //Edit the existing language records
        [Given(@"User logged into Mars app successfully")]
        public void GivenUserLoggedIntoMarsAppSuccessfully()
        {
            //go to login steps
            LoginPageObj.LoginSteps();
        }

        [When(@"I edit the existing '([^']*)' and/or '([^']*)' record and udpate with the new value '([^']*)' & '([^']*)'")]
        public void WhenIEditTheExistingAndOrRecordAndUdpateWithTheNewValue(string languageToBeUpdated, string levelToBeUpdated, string language, string level)
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
            string editedlanguage = languagePageObj.getEditLang();
            string editedlanguageLevel = languagePageObj.getEditLangLevel();
           

                if (language == editedlanguage && level == editedlanguageLevel)
            {
                Assert.AreEqual(language, editedlanguage, "Actual language and expected language do not match.");
                Assert.AreEqual(level, editedlanguageLevel, "Actual language level and expected language level do not match.");
            }
            else
            {
                Console.WriteLine("Please check the error.");
            }

        }

        //============================DELETE================================
        [Given(@"User logged into Mars app successfull")]
        public void GivenUserLoggedIntoMarsAppSuccessfull()
        {
            //go to login steps
            LoginPageObj.LoginSteps();
        }


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
