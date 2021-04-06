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