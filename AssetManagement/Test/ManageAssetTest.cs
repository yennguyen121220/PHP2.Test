using System.Runtime.CompilerServices;
using System.Threading;
using System;
using AssetManagement.Pages;
using NUnit.Framework;

namespace AssetManagement.Test
{
    public class ManageAssetTest:BaseTest
    {
        private HomePage _homePage = new HomePage();
        private LoginPage _loginPage = new LoginPage();
        private ManageAssetPage _manageAssetPage = new ManageAssetPage();

        [TestCase("adminHCM", "321321321", "Do Not Delete123"), Description("Search Successfully With Valid Value")]
        [TestCase("adminHCM", "321321321", "Do Not Delete")]
        [TestCase("adminHCM", "321321321", "DE000204")]
        [Category("Regression")]
        public void SearchSuccessfullyWithValidValues(string username, string password, string assetCode)
        {
            _homePage.VisitHomePage();
            _loginPage.Login(username, password);
            _homePage.ClickManageAssetLink();
            Thread.Sleep(2000);
            _manageAssetPage.EnterSearchValue(assetCode);
            bool isElementDisplayed = _manageAssetPage.IfSearchValueExist();
            if(isElementDisplayed==true && _manageAssetPage.GetAssetCodeValue().Contains(assetCode))
            {
                Assert.That(_manageAssetPage.GetAssetCodeValue().Trim().Contains(assetCode));
            } 
            else 
            {
                if(isElementDisplayed==true && _manageAssetPage.GetAssetNameValue().Contains(assetCode))
                    Assert.That(_manageAssetPage.GetAssetNameValue().Trim().Contains(assetCode));
                else 
                    if(isElementDisplayed==false)
                        Assert.That(_manageAssetPage.GetErrorMessageNotFound().Trim(), Is.EqualTo("No result was found"));
            }
        }


        [TestCase("adminHCM", "321321321", "DE000204"), Description("Search Successfully With Valid Asset Code")]
        [Category("Regression")]
        public void SearchSuccessfullyWithValidAssetCode(string username, string password, string assetCode)
        {
            _homePage.VisitHomePage();
            _loginPage.Login(username, password);
            _homePage.ClickManageAssetLink();
            Thread.Sleep(2000);
            _manageAssetPage.EnterSearchValue(assetCode);
            Assert.That(_manageAssetPage.GetAssetCodeValue().Trim(), Is.EqualTo(assetCode));
        }

        

        [TestCase("adminHCM", "321321321", "Auto Test Do Not Delete"), Description("Search Successfully With Valid Asset Name")]
        [Category("Regression")]
        public void SearchSuccessfullyWithValidAssetName(string username, string password, string assetName)
        {
            _homePage.VisitHomePage();
            _loginPage.Login(username, password);
            _homePage.ClickManageAssetLink();            
            Thread.Sleep(1000);
            _manageAssetPage.EnterSearchValue(assetName);
            Assert.That(_manageAssetPage.GetAssetNameValue().Trim(), Is.EqualTo(assetName));
        }

        [TestCase("adminHCM", "321321321", "DE0002041"), Description("Search Successfully With Value Not Found")]
        [Category("Regression")]
        public void SearchUnsucessfullyWithNotFoundValue(string username, string password, string assetCode)
        {
            _homePage.VisitHomePage();
            _loginPage.Login(username, password);
            Console.WriteLine("Test Search With Valid Staff's name");
            _homePage.ClickManageUserLink();
            Thread.Sleep(1000);
            _manageAssetPage.EnterSearchValue(assetCode);
            Assert.That(_manageAssetPage.GetErrorMessageNotFound().Trim(), Is.EqualTo("No result was found"));
        }

    }
}