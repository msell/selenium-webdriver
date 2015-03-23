using System;
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
                var query = _driver.FindElement(By.Name("email"));
                query.SendKeys("cookieMonster");
                _error = _driver.FindElementByXPath("//p").Text;                                               
            };

            It should_display_email_error = () =>
            {
                _error.Should().Contain("Email is invalid");
                _driver.GetScreenshot().SaveAsFile("invalidEmail.png", ImageFormat.Png);
            };
            static IWebElement _emailError;
            static string _error;
        }

        public class when_user_enters_valid_email
        {
            It should_not_display_email_error;
        }

        public class when_user_has_password_missmatch
        {
            It should_display_missmatch_error;
        }

        static readonly string url = "http://quickstart-frontend.herokuapp.com/#/register";
        static FirefoxDriver _driver;
    }
}
