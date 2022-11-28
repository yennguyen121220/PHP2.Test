using System.Collections;
using NUnit.Framework;
using AssetManagement.Pages;
using System;
using AssetManagement.Test;
using AssetManagement.Library;

namespace AssetManagement.Test
{
    public class TestManageUserUI : BaseTest
    {
        private HomePage _homePage;
        private LoginAssetManagerPage _loginAssetManagerPage;
        private ManageUserPage _manageUerPage;

        [SetUp]
        public void init()
        {
            _homePage = new HomePage();
            _loginAssetManagerPage = new LoginAssetManagerPage();
            _manageUerPage = new ManageUserPage();
        }

        [Test, TestCaseSource(nameof(GetUserDataFromJsonFile))]
        [Category("json")]
        public void TestUIManageUserPage(string userName, string password,string createButtonInfor, 
                string searchBarInfor, string staffCodeInfor,string fullNameInfor, string userNameInfor,
                string joinDateInfor, string typeInfor)
        {
            _loginAssetManagerPage.VisitHomePage();
            _loginAssetManagerPage.LoginAssetManager(userName, password);
            _homePage.ChoosingManageUser();
            var actualUI = _manageUerPage.GetResultFromManageUserPage();
            Console.WriteLine(actualUI);
            Assert.That(actualUI, Does.Contain(createButtonInfor));
            Assert.That(actualUI, Does.Contain(staffCodeInfor));
            Assert.That(actualUI, Does.Contain(fullNameInfor));
            Assert.That(actualUI, Does.Contain(userNameInfor));
            Assert.That(actualUI, Does.Contain(joinDateInfor));
            Assert.That(actualUI, Does.Contain(typeInfor));
        }

        public static IEnumerable GetUserDataFromJsonFile()
        {
            var datas = JsonHelper.GetTestData("TestData\\TestData.json", "Information");
            return datas;
        }
    }
}