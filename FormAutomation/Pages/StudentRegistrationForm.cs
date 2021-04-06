using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace FormAutomation.Pages
{
    class StudentRegistrationForm
    {
        [Obsolete]
        public StudentRegistrationForm(IWebDriver Chromedriver)
        {
            driver = Chromedriver;
            PageFactory.InitElements(Chromedriver, this);
        }
        private static IWebDriver driver;



        [FindsBy(How = How.Id, Using = "firstName")]
        private IWebElement fNameTxt { get; set; }
        [FindsBy(How = How.Id, Using = "lastName")]
        private IWebElement lNameTxt { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='genterWrapper']/div[2]/div[1]/label")]
        private IWebElement genderRadioBtn { get; set; }
        [FindsBy(How = How.Id, Using = "userNumber")]
        private IWebElement mobileTxt { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='submit']")]
        private IWebElement btnSubmit { get; set; }
        [FindsBy(How = How.Id, Using = "example-modal-sizes-title-lg")]
        private IWebElement divThanks { get; set; }






        public void ExplicitWait(By element)
        {



            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
        }
        public bool isElementExist(IWebElement element)
        {

            return element.Displayed && element.Enabled;
        }



        public void WriteText(IWebElement element, String text)
        {
            element.Clear();
            element.SendKeys(text);
        }



        public void BtnClick(IWebElement btn)
        {
            btn.Click();
        }



        public bool SubmitForm()
        {
            ExplicitWait(By.Id("firstName"));
            WriteText(fNameTxt, "FName");
            WriteText(lNameTxt, "LName");
            BtnClick(genderRadioBtn);
            WriteText(mobileTxt, "033335347762");
            BtnClick(btnSubmit);
            ExplicitWait(By.Id("example-modal-sizes-title-lg"));
            return isElementExist(divThanks);
        }




    }
}