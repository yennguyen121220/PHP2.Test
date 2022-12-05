using AssetManagement.Pages;
using NUnit.Framework;


namespace AssetManagement.Test
{
    public class CreateAssetTest : BaseTest
    {
        private HomePage _homePage = new HomePage();
        private LoginPage _loginPage = new LoginPage();
        private ManageAssetPage _manageAssetPage = new ManageAssetPage();

        public void EnterValueToCreateAsset(string assetName, string specification, string datePicker)
        {
            _manageAssetPage.EnterAllAssetValue(assetName, specification, datePicker);
            _manageAssetPage.SelectCategory();
            _manageAssetPage.SelectState();
        }

        [TestCase("adminHCM", "321321321","12/12/2021", "Assetname Autotest", "Specification Test"), Description("Create New Asset Successfully")]
        [Category("Regression")]
        public void CreateNewAssetSuccessfullyWithValidValues(string username, string password, string datePicker, string assetName, string specification)
        {
            _homePage.VisitHomePage();
            _loginPage.Login(username, password);
            _homePage.ClickManageAssetLink();
            _homePage.ClickCreateAssetButton();
            EnterValueToCreateAsset(assetName, specification, datePicker);
            _manageAssetPage.ClickSaveButton();
            Assert.That(_manageAssetPage.GetNameAsset(assetName).Trim(), Is.EqualTo(assetName));
        }

        
        [TestCase("adminHCM", "321321321","12/12/2021", "Assetname Autotest", "Specification Test"), Description("Create New Asset Unsucessfully when user clicks Cancel button")]
        [Category("Regression")]
        public void CreateNewAssetUnuccessfullyWithCancel(string username, string password, string datePicker, string assetName, string specification)
        {
            _homePage.VisitHomePage();
            _loginPage.Login(username, password);
            _homePage.ClickManageAssetLink();
            _homePage.ClickCreateAssetButton();
            EnterValueToCreateAsset(assetName, specification, datePicker);
            _manageAssetPage.ClickCancelButton();
            Assert.That(_manageAssetPage.GetAssetListText().Trim(), Is.EqualTo("Asset List"));
        }

        [TestCase("adminHCM", "321321321","12/12/2021", 
        "wertyuiopoiuytreqwertyuiQWERTYUIOPASDFGHJKLZXCVBNM!@#$%^&*345678909876543qwertyuiopasdfghjklZxcvbnm,sdcfvghjgfwertyuirtyu", 
        "wertyuiopoiuytreqwertyuiQWERTYUIOPASDFGHJKLZXCVBNM!@#$%^&*345678909876543qwertyuiopasdfghjklZxcvbnm,sdcfvghjgfwertyuirtyu"), 
        Description("Error message show when user enter over max length successfully")]
        [Category("Regression")]
        public void ErrorMessageShowWhenEnterOverMaxLength(string username, string password, string datePicker, string assetName, string specification)
        {
            _homePage.VisitHomePage();
            _loginPage.Login(username, password);
            _homePage.ClickManageAssetLink();
            _homePage.ClickCreateAssetButton();
            _manageAssetPage.EnterAllAssetValue(assetName, specification, datePicker);
            Assert.That(_manageAssetPage.GetNameAssetOverLengthErrorMessage().Trim(), Is.EqualTo("Name cannot exceed 120 characters"));
            Assert.That(_manageAssetPage.GetSpecificationOverLengthErrorMessage().Trim(), Is.EqualTo("Specification cannot exceed 120 characters"));
        }

        [TestCase("adminHCM", "321321321","12/12/2021", "123", "123"), Description("Error message show when user enter over max length successfully")]
        [Category("Regression")]
        public void ErrorMessageShowWhenEnterUnderMinLength(string username, string password, string datePicker, string assetName, string specification)
        {
            _homePage.VisitHomePage();
            _loginPage.Login(username, password);
            _homePage.ClickManageAssetLink();
            _homePage.ClickCreateAssetButton();
            _manageAssetPage.EnterAllAssetValue(assetName, specification, datePicker);
            Assert.That(_manageAssetPage.GetNameAssetOverLengthErrorMessage().Trim(), Is.EqualTo("The name asset must be at least 6 characters"));
            Assert.That(_manageAssetPage.GetSpecificationOverLengthErrorMessage().Trim(), Is.EqualTo("The specification must be at least 6 characters"));
        }

    }
}