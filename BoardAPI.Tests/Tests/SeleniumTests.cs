/* 
 * Copyright (C) Work-FLow, All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Łukasz Szafrański <lukasz.szafranski16@wp.pl>, Krzysztof Łepkowski, Szymon Lewandowski, May 2020
 */

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

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
            login = "TestSelenium13";

            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
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
        public void LoginTest_SendCorrectInformations_LoggedInAndLoggedOut()
        {
            driver.Navigate().GoToUrl(URL + "login");
            driver.Manage().Window.Maximize();

            IWebElement loginInput = driver.FindElement(By.XPath("//*[@id='layoutAuthentication_content']/main/div/div[2]/div/div/div[2]/form/div[1]/input"));
            loginInput.SendKeys(login);

            IWebElement passwordInput = driver.FindElement(By.XPath("//*[@id='layoutAuthentication_content']/main/div/div[2]/div/div/div[2]/form/div[2]/input"));
            passwordInput.SendKeys("SeleniumPassword1");
            passwordInput.Submit();

            System.Threading.Thread.Sleep(10000);

            IWebElement user = driver.FindElement(By.XPath("//*[@id='navbarDropdownUserImage']"));
            user.Click();

            System.Threading.Thread.Sleep(5000);

            IWebElement logout = driver.FindElement(By.XPath("//*[@id='sidenavAccordion']/ul/li/div/a[2]"));
            logout.Click();

            System.Threading.Thread.Sleep(5000);

            Assert.That(driver.Url, Is.EqualTo("https://workflowui.azurewebsites.net/login"));
        }

        [Test, Order(4)]
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

        [Test, Order(5)]
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

        [Test, Order(6)]
        public void Dashboard_ClickOnNavbar_NavigateToDocumentation()
        {
            driver.Navigate().GoToUrl(URL + "login");
            driver.Manage().Window.Maximize();

            IWebElement loginInput = driver.FindElement(By.XPath("//*[@id='layoutAuthentication_content']/main/div/div[2]/div/div/div[2]/form/div[1]/input"));
            loginInput.SendKeys(login);

            IWebElement passwordInput = driver.FindElement(By.XPath("//*[@id='layoutAuthentication_content']/main/div/div[2]/div/div/div[2]/form/div[2]/input"));
            passwordInput.SendKeys("SeleniumPassword1");

            passwordInput.Submit();

            System.Threading.Thread.Sleep(5000);

            IWebElement projectsNavigation = driver.FindElement(By.XPath("//*[@id='accordionSidenav']/a[4]"));
            projectsNavigation.Click();

            System.Threading.Thread.Sleep(5000);

            Assert.That(driver.Url, Is.EqualTo("https://projektygrupowe.github.io/index.html"));
        }

        [Test, Order(7)]
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

        [Test, Order(8)]
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

        [Test, Order(9)]
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

            Assert.That(driver.Url, Is.EqualTo("https://workflowui.azurewebsites.net/projects-list"));
        }

        [Test, Order(10)]
        public void Dashboard_GoToProjectList_ClickOnProject()
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

            IWebElement project = driver.FindElement(By.XPath("//*[@id='layoutSidenav_content']/main/app-projects-list/div[2]/div/div[1]/div/div/div/h5/a"));
            project.Click();

            System.Threading.Thread.Sleep(5000);

            Assert.That(driver.Url, Is.EqualTo("https://workflowui.azurewebsites.net/project/1"));
        }

        [Test, Order(11)]
        public void Dashboard_GoToProjectListClickOnProject_EditTitleAndMakeSureThatCorrectWasSet()
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

            IWebElement project = driver.FindElement(By.XPath("//*[@id='layoutSidenav_content']/main/app-projects-list/div[2]/div/div[1]/div/div/div/h5/a"));
            project.Click();

            System.Threading.Thread.Sleep(5000);

            IWebElement editTitle = driver.FindElement(By.XPath("//*[@id='layoutSidenav_content']/main/app-project/div[1]/div/div/h1/button[1]"));
            editTitle.Click();

            System.Threading.Thread.Sleep(5000);

            IWebElement titleInput = driver.FindElement(By.XPath("//*[@id='editProjectModal']/div/div/div[2]/form/div[1]/input"));
            titleInput.Clear();
            titleInput.SendKeys("TestowyProjektSelenium1");
            titleInput.Submit();

            System.Threading.Thread.Sleep(5000);

            IWebElement title = driver.FindElement(By.XPath("//*[@id='layoutSidenav_content']/main/app-project/div[1]/div/div/h1/span"));

            System.Threading.Thread.Sleep(5000);

            Assert.That(title.Text, Is.EqualTo("TestowyProjektSelenium1"));
        }

        [Test, Order(12)]
        public void Dashboard_GoToProjectListClickOnProject_AddTaskAndMakeSureThatCorrectWasSet()
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

            IWebElement project = driver.FindElement(By.XPath("//*[@id='layoutSidenav_content']/main/app-projects-list/div[2]/div/div[1]/div/div/div/h5/a"));
            project.Click();

            System.Threading.Thread.Sleep(5000);

            IWebElement addTask = driver.FindElement(By.XPath("//*[@id='1']/button"));
            addTask.Click();

            System.Threading.Thread.Sleep(5000);

            IWebElement taskName = driver.FindElement(By.XPath("//*[@id='taskModal']/div/div/div[2]/form/div[1]/input"));
            taskName.Clear();
            taskName.SendKeys("TestowyTaskSelenium");
            taskName.Submit();

            System.Threading.Thread.Sleep(5000);

            IWebElement newTask = driver.FindElement(By.XPath("//*[@id='1']/div[1]/div[2]"));

            System.Threading.Thread.Sleep(5000);

            Assert.That(newTask.Text, Is.EqualTo("TestowyTaskSelenium            "));
        }

        [Test, Order(13)]
        public void Dashboard_GoToProjectListClickOnProject_AddColumnAndMakeSureThatCorrectWasSet()
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

            IWebElement project = driver.FindElement(By.XPath("//*[@id='layoutSidenav_content']/main/app-projects-list/div[2]/div/div[1]/div/div/div/h5/a"));
            project.Click();

            System.Threading.Thread.Sleep(5000);

            IWebElement addColumn = driver.FindElement(By.XPath("//*[@id='layoutSidenav_content']/main/app-project/div[2]/div/button"));
            addColumn.Click();

            System.Threading.Thread.Sleep(5000);

            IWebElement columnName = driver.FindElement(By.XPath("//*[@id='columnModal']/div/div/div[2]/form/div[1]/input"));
            columnName.Clear();
            columnName.SendKeys("TestColumn");
            columnName.Submit();

            System.Threading.Thread.Sleep(5000);

            IWebElement newColumn = driver.FindElement(By.XPath("//*[@id='cdk-drop-list-0']/div[4]/div/div/div[1]"));

            System.Threading.Thread.Sleep(5000);

            Assert.That(newColumn.Text, Is.EqualTo("TestColumn            "));
        }

        [Test, Order(14)]
        public void Dashboard_GoToProjectListClickOnProject_EditColumnAndMakeSureThatCorrectWasSet()
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

            IWebElement project = driver.FindElement(By.XPath("//*[@id='layoutSidenav_content']/main/app-projects-list/div[2]/div/div[1]/div/div/div/h5/a"));
            project.Click();

            System.Threading.Thread.Sleep(5000);

            IWebElement columnEdit = driver.FindElement(By.XPath("//*[@id='cdk-drop-list-0']/div[1]/div/div/div[1]/button[1]"));
            columnEdit.Click();

            System.Threading.Thread.Sleep(5000);

            IWebElement columnName = driver.FindElement(By.XPath("//*[@id='editColumnModal']/div/div/div[2]/form/div[1]/input"));
            columnName.Clear();
            columnName.SendKeys("Selenium");
            columnName.Submit();

            System.Threading.Thread.Sleep(10000);

            IWebElement newColumn = driver.FindElement(By.XPath("//*[@id='cdk-drop-list-0']/div[1]/div/div/div[1]"));

            System.Threading.Thread.Sleep(5000);

            Assert.That(newColumn.Text.Contains("Selenium            "));
        }

        [Test, Order(14)]
        public void Dashboard_GoToProjectListClickOnProject_EditTaskAndMakeSureThatCorrectWasSet()
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

            IWebElement project = driver.FindElement(By.XPath("//*[@id='layoutSidenav_content']/main/app-projects-list/div[2]/div/div[1]/div/div/div/h5/a"));
            project.Click();

            System.Threading.Thread.Sleep(5000);

            IWebElement taskEdit = driver.FindElement(By.XPath("//*[@id='1']/div[1]/div[1]/button[1]"));
            taskEdit.Click();

            System.Threading.Thread.Sleep(5000);

            IWebElement taskName = driver.FindElement(By.XPath("//*[@id='editTaskModal']/div/div/div[2]/form/div[1]/input"));
            taskName.Clear();
            taskName.SendKeys("SeleniumTask");
            taskName.Submit();

            System.Threading.Thread.Sleep(10000);

            IWebElement newTask = driver.FindElement(By.XPath("//*[@id='1']/div[1]/div[1]"));

            System.Threading.Thread.Sleep(5000);

            Assert.That(newTask.Text.Contains("SeleniumTask            "));
        }
    }
}

