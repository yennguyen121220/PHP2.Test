using OpenQA.Selenium;
using AssetManagement.Library;
using AssetManagement.Test;

namespace AssetManagement.Pages
{
    public class HomePage
    {
        //Web Elements

        private WebObject _managaUserLink = new WebObject(By.XPath("//span[text()='Manage User']"), "Manage User Link");
        private WebObject _manageUserButton = new WebObject(By.XPath("//span[@class='ant-menu-title-content'][normalize-space()='Manage User']"), "Manage User Tab");

        //Contructor
        public HomePage() { }

        //Page Methods

        public void ClickManageUSerLink()
        {
            DriverUtils.ClickOnElement(_managaUserLink);
        }

        public void VisitHomePage()
        {
            DriverUtils.GoToUrl(ConfigurationHelper.GetConfigurationByKey("TestURL"));
        }
        public void ChoosingManageUser()
        {
            DriverUtils.ClickOnElement(_manageUserButton);
        }
    }
}