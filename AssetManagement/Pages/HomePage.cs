using OpenQA.Selenium;
using AssetManagement.Library;
using AssetManagement.Test;

namespace AssetManagement.Pages
{
    public class HomePage
    {
        //Web Elements

        private WebObject _managaUserLink = new WebObject(By.XPath("//span[text()='Manage User']"), "Manage User Link");

        //Contructor
        public HomePage() { }

        //Page Methods

        public void ClickManageUserLink()
        {
            DriverUtils.ClickOnElement(_managaUserLink);
        }

        public void VisitHomePage()
        {
            DriverUtils.GoToUrl(ConfigurationHelper.GetConfigurationByKey("TestURL"));
        }
    }
}