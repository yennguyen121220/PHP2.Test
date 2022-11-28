using OpenQA.Selenium;
using AssetManagement.Library;

namespace AssetManagement.Pages
{
    public class LoginPage
    {
        //Web Elements
        private WebObject _usernameTextbox = new WebObject(By.CssSelector("input#basic_username"), "Username Textbox");
        private WebObject _passwordTextbox = new WebObject(By.Id("basic_password"), "Password Textbox");
        private WebObject _loginButton = new WebObject(By.XPath("//button[@type='submit']"), "Log in Button");
        private WebObject _errorMessageLabel = new WebObject(By.XPath("//p[@style]"), "Error Messsage Label");
        private WebObject _errorMessageUsername = new WebObject(By.CssSelector("#basic_username_help .ant-form-item-explain-error"), "Error Username Message");
        private WebObject _errorMessagePassword = new WebObject(By.CssSelector("#basic_password_help .ant-form-item-explain-error"), "Error Password Message");
        //Contructor
        public LoginPage() { }

        //Page Methods
        public void Login(string username, string password)
        {
            DriverUtils.EnterText(_usernameTextbox, username);
            DriverUtils.EnterText(_passwordTextbox, password);
            DriverUtils.ClickOnElement(_loginButton);
        }

        public string GetMessageErrorText()
        {
            return DriverUtils.GetTextFromElement(_errorMessageLabel);
        }
        public string GetMessageErrorUserName()
        {
            return DriverUtils.GetTextFromElement(_errorMessageUsername);
        }
        public string GetMessageErrorPassword()
        {
            return DriverUtils.GetTextFromElement(_errorMessagePassword);
        }
    }
}