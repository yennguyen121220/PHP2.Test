using System.Threading;
using System;
using AssetManagement.Pages;
using NUnit.Framework;

namespace AssetManagement.Test
{
    public class ManageUserTest : BaseTest
    {
        private HomePage _homePage = new HomePage();
        private LoginPage _loginPage = new LoginPage();
        private ManageUserPage _manageUserPage = new ManageUserPage();

        [Test, Description("Filter By Admin Type")]
        [Category("Regression")]
        public void FilterByAdminTypeSuccessfully()
        {
            _homePage.VisitHomePage();
            _loginPage.Login("adminHCM", "321321321");
            _manageUserPage.ManageUser();
            _manageUserPage.ClickOnAdminOption();
            _manageUserPage.VerifyFilteredByAdmin();
        }

        [Test, Description("Filter By Staff Type")]
        [Category("Regression")]
        public void FilterByStaffTypeSuccessfully()
        {
            _homePage.VisitHomePage();
            _loginPage.Login("adminHCM", "321321321");
            _manageUserPage.ManageUser();
            _manageUserPage.ClickOnStaffOption();
            _manageUserPage.VerifyFilteredByStaff();
        }

        // =========Search=======

        // [TestCase("adminHCM", "321321321", "Do Not Delete123"), Description("Search Successfully With Valid Value")]
        // [TestCase("adminHCM", "321321321", "Do Not Delete")]
        // [TestCase("adminHCM", "321321321", "DE000038")]
        // [Category("Regression")]
        // public void SearchSuccessfullyWithValidValues(string username, string password, string assetCode)
        // {
        //     _homePage.VisitHomePage();
        //     _loginPage.Login(username, password);
        //     _homePage.ClickManageAssetLink();
        //     Thread.Sleep(2000);
        //     _manageUserPage.EnterSearchValue(assetCode);
        //     bool isElementDisplayed = _manageUserPage.IfSearchValueExist();
        //     if(isElementDisplayed==true && _manageUserPage.GetStaffCodeText().Equals(assetCode))
        //     {
        //         Assert.That(_manageUserPage.GetStaffCodeText().Trim(), Is.EqualTo(assetCode));
        //     } 
        //     else 
        //     {
        //         if(isElementDisplayed==true && _manageUserPage.GetAssetNameValue().Equals(assetCode))
        //             Assert.That(_manageUserPage.GetAssetNameValue().Trim(), Is.EqualTo(assetCode));
        //         else 
        //             if(isElementDisplayed==false)
        //                 Assert.That(_manageUserPage.GetErrorMessageNotFound().Trim(), Is.EqualTo("No result was found"));
        //     }
        // }


        // [TestCase("adminHCM", "321321321", "SD0012"), Description("Search Successfully With Valid Value")]
        // [TestCase("adminHCM", "321321321", "Jane Jones")]
        [TestCase("adminHCM", "321321321", "SD00121234")]
        [Category("Regression")]
        public void SearchSuccessfullyWithValidValues(string username, string password, string assetCode)
        {
            _homePage.VisitHomePage();
            _loginPage.Login(username, password);
            _homePage.ClickManageUserLink();
            Thread.Sleep(2000);
            _manageUserPage.EnterSearchValue(assetCode);
            bool isElementDisplayed = _manageUserPage.IfSearchValueExist();
            if(isElementDisplayed==true && _manageUserPage.GetStaffCodeText().Contains(assetCode))
            {
                Assert.That(_manageUserPage.GetStaffCodeText().Trim().Contains(assetCode));
            } 
            else 
            {
                if(isElementDisplayed==true && _manageUserPage.GetStaffNameText().Contains(assetCode))
                    Assert.That(_manageUserPage.GetStaffNameText().Trim().Contains(assetCode));
                else 
                    if(isElementDisplayed==false)
                        Assert.That(_manageUserPage.GetErrorMessageNotFound().Trim(), Is.EqualTo("No result was found"));
            }
        }


        [TestCase("adminHCM", "321321321", "SD0012"), Description("Search successfully with valid staff code")]
        [Category("SmokeTest")]
        [Category("Regression")]
        public void SearchSuccessfullyWithValidStaffCode(string username, string password, string staffcode)
        {
            _homePage.VisitHomePage();
            _loginPage.Login(username, password);
            _homePage.ClickManageUserLink();
            _manageUserPage.EnterSearchValue(staffcode);
            Assert.That(_manageUserPage.GetStaffCodeText().Trim(), Is.EqualTo(staffcode));
        }

        [TestCase("adminHCM", "321321321", "Jane Jones"), Description("Search successfully with valid staff's name")]
        [Category("Regression")]
        [Category("SmokeTest")]
        public void SearchsucessfullyWithValidStaffName(string username, string password, string staffname)
        {
            _homePage.VisitHomePage();
            _loginPage.Login(username, password);
            _homePage.ClickManageUserLink();
            Thread.Sleep(1000);
            _manageUserPage.EnterSearchValue(staffname);
            Assert.That(_manageUserPage.GetStaffNameText().Trim(), Is.EqualTo(staffname));
        }

        [TestCase("adminHCM", "321321321", "qwertyu"), Description("Search successfully with valid staff's name")]
        [Category("Regression")]
        [Category("SmokeTest")]
        public void SearchUnsucessfullyWithNotFoundStaffCode(string username, string password, string staffcode)
        {
            _homePage.VisitHomePage();
            _loginPage.Login(username, password);
            Console.WriteLine("Test Search With Valid Staff's name");
            _homePage.ClickManageUserLink();
            Thread.Sleep(1000);
            _manageUserPage.EnterSearchValue(staffcode);
            Assert.That(_manageUserPage.GetErrorMessageNotFound().Trim(), Is.EqualTo("No result was found"));
        }
    }
}