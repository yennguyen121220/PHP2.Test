using OpenQA.Selenium;
using AssetManagement.Library;

namespace AssetManagement.Pages
{
    public class LoginAssetManagerPage
    {
        private WebObject _usernametextbox = new WebObject(By.Id("basic_username"), "User Name Textbox");
        private WebObject _passwordtextbox = new WebObject(By.Id("basic_password"), "Password Textbox");
        private WebObject _loginbutton = new WebObject(By.XPath("//button[@type='submit']"), "Login Button");
        string UrlFormPage = "https://ams-app-2.azurewebsites.net/";
        //Contructor
        public LoginAssetManagerPage ()  { }

        //Page Methods
        public void VisitHomePage()
        {
            DriverUtils.GoToUrl(UrlFormPage);
        }
        public void LoginAssetManager(string userName, string password)
        {
            DriverUtils.EnterText(_usernametextbox, userName);
            DriverUtils.EnterText(_passwordtextbox, password);
            DriverUtils.ClickOnElement(_loginbutton);
        }
    }
}