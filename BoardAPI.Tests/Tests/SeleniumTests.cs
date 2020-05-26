using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace WorkflowAPI.Tests.Tests
{
    public class SeleniumTests
    {
        private IWebDriver driver;
        private string URL;
        private string login;

        [TearDown]
        public void tearDownTests()
        {
            driver.Close();
        }

        [SetUp]
        public void setUpTests()
        {
            URL = "https://workflowui.azurewebsites.net/";
            login = "TestSelenium12";

            driver = new ChromeDriver(Directory.GetCurrentDirectory());
        }

        [Test, Order(1)]
        public void RegisterTest_SendCorrectInformations_Registered()
        {
            driver.Navigate().GoToUrl(URL + "register");
            driver.Manage().Window.Maximize();

            IWebElement firstNameInput = driver.FindElement(By.XPath("//*[@id='layoutAuthentication_content']/main/div/div[2]/div/div/div[2]/form/div[1]/input"));
            firstNameInput.SendKeys("Selenium1");

            IWebElement secondNameInput = driver.FindElement(By.XPath("//*[@id='layoutAuthentication_content']/main/div/div[2]/div/div/div[2]/form/div[2]/input"));
            secondNameInput.SendKeys("Selenium2");

            IWebElement loginInput = driver.FindElement(By.XPath("//*[@id='layoutAuthentication_content']/main/div/div[2]/div/div/div[2]/form/div[3]/input"));
            loginInput.SendKeys(login);

            IWebElement passwordInput = driver.FindElement(By.XPath("//*[@id='layoutAuthentication_content']/main/div/div[2]/div/div/div[2]/form/div[4]/input"));
            passwordInput.SendKeys("SeleniumPassword1");

            passwordInput.Submit();

            System.Threading.Thread.Sleep(5000);

            Assert.That(driver.Url, Is.EqualTo("https://workflowui.azurewebsites.net/login"));
        }

        [Test, Order(2)]
        public void LoginTest_SendCorrectInformations_LoggedIn()
        {
            driver.Navigate().GoToUrl(URL + "login");
            driver.Manage().Window.Maximize();

            IWebElement loginInput = driver.FindElement(By.XPath("//*[@id='layoutAuthentication_content']/main/div/div[2]/div/div/div[2]/form/div[1]/input"));
            loginInput.SendKeys(login);

            IWebElement passwordInput = driver.FindElement(By.XPath("//*[@id='layoutAuthentication_content']/main/div/div[2]/div/div/div[2]/form/div[2]/input"));
            passwordInput.SendKeys("SeleniumPassword1");

            passwordInput.Submit();

            System.Threading.Thread.Sleep(5000);

            Assert.That(driver.Url, Is.EqualTo("https://workflowui.azurewebsites.net/dashboard"));
        }

        [Test, Order(3)]
        public void Dashboard_ClickOnNavbar_NavigateToProjects()
        {
            driver.Navigate().GoToUrl(URL + "login");
            driver.Manage().Window.Maximize();

            IWebElement loginInput = driver.FindElement(By.XPath("//*[@id='layoutAuthentication_content']/main/div/div[2]/div/div/div[2]/form/div[1]/input"));
            loginInput.SendKeys(login);

            IWebElement passwordInput = driver.FindElement(By.XPath("//*[@id='layoutAuthentication_content']/main/div/div[2]/div/div/div[2]/form/div[2]/input"));
            passwordInput.SendKeys("SeleniumPassword1");

            passwordInput.Submit();

            System.Threading.Thread.Sleep(5000);

            IWebElement projectsNavigation = driver.FindElement(By.XPath("//*[@id='accordionSidenav']/a[2]"));
            projectsNavigation.Click();

            System.Threading.Thread.Sleep(5000);

            Assert.That(driver.Url, Is.EqualTo("https://workflowui.azurewebsites.net/projects-list"));
        }

        [Test, Order(4)]
        public void Dashboard_ClickOnNavbar_NavigateToChat()
        {
            driver.Navigate().GoToUrl(URL + "login");
            driver.Manage().Window.Maximize();

            IWebElement loginInput = driver.FindElement(By.XPath("//*[@id='layoutAuthentication_content']/main/div/div[2]/div/div/div[2]/form/div[1]/input"));
            loginInput.SendKeys(login);

            IWebElement passwordInput = driver.FindElement(By.XPath("//*[@id='layoutAuthentication_content']/main/div/div[2]/div/div/div[2]/form/div[2]/input"));
            passwordInput.SendKeys("SeleniumPassword1");

            passwordInput.Submit();

            System.Threading.Thread.Sleep(5000);

            IWebElement projectsNavigation = driver.FindElement(By.XPath("//*[@id='accordionSidenav']/a[3]"));
            projectsNavigation.Click();

            System.Threading.Thread.Sleep(5000);

            Assert.That(driver.Url, Is.EqualTo("https://workflowui.azurewebsites.net/chat"));
        }

        //[Test, Order(5)]
        //public void Dashboard_ClickOnNavbar_NavigateToDocumentation()
        //{
        //    driver.Navigate().GoToUrl(URL + "login");
        //    driver.Manage().Window.Maximize();

        //    IWebElement loginInput = driver.FindElement(By.XPath("//*[@id='layoutAuthentication_content']/main/div/div[2]/div/div/div[2]/form/div[1]/input"));
        //    loginInput.SendKeys(login);

        //    IWebElement passwordInput = driver.FindElement(By.XPath("//*[@id='layoutAuthentication_content']/main/div/div[2]/div/div/div[2]/form/div[2]/input"));
        //    passwordInput.SendKeys("SeleniumPassword1");

        //    passwordInput.Submit();

        //    System.Threading.Thread.Sleep(5000);

        //    IWebElement projectsNavigation = driver.FindElement(By.XPath("//*[@id='accordionSidenav']/a[4]"));
        //    projectsNavigation.Click();

        //    System.Threading.Thread.Sleep(5000);

        //    Assert.That(driver.Url, Is.EqualTo("https://projektygrupowe.github.io/index.html"));
        //}

        [Test, Order(6)]
        public void Dashboard_ClickOnNavbar_NavigateToContact()
        {
            driver.Navigate().GoToUrl(URL + "login");
            driver.Manage().Window.Maximize();

            IWebElement loginInput = driver.FindElement(By.XPath("//*[@id='layoutAuthentication_content']/main/div/div[2]/div/div/div[2]/form/div[1]/input"));
            loginInput.SendKeys(login);

            IWebElement passwordInput = driver.FindElement(By.XPath("//*[@id='layoutAuthentication_content']/main/div/div[2]/div/div/div[2]/form/div[2]/input"));
            passwordInput.SendKeys("SeleniumPassword1");

            passwordInput.Submit();

            System.Threading.Thread.Sleep(5000);

            IWebElement projectsNavigation = driver.FindElement(By.XPath("//*[@id='accordionSidenav']/a[5]"));
            projectsNavigation.Click();

            System.Threading.Thread.Sleep(5000);

            Assert.That(driver.Url, Is.EqualTo("https://workflowui.azurewebsites.net/contact"));
        }

        [Test, Order(7)]
        public void Dashboard_ClickOnNavbar_NavigateToSupport()
        {
            driver.Navigate().GoToUrl(URL + "login");
            driver.Manage().Window.Maximize();

            IWebElement loginInput = driver.FindElement(By.XPath("//*[@id='layoutAuthentication_content']/main/div/div[2]/div/div/div[2]/form/div[1]/input"));
            loginInput.SendKeys(login);

            IWebElement passwordInput = driver.FindElement(By.XPath("//*[@id='layoutAuthentication_content']/main/div/div[2]/div/div/div[2]/form/div[2]/input"));
            passwordInput.SendKeys("SeleniumPassword1");

            passwordInput.Submit();

            System.Threading.Thread.Sleep(5000);

            IWebElement projectsNavigation = driver.FindElement(By.XPath("//*[@id='accordionSidenav']/a[6]"));
            projectsNavigation.Click();

            System.Threading.Thread.Sleep(5000);

            Assert.That(driver.Url, Is.EqualTo("https://workflowui.azurewebsites.net/support"));
        }

        [Test, Order(8)]
        public void Dashboard_ClickOnAddProject_AddProject()
        {
            driver.Navigate().GoToUrl(URL + "login");
            driver.Manage().Window.Maximize();

            IWebElement loginInput = driver.FindElement(By.XPath("//*[@id='layoutAuthentication_content']/main/div/div[2]/div/div/div[2]/form/div[1]/input"));
            loginInput.SendKeys(login);

            IWebElement passwordInput = driver.FindElement(By.XPath("//*[@id='layoutAuthentication_content']/main/div/div[2]/div/div/div[2]/form/div[2]/input"));
            passwordInput.SendKeys("SeleniumPassword1");

            passwordInput.Submit();

            System.Threading.Thread.Sleep(5000);

            IWebElement addProjectButton = driver.FindElement(By.XPath("//*[@id='overviewPill']/div/button"));
            addProjectButton.Click();

            System.Threading.Thread.Sleep(5000);

            IWebElement projectName = driver.FindElement(By.XPath("//*[@id='exampleModalCenter']/div/div/div[2]/form/div[1]/input"));
            projectName.SendKeys("Test Project 2");
            projectName.Submit();

            System.Threading.Thread.Sleep(5000);

            IWebElement closeButton = driver.FindElement(By.XPath("//*[@id='exampleModalCenter']/div/div/div[2]/form/div[2]/button[1]"));
            closeButton.Click();

            System.Threading.Thread.Sleep(5000);

            Assert.That(driver.Url, Is.EqualTo("https://workflowui.azurewebsites.net/projects-list"));
        }
    }
}

