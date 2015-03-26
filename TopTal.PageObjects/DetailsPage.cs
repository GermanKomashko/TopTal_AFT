using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using TopTal.PageObjects.TestDataModels;

namespace TopTal.PageObjects
{
    public class DetailsPage : ProfilePage
    {
        [FindsBy(How = How.Id, Using = "new_job_commitment")]
        private IWebElement _desiredCommitmentDropDown;

        [FindsBy(How = How.Id, Using = "job_prefer_timezone_yes")]
        private IWebElement _timeZonePreferenceYesCheckbox;

        [FindsBy(How = How.Id, Using = "job_prefer_timezone_no")]
        private IWebElement _timeZonePreferenceNoCheckbox;

        [FindsBy(How = How.Id, Using = "new_job_start_date")]
        private IWebElement _desiredStartDate;

        [FindsBy(How = How.Id, Using = "new_job_estimated_length")]
        private IWebElement _estimatedLengthDropDown;

        [FindsBy(How = How.Id, Using = "new_job_time_zone_name")]
        private IWebElement _timeZoneDropDown; 

        [FindsBy(How = How.Id, Using = "new_job_hours_overlap")]
        private IWebElement _hoursOfOverlapDropDown;

        [FindsBy(How = How.Id, Using = "new_job_languages")]
        private IWebElement _spokenLanguagesSuggestionField;

        [FindsBy(How = How.ClassName, Using = "js-suggests-multiple__items_container")]
        private IWebElement _choosedLanguagesBox;  

        [FindsBy(How = How.XPath, Using = "//*[text()='Next — Required Skills']")]
        private IWebElement _nextRequiredSkillsButton;  


        public DetailsPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }


        public string DesiredCommitment
        {   
            get { return _desiredCommitmentDropDown.Text; }

            set
            {
                SelectElement selectElement = new SelectElement(_desiredCommitmentDropDown);

                selectElement.SelectByText(value);
            }
        }


        public void SetTimeZonePreference(bool specify)
        {
            if (specify)
            {
                _timeZonePreferenceYesCheckbox.Click();
            }
            else
            {
                _timeZonePreferenceNoCheckbox.Click();
            }
        }


        public string DesiredStartDate
        {
            get { return _desiredStartDate.Text; }

            set
            {
                _desiredStartDate.SendKeys(value + Keys.Tab); 
            }

            //TODO: Make some validation on date format. It should be yyyy-mm-dd 
        }


        public void ClearDesiredStartDate()
        {
            _desiredStartDate.Clear();
            _desiredStartDate.SendKeys(Keys.Tab);
        }


        public string EstimatedLength
        {
            get { return _estimatedLengthDropDown.Text; }

            set
            {
                Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

                SelectElement selectElement = new SelectElement(_estimatedLengthDropDown);
                selectElement.SelectByText(value);
            }
       
        }


        public string TimeZone
        {
            get { return _timeZoneDropDown.Text; }

            set
            {
                Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

                SelectElement selectElement = new SelectElement(_timeZoneDropDown);
                selectElement.SelectByText(value);
            }
        }


        public string HoursOverlap
        {
            get { return _hoursOfOverlapDropDown.Text; }
            
            set
            {
               SelectElement selectElement = new SelectElement(_hoursOfOverlapDropDown);   

               selectElement.SelectByText(value);
            }
        }


        public void AddLanguageToSpokenLanguagesField(string language) 
        {
            throw new NotImplementedException();
        }


        public void AddLanguageToSpokenLanguagesField(List<string> languages)
        {
            foreach (string language in languages)
            {   
                AddLanguageToSpokenLanguagesField(language);
            }
        }


        public RequiredSkillsPage ClickNextButton()
        {
            _nextRequiredSkillsButton.Click();

            return new RequiredSkillsPage(Driver);
        }


        public bool IsLanguageInLanguagesBox(string language)
        {
            var selectedLanguages = _choosedLanguagesBox.FindElements(By.XPath("//div[@class='js-language']"));

            foreach (IWebElement selectedLanguage in selectedLanguages)
            {
                if (selectedLanguage.FindElement(By.XPath("//span")).Text == language)
                {
                    return true;
                }
            }

            return false;
        }   


        public void FillDetailsPage(DetailsPageData detailsPageData)
        {
            if (detailsPageData.DesiredCommitment != null)
            {
                DesiredCommitment = detailsPageData.DesiredCommitment;
            }

            if (detailsPageData.HoursOfOverlap != null || detailsPageData.TimeZone != null)
            {
                SetTimeZonePreference(true);
            }

            if (detailsPageData.HoursOfOverlap != null)
            {
                HoursOverlap = detailsPageData.HoursOfOverlap;
            }

            if (detailsPageData.TimeZone != null)
            {
                TimeZone = detailsPageData.TimeZone;
            }

            ((IJavaScriptExecutor)Driver).ExecuteScript("window.scroll(0, 350);");

            if (detailsPageData.DesiredStartDate != null)
            {
                DesiredStartDate = detailsPageData.DesiredStartDate;
            }
            else
            {
                throw new Exception("Desired start date is mandatory field and can't be null");
            }

            if (detailsPageData.EstimatedLength != null)
            {
                EstimatedLength = detailsPageData.EstimatedLength;
            }
            else
            {
                throw new Exception("Estimated Length is mandatory field and can't be null");
            }

            if (detailsPageData.SpokenLanguages != null)
            {
                if (!detailsPageData.SpokenLanguages.Count.Equals(0))
                {
                    AddLanguageToSpokenLanguagesField(detailsPageData.SpokenLanguages);
                }
            }

            ClickNextButton();
        }

    }
}
