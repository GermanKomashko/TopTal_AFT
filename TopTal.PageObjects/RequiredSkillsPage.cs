using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace TopTal.PageObjects
{
    public class RequiredSkillsPage : ProfilePage
    {
        [FindsBy(How = How.Id, Using = "job_skill_sets")]
        private IWebElement _requiredSkillsField;

        [FindsBy(How = How.XPath, Using = "//button[text()='Next — Confirmation']")]
        private IWebElement _nextConfirmationButton;


        public RequiredSkillsPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }


        public void AddSkillToSkillsField(string skill)
        {
            _requiredSkillsField.SendKeys(skill + Keys.Enter);

            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
        }


        public void AddSkillToSkillsField(List<string> skills)
        {
            foreach (string skill in skills)
            {
                AddSkillToSkillsField(skill);
            }
        }
        

        public bool IsSkillPresentInSkillGroup(string skillName, SkillGroupType skillGroupName)
        {
            var skillGroups = Driver.FindElements(By.ClassName("is-skill_group"));
            
            foreach (IWebElement skillGroup in skillGroups)
            {
                if (skillGroup.FindElement(By.ClassName("label_wrap")).Text.Equals(skillGroupName));
                {
                    var skills = skillGroup.FindElements(By.ClassName("js-skill"));

                    foreach (IWebElement skill in skills)
                    {
                        if (skill.FindElement(By.CssSelector("span")).Text.Equals(skillName))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }


        public ConfirmPage ClickNextConfirmationButton()
        {
            _nextConfirmationButton.Click();

            return new ConfirmPage(Driver);
        }
    }
}
