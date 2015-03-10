using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Machine.Specifications;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace demo
{
    public class ScreenshotRemoteWebDriver : RemoteWebDriver, ITakesScreenshot
    {
        public ScreenshotRemoteWebDriver(Uri address, ICapabilities capabilities)
            : base(address, capabilities)
        {
        }

        public Screenshot GetScreenshot()
        {
            var screenshotResponse = Execute(DriverCommand.Screenshot, null);
            var base64 = screenshotResponse.Value.ToString();

            return new Screenshot(base64);
        }
    }
    public abstract class SeleniumSpecs
    {
        internal static ScreenshotRemoteWebDriver Selenium;

        Establish context = () =>
        {
            Selenium = new ScreenshotRemoteWebDriver(new Uri("http://localhost:9515/"), DesiredCapabilities.Chrome());           
        };

        Cleanup after =
            () => Selenium.Close();
    }
    public class describe_user_registration
    {
        public class when_user_enters_invalid_email : SeleniumSpecs
        {
            Establish context = () =>
            {
                Selenium.Navigate().GoToUrl(url);
                Selenium.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
            };

            Because of = () =>
            {
                var query = Selenium.FindElement(By.Name("email"));
                query.SendKeys("cookieMonster");
                _error = Selenium.FindElementByXPath("//p").Text;                                               
            };

            It should_display_email_error = () =>
            {
                _error.Should().Contain("Email is invalid");

                Selenium.GetScreenshot().SaveAsFile("invalidEmail.png", ImageFormat.Png);
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
    }
}
