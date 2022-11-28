using NUnit.Framework;
using AssetManagement.Pages;
using System;

namespace AssetManagement.Test
{
    public class Login : BaseTest
    {
        private HomePage _homePage = new HomePage();
        private LoginPage _loginPage = new LoginPage();

        [TestCase("adminHCM", "321321321"), Description("Log in with invalid email or password using parameter")]
        [Category("Regression")]
        public void LoginSucessfullyWithValidAccount(string username, string password)
        {
            _homePage.VisitHomePage();
            _loginPage.Login(username, password);
            Console.WriteLine("Test Login With Valid Account Using Parameters");
            Assert.That(_loginPage.GetMessageLoginSuccessfully().Trim(), Is.EqualTo("Home"));
        }

        [TestCase("adminHCM", "1234567890"), Description("Log in with invalid email or password using parameter")]
        [Category("Regression")]
        public void LoginUnsucessfullyIfAccountIsInvalid(string username, string password)
        {
            Console.WriteLine("Test Login With Invalid Account Using Parameters");
            _homePage.VisitHomePage();
            _loginPage.Login(username, password);
            Assert.That(_loginPage.GetMessageErrorText().Trim(), Is.EqualTo("Username or password is incorrect. Please try again"));
        }

        [TestCase("ad", "123"), Description("Log in with invalid format email/password using parameter")]
        [Category("Regression")]
        public void LoginUnsucessfullyIfAccountInvalidFormat(string username, string password)
        {
            Console.WriteLine("Test Login With Invalid Account Using Parameters");
            _homePage.VisitHomePage();
            _loginPage.Login(username, password);
            Assert.That(_loginPage.GetMessageErrorPassword().Trim(), Is.EqualTo("Password must be at least 8 characters"));
            Assert.That(_loginPage.GetMessageErrorUserName().Trim(), Is.EqualTo("Username must be at least 3 characters"));
        }

        [TestCase("AliceBrown435", "password"), Description("requiring change password popup at the first time log in successfully")]
        [Category("Regression")]
        public void LoginSuccessfullyAtTheFirstTime(string username, string password)
        {
            Console.WriteLine("Test Login With Invalid Account Using Parameters");
            _homePage.VisitHomePage();
            _loginPage.Login(username, password);
            Assert.That(_loginPage.GetMessageLoginTheFirstTime().Trim(), Is.EqualTo("Change password"));
        }

    }
}