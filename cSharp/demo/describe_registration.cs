using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Machine.Specifications;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace demo
{
    public class describe_user_registration
    {
        Establish context = () =>
        {
            _driver = new FirefoxDriver();
        };

        Cleanup teardown = () => _driver.Quit();
        
        public class when_user_enters_invalid_email
        {
            Establish context = () =>
            {
                _driver.Navigate().GoToUrl(url);
                _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
            };

            Because of = () =>
            {
                var query = _driver.FindElement(By.Id("UserName"));
                query.SendKeys("cookieMonster");
                query.Submit();
                _error = _driver.FindElementById("message").Text;
            };

            It should_display_email_error = () =>
            {
                _error.Should().Contain("Your Username or Password are incorrect.");
                _driver.GetScreenshot().SaveAsFile("invalidEmail.png", ImageFormat.Png);
            };
            static IWebElement _emailError;
            static string _error;
        }

        public class when_searching_for_events
        {
            Establish context = () =>
            {
                _driver.Navigate().GoToUrl(url);
                _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));
            };

            Because of = () =>
            {
                var username = _driver.FindElement(By.Id("UserName"));
                username.SendKeys(_username);

                var password = _driver.FindElementById("Password");
                password.SendKeys(_password);

                password.Submit();
                
                var search = _driver.FindElementByCssSelector(".button.primary");
                search.Click();

                _events = _driver.FindElementsByCssSelector(".item.event-item");
            };
            It should_find_some_events = () => _events.Count.Should().Be(2);

            static IReadOnlyCollection<IWebElement> _events;
        }


        static readonly string url = "http://10.1.104.13:8088/";
        static FirefoxDriver _driver;
        static string _username = "wgvadmin";
        static string _password = "Pass@word1";
    }
}
