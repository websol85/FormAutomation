# FormAutomation
1. Create a console app .net framework from visual studio c#
2. Create Form Automation project name
2. Install selenium.webdriver, Selenium.support, selenium.webdriver.chrome, DotNetseleniumextraswaithelpers and nnuit from NUget
3. Add new folder and name it Pages
4. Add Class StudentRegistrationForm and add code in this class

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
        private  IWebElement btnSubmit { get; set; }
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
            WriteText(mobileTxt, "0308524691");
            BtnClick(btnSubmit);
            ExplicitWait(By.Id("example-modal-sizes-title-lg"));
            return isElementExist(divThanks);
        }

 


    }
}

5. Now in program.cs add this code


using FormAutomation.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 

namespace FormAutomation
{
    class Program
    {
        IWebDriver driver = new ChromeDriver();
        StudentRegistrationForm objStudent = null;
        static void Main(string[] args)
        {
        }

 

        [SetUp]
        public void Initialize()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
            driver.Manage().Window.Maximize();
            objStudent = new StudentRegistrationForm(driver);
            
        }

 

        [Test]
        public void ExecuteTest()
        {
            objStudent.SubmitForm();
        }

 

        [TearDown]
        public void CleanUp()
        {
            driver.Close();
        }
    }
}
