using AssetManagement.Pages;
using NUnit.Framework;

namespace AssetManagement.Test
{
    public class CreateCategoryTest:BaseTest
    {
        private HomePage _homePage = new HomePage();
        private LoginPage _loginPage = new LoginPage();
        private ManageAssetPage _manageAssetPage = new ManageAssetPage();

        [TestCase("adminHCM", "321321321"), Description("Create New Category Successfully with all valid values")]
        [Category("Regression")]
        public void CreateCategorySuccessfullyWithValidValues(string username, string password)
        {
            _homePage.VisitHomePage();
            _loginPage.Login(username, password);
            _homePage.ClickManageAssetLink();
            _homePage.ClickCreateAssetButton();
            _manageAssetPage.ClickAddCategoryLink();
            string categoryName = _manageAssetPage.GenerateRandomString(6);
            string prefix = _manageAssetPage.GenerateRandomString(2).ToUpper();
            _manageAssetPage.EnterCategoryValue(categoryName, prefix);
            _manageAssetPage.ClickOnAddCategoryIcon();
            Assert.That(_manageAssetPage.GetCategoryName(categoryName).Trim(), Is.EqualTo(categoryName));
            // _homePage.ClickManageAssetLink();
        }

        [TestCase("adminHCM", "321321321"), Description("Create New Category Unsuccessfully with Cancel Button")]
        [Category("Regression")]
        public void CreateCategoryUnsuccessfullyWithCancelButton(string username, string password)
        {
            _homePage.VisitHomePage();
            _loginPage.Login(username, password);
            _homePage.ClickManageAssetLink();
            _homePage.ClickCreateAssetButton();
            _manageAssetPage.ClickAddCategoryLink();
            string categoryName = _manageAssetPage.GenerateRandomString(6);
            string prefix = _manageAssetPage.GenerateRandomString(2).ToUpper();
            _manageAssetPage.EnterCategoryValue(categoryName, prefix);
            _manageAssetPage.ClickOnCancelCategoryIcon();
            Assert.That(_manageAssetPage.GetTextFromAssetLink().Trim(), Is.EqualTo("Add new category"));
        }

        [TestCase("adminHCM", "321321321"), Description("Create New Category Unsuccessfully with Blank spaces on Category and Prefix")]
        [Category("Regression")]
        public void CreateCategoryUnsuccessfullyWithBlankSpace(string username, string password)
        {
            _homePage.VisitHomePage();
            _loginPage.Login(username, password);
            _homePage.ClickManageAssetLink();
            _homePage.ClickCreateAssetButton();
            _manageAssetPage.ClickAddCategoryLink();
            _manageAssetPage.ClickOnAddCategoryIcon();
            Assert.That(_manageAssetPage.GetCategoryErrorMessage().Trim(), Is.EqualTo("New category cannot be blank!"));
            Assert.That(_manageAssetPage.GetPrefixErrorMessage().Trim(), Is.EqualTo("Prefix cannot be blank!"));
        }

        [TestCase("adminHCM", "321321321", "#$$%", "*&*"), Description("Create New Category Unsuccessfully with Special character")]
        [Category("Regression")]
        public void CreateCategoryUnsuccessfullyWithSpecialCharacter(string username, string password, string categoryName, string prefix)
        {
            _homePage.VisitHomePage();
            _loginPage.Login(username, password);
            _homePage.ClickManageAssetLink();
            _homePage.ClickCreateAssetButton();
            _manageAssetPage.ClickAddCategoryLink();
            _manageAssetPage.EnterCategoryValue(categoryName, prefix);
            _manageAssetPage.ClickOnAddCategoryIcon();
            Assert.That(_manageAssetPage.GetCategoryErrorMessage().Trim(), Is.EqualTo("New category cannot contain special characters!"));
            Assert.That(_manageAssetPage.GetPrefixErrorMessage().Trim(), Is.EqualTo("Prefix cannot contain special characters!"));
        }

        [TestCase("adminHCM", "321321321", "Desktop", "DE"), Description("Create New Category Unsuccessfully with Duplicate Values")]
        [Category("Regression")]
        public void CreateCategoryUnsuccessfullyWithDuplicateValues(string username, string password, string categoryName, string prefix)
        {
            _homePage.VisitHomePage();
            _loginPage.Login(username, password);
            _homePage.ClickManageAssetLink();
            _homePage.ClickCreateAssetButton();
            _manageAssetPage.ClickAddCategoryLink();
            _manageAssetPage.EnterCategoryValue(categoryName, prefix);
            _manageAssetPage.ClickOnAddCategoryIcon();
            Assert.That(_manageAssetPage.GetCategoryErrorMessage().Trim(), Is.EqualTo("Category is already existed. Please enter a different category!"));
            Assert.That(_manageAssetPage.GetPrefixErrorMessage().Trim(), Is.EqualTo("Prefix is already existed. Please enter a different prefix!"));
        }

        [TestCase("adminHCM", "321321321", "De", "D"), Description("Create New Category Unsuccessfully with Duplicate Values")]
        [Category("Regression")]
        public void CreateCategoryUnsuccessfullyWithUnderMinLength(string username, string password, string categoryName, string prefix)
        {
            _homePage.VisitHomePage();
            _loginPage.Login(username, password);
            _homePage.ClickManageAssetLink();
            _homePage.ClickCreateAssetButton();
            _manageAssetPage.ClickAddCategoryLink();
            _manageAssetPage.EnterCategoryValue(categoryName, prefix);
            _manageAssetPage.ClickOnAddCategoryIcon();
            Assert.That(_manageAssetPage.GetCategoryErrorMessage().Trim(), Is.EqualTo("The category name must be at least 3 characters."));
            Assert.That(_manageAssetPage.GetPrefixErrorMessage().Trim(), Is.EqualTo("The category prefix must be at least 2 characters."));
        }

    }
}