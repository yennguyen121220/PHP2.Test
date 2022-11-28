using System;
using System.Collections;
using AssetManagement.Library;
using AssetManagement.Pages;
using NUnit.Framework;

namespace AssetManagement.Test
{
    public class TestDetailedUserInformation : BaseTest
    {
        private HomePage _homePage;
        private LoginAssetManagerPage _loginAssetManagerPage;
        private ManageUserPage _manageUerPage;
        private DetailedUserInformationPage _detailedUserInformationPage;

        [SetUp]
        public void init()
        {
            _homePage = new HomePage();
            _loginAssetManagerPage = new LoginAssetManagerPage();
            _manageUerPage = new ManageUserPage();
            _detailedUserInformationPage = new DetailedUserInformationPage();
        }

        [Test, TestCaseSource(nameof(GetUserDataFromJsonFile))]
        [Category("json")]
        public void TestUIManageUserPage(string userName, string password, string staffCodeInfor, string fullNameInfor,
                string userNameInfor, string datOfBirthInfor,
                string genderInfor, string joinDateInfor, string typeInfor, string locationInfor)
        {
            _loginAssetManagerPage.VisitHomePage();
            _loginAssetManagerPage.LoginAssetManager(userName, password);
            _homePage.ChoosingManageUser();
            _detailedUserInformationPage.ChoosingRecordItem();
            var actualUserInfor = _detailedUserInformationPage.GetResultFromRecordItemPage();
            Console.WriteLine(actualUserInfor);
            Assert.That(actualUserInfor, Does.Contain(staffCodeInfor));
            Assert.That(actualUserInfor, Does.Contain(fullNameInfor));
            Assert.That(actualUserInfor, Does.Contain(userNameInfor));
            Assert.That(actualUserInfor, Does.Contain(datOfBirthInfor));
            Assert.That(actualUserInfor, Does.Contain(genderInfor));
            Assert.That(actualUserInfor, Does.Contain(joinDateInfor));
            Assert.That(actualUserInfor, Does.Contain(typeInfor));
            Assert.That(actualUserInfor, Does.Contain(locationInfor));
        }

        public static IEnumerable GetUserDataFromJsonFile()
        {
            var datas = JsonHelper.GetTestData("TestData\\TestData.json", "DetailUser");
            return datas;
        }
    }
}