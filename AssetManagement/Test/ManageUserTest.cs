using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public void FilterByAdminTypeSuccessfully()
        {
            _homePage.VisitHomePage();
            _loginPage.Login("adminHCM", "123123123");
            _manageUserPage.ManageUser();
            _manageUserPage.ClickOnAdminOption();
            _manageUserPage.VerifyFilteredByAdmin();
        }

        [Test, Description("Filter By Staff Type")]
        public void FilterByStaffTypeSuccessfully()
        {
            _homePage.VisitHomePage();
            _loginPage.Login("adminHCM", "123123123");
            _manageUserPage.ManageUser();
            _manageUserPage.ClickOnStaffOption();
            _manageUserPage.VerifyFilteredByStaff();
        }
    }
}