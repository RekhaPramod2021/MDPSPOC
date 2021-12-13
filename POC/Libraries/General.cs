using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;


namespace POC.Libraries
{
    public class General:Constants
    {
        public Process Process { get; set; }
        public bool Bstatus { get; set; }
        public static WindowsDriver<WindowsElement> Session { get; set; }

        public void IBW5Login(string appName, string cortonaAppname, string appIdentify, string userlevel)
        {
            ////    To start WinappDriver process
            TestInitialization();

            ////    Launching of IBW apps
            bool status = LaunchIbwApps(appName, appIdentify);

            ////    Login to application
            if (status)
                Login(userlevel);
        }
        public void TestInitialization()
        {
            Process = Process.Start("C:\\Program Files (x86)\\Windows Application Driver\\WinAppDriver.exe");
        }
        public bool LaunchIbwApps(string appName, string appIdentify)
        {
            return LaunchApplication(appName, appIdentify, 4);
        }
        public void Login(string userType)
        {
           
            string username ="auto1";
            string password = "P@ssword2";
            Session.FindElementByName("LoginUserId").Clear();
            Session.FindElementByName("LoginUserId").SendKeys(username);
            Session.FindElementByName("LoginPassword").Clear();
            Session.FindElementByName("LoginPassword").SendKeys(password);
            actionTobeDone("Enter");
                         
        }
        public bool IsElementPresent(string element, int count)
        {
            for (int i = 0; i < count; i++)
            {
                try
                {
                    // Thread.Sleep(5);
                    Session.FindElementByName(element).Click();
                    Bstatus = true;
                    break;
                }
                catch
                {
                    Bstatus = false;
                }
            }
            return Bstatus;
        }
        public bool LaunchApplication(string appName, string appIdentify, int count)
        {
            Launch(appName);
            for (int i = 0; i <= count; i++)
            {
                try
                {
                    try
                    {
                        if (Session.FindElementByName(appIdentify).Displayed)
                        {
                            break;
                        }
                    }
                    catch
                    {
                        if (Session.FindElementByName("LoginUserId").Displayed)

                        {
                            break;
                        }
                    }
                }
                catch
                {
                    Thread.Sleep(1000);
                }
            }

            bool isPresent = IsElementPresent(appIdentify, 2);

            return !isPresent;
        }
        public void actionTobeDone(string key)
        {
            Actions actions = new Actions(Session);
            switch (key)
            {
                case "Enter":
                    {
                        actions.SendKeys(Keys.Enter).Build().Perform();
                        break;
                    }
                case "Delete":
                    {
                        actions.SendKeys(Keys.Delete).Build().Perform();
                        break;
                    }
                case "Tab":
                    {
                        actions.SendKeys(Keys.Tab).Build().Perform();
                        break;
                    }
                case "PageUp":
                    {
                        actions.SendKeys(Keys.PageUp).Build().Perform();
                        break;
                    }
                case "PageDown":
                    {
                        actions.SendKeys(Keys.PageDown).Build().Perform();
                        break;
                    }
                case "Backspace":
                    {
                        actions.SendKeys(Keys.Backspace).Build().Perform();
                        break;
                    }
                case "ArrowUp":
                    {
                        actions.SendKeys(Keys.ArrowUp).Build().Perform();
                        break;
                    }
                case "ArrowDown":
                    {
                        actions.SendKeys(Keys.ArrowDown).Build().Perform();
                        break;
                    }
                default:
                    {
                        actions.SendKeys(key).Build().Perform();
                        break;
                    }
            }

        }
        public void Launch(string appName)
        {
            try
            {
                AppiumOptions appCapabilities = new AppiumOptions();
                appCapabilities.AddAdditionalCapability("app", appName);
                appCapabilities.AddAdditionalCapability("deviceName", "WindowsPC");
                Thread.Sleep(15000);
                Session = new WindowsDriver<WindowsElement>(new Uri(WINAPPDRIVERPATH), appCapabilities);
                Session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                Thread.Sleep(15000);
                try { Session.Manage().Window.Maximize(); } catch { }
            }
            catch
            {
                AppiumOptions appCapabilities = new AppiumOptions();
                appCapabilities.AddAdditionalCapability("app", appName);
                appCapabilities.AddAdditionalCapability("deviceName", "WindowsPC");

                Session = new WindowsDriver<WindowsElement>(new Uri(WINAPPDRIVERPATH), appCapabilities);
                Session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                Thread.Sleep(15000);
                try { Session.Manage().Window.Maximize(); } catch { }
            }
        }
    }
}
