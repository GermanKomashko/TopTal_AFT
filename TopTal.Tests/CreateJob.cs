using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using TopTal.Core;
using TopTal.PageObjects;
using TopTal.PageObjects.TestDataModels;
using TopTal.Utilities;


namespace TopTal.Tests
{
    [TestClass]
    public class CreateJob : BaseTest
    {
        [TestInitialize]
        public void Precondition()
        {
            #region Testdata
            string email = "slava.connectpal.com@mailinator.com";
            string password = "password";
            #endregion

            LandingPage landingPage = new LandingPage(Driver);
            LoginPage loginPage = landingPage.OpenLoginPage();
            ProfilePage profilePage = loginPage.LogOn(email, password);
            profilePage.ClickAddNewJobButton();
        }


        [TestMethod]
        public void Job_ShouldBeCreated() 
        {   
            BasicInfoPage basicInfoPage = new BasicInfoPage(Driver);
            basicInfoPage.FillBasicInfoPage("Some Title", "some description about description with description");
            
            DetailsPage detailsPage = new DetailsPage(Driver);
            detailsPage.FillDetailsPage(new DetailsPageData()
            {
                DesiredStartDate = "2015-04-03",
                EstimatedLength = "12+ months"
            });

            RequiredSkillsPage requiredSkillsPage = new RequiredSkillsPage(Driver);
            requiredSkillsPage.AddSkillToSkillsField(new List<string>()
            {
                "Java", "Scala", "Groovy", "SQL", "HTTP", "JSON", "GWT", "JavaScript"
            });
            Scrolling.ScrollDown(Driver, 300);
            requiredSkillsPage.ClickNextConfirmationButton();
            
            ConfirmPage confirmPage = new ConfirmPage(Driver);
            confirmPage.ConfirmAllAndSubmit();

            WhatsNextPage whatsNextPage = new WhatsNextPage(Driver);

            Assert.IsNotNull(whatsNextPage.ConfirmTitle);
        }

        
        [TestMethod]
        public void BasicInfoPage_ShouldShowValidation()
        {
            BasicInfoPage basicInfoPage = new BasicInfoPage(Driver);
            basicInfoPage.ClickNextButton();

            Assert.IsTrue(basicInfoPage.GetErrorsList().Count.Equals(2));

            basicInfoPage.TitleField = "someTitle";
            basicInfoPage.ClickNextButton();

            Assert.IsTrue(basicInfoPage.GetErrorsList().Count.Equals(1));

            basicInfoPage.ClearTitleField();
            basicInfoPage.DescriptionField = "someDetails";
            basicInfoPage.ClickNextButton();

            Assert.IsTrue(basicInfoPage.GetErrorsList().Count.Equals(1));
        } 


        [TestMethod]
        public void DetailsPage_ShouldShowValidation()
        {
            BasicInfoPage basicInfoPage = new BasicInfoPage(Driver);
            basicInfoPage.FillBasicInfoPage("someTitle", "someDescription");

            DetailsPage detailsPage = new DetailsPage(Driver);
            detailsPage.ClickNextButton();
            
            Assert.IsTrue(detailsPage.GetErrorsList().Count.Equals(2));

            detailsPage.DesiredStartDate = "2015-04-06";
            detailsPage.ClickNextButton();

            Assert.IsTrue(detailsPage.GetErrorsList().Count.Equals(1));

            detailsPage.ClearDesiredStartDate();
            detailsPage.EstimatedLength = "6-12 months";
            detailsPage.ClickNextButton();

            Assert.IsTrue(detailsPage.GetErrorsList().Count.Equals(1));
        }


        [TestMethod]
        public void RequiredSkillsPage_ShouldShowValidation()
        {
            BasicInfoPage basicInfoPage = new BasicInfoPage(Driver);
            basicInfoPage.FillBasicInfoPage("someTitle", "someDescription");

            DetailsPage detailsPage = new DetailsPage(Driver);
            detailsPage.FillDetailsPage(new DetailsPageData()
            {
                DesiredStartDate = "2015-04-06",
                EstimatedLength = "6-12 months"
            });

            RequiredSkillsPage requiredSkillsPage = new RequiredSkillsPage(Driver);
            Scrolling.ScrollDown(Driver, 400);
            requiredSkillsPage.ClickNextConfirmationButton();

            Assert.IsTrue(requiredSkillsPage.GetErrorsList().Count.Equals(1));
        }


        [TestMethod]
        public void ConfirmPage_ShouldShowValidation()
        {
            BasicInfoPage basicInfoPage = new BasicInfoPage(Driver);
            basicInfoPage.FillBasicInfoPage("someTitle", "someDescription");

            DetailsPage detailsPage = new DetailsPage(Driver);
            detailsPage.FillDetailsPage(new DetailsPageData()
            {
                DesiredStartDate = "2015-04-06",
                EstimatedLength = "6-12 months"
            });

            RequiredSkillsPage requiredSkillsPage = new RequiredSkillsPage(Driver);
            requiredSkillsPage.AddSkillToSkillsField(new List<string>()
            {
                "Java", "Scala", "Oracle"
            });
            Scrolling.ScrollDown(Driver, 400);

            requiredSkillsPage.ClickNextConfirmationButton();

            ConfirmPage confirmPage = new ConfirmPage(Driver);
            confirmPage.ClickSubmitButton();

            Assert.IsTrue(requiredSkillsPage.GetErrorsList().Count.Equals(3));

            confirmPage.ClickAcceptReviewCheckBox();
            confirmPage.ClickSubmitButton();

            Assert.IsTrue(requiredSkillsPage.GetErrorsList().Count.Equals(2));

            confirmPage.ClickAcceptDepositCheckBox();
            confirmPage.ClickSubmitButton();

            Assert.IsTrue(requiredSkillsPage.GetErrorsList().Count.Equals(1));
        }
    }
}
