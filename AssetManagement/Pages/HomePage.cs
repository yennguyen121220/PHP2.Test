using OpenQA.Selenium;
using AssetManagement.Library;
using AssetManagement.Test;

namespace AssetManagement.Pages
{
    public class HomePage
    {
        //Web Elements

        private WebObject _btnManagaUserLink = new WebObject(By.XPath("//span[text()='Manage User']"), "Manage User Link");
        private WebObject _btnManageAssetLink = new WebObject(By.XPath("//span[text()='Manage Asset']"), "Manage Asset Link");
        private WebObject _btnCreateAsset = new WebObject(By.CssSelector("button.ams__button"), "Create Asset Link");

        //Contructor
        public HomePage() { }

        //Page Methods

        public void ClickManageUserLink()
        {
            DriverUtils.ClickOnElement(_btnManagaUserLink);
        }

        public void ClickManageAssetLink()
        {
            DriverUtils.ClickOnElement(_btnManageAssetLink);
        }

        public void ClickCreateAssetButton()
        {
            DriverUtils.ClickOnElement(_btnCreateAsset);
        }


        public void VisitHomePage()
        {
            DriverUtils.GoToUrl(ConfigurationHelper.GetConfigurationByKey("TestURL"));
        }
    }
}