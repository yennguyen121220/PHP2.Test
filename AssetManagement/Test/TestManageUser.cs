using System.Threading;
using NUnit.Framework;
using AssetManagement.Pages;
using System;


namespace AssetManagement.Test
{
    public class TestManageUser : BaseTest
    {
        private HomePage _homePage = new HomePage();
        private LoginPage _loginPage = new LoginPage();
        private ManageUserPage _manageUserPage = new ManageUserPage();

        [TestCase("adminHCM", "123123123", "SD0012"), Description("Search successfully with valid staff code")]
        [Category("SmokeTest")]
        [Category("Regression")]
        public void SearchSuccessfullyWithValidStaffCode(string username, string password, string staffcode)
        {
            _homePage.VisitHomePage();
            _loginPage.Login(username, password);
            Console.WriteLine("Test Search With Valid StaffCode");
            _homePage.ClickManageUSerLink();
            Thread.Sleep(1000);
            _manageUserPage.EnterSeachValue(staffcode);
            Assert.That(_manageUserPage.GetStaffCodeText().Trim(), Is.EqualTo(staffcode));
        }

        [TestCase("adminHCM", "123123123", "Jane Jones"), Description("Search successfully with valid staff's name")]
        [Category("Regression")]
        [Category("SmokeTest")]
        public void SearchsucessfullyWithValidStaffName(string username, string password, string staffname)
        {
            _homePage.VisitHomePage();
            _loginPage.Login(username, password);
            Console.WriteLine("Test Search With Valid Staff's name");
            _homePage.ClickManageUSerLink();
            Thread.Sleep(1000);
            _manageUserPage.EnterSeachValue(staffname);
            Assert.That(_manageUserPage.GetStaffNameText().Trim(), Is.EqualTo(staffname));
        }

        [TestCase("adminHCM", "123123123", "qwertyu"), Description("Search successfully with valid staff's name")]
        [Category("Regression")]
        [Category("SmokeTest")]
        public void SearchUnsucessfullyWithNotFoundStaffCode(string username, string password, string staffcode)
        {
            _homePage.VisitHomePage();
            _loginPage.Login(username, password);
            Console.WriteLine("Test Search With Valid Staff's name");
            _homePage.ClickManageUSerLink();
            Thread.Sleep(1000);
            _manageUserPage.EnterSeachValue(staffcode);
            Assert.That(_manageUserPage.GetErrorMessage().Trim(), Is.EqualTo("No result was found"));
        }

        // [TestCase("adminHCM", "123123123"), Description("Search successfully with valid staff's name")]
        // [Category("Regression")]
        // [Category("SmokeTest")]
        // public void GetUserDetail(string username, string password)
        // {
        //     _homePage.VisitHomePage();
        //     _loginPage.Login(username, password);
        //     // _manageUserPage.GetStaffCode();
        //     // _manageUserPage.GetStaffName();
        //     // _manageUserPage.GetUserName();
        //     // _manageUserPage.ClickOnDetailUser();

        //     // Thread.Sleep(1000);
        //     // _manageUserPage.EnterSeachValue(staffcode);
        //     Assert.That(_manageUserPage.GetStaffCode().Trim(), Is.EqualTo(_manageUserPage.CompareStaffCode));
        // }
        

    }
}