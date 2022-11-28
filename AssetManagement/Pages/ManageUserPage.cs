using OpenQA.Selenium;
using AssetManagement.Library;

namespace AssetManagement.Pages
{
    public class ManageUserPage
    {
        private WebObject _searchTextbox = new WebObject(By.XPath("//input[@placeholder='Search...']"), "Search Textbox");
        private WebObject _searchButton = new WebObject(By.CssSelector(".anticon.anticon-search"),"Search button");
        private WebObject _getStaffName = new WebObject(By.CssSelector(".ams__record:nth-child(2) div"),"Staff's fullname value");
        private WebObject _getStaffCode = new WebObject(By.CssSelector(".ams__record:nth-child(1) div"),"StaffCode value");
        private WebObject _getErrorMessage = new WebObject(By.CssSelector(".ant-empty-description"),"StaffCode value");
        private WebObject _staffCode = new WebObject(By.CssSelector("tr:nth-child(2) td:nth-child(1) div"), "Get StaffCode value");
        private WebObject _staffName = new WebObject(By.CssSelector("tr:nth-child(2) td:nth-child(2) div"), "Get StaffName value");
        private WebObject _userName = new WebObject(By.CssSelector("tr:nth-child(2) td:nth-child(3) div"), "Get StaffName value");
        private WebObject _staffCodeValue = new WebObject(By.CssSelector(".ams_detail__item:nth-child(1) .ams_detail__item__value"), "StaffCode value");
        private WebObject _staffNameValue = new WebObject(By.CssSelector(".ams_detail__item:nth-child(2) .ams_detail__item__value"), "StaffName value");
        private WebObject _userNameValue = new WebObject(By.CssSelector(".ams_detail__item:nth-child(3) .ams_detail__item__value"), "UserName value");

        // private WebObject _getErrorMessage = new WebObject(By.CssSelector(".ant-empty-description", "Get Error Message"));
        
        public ManageUserPage(){}

        public void EnterSeachValue(string searchValue)
        {
            DriverUtils.EnterText(_searchTextbox, searchValue);
            DriverUtils.ClickOnElement(_searchButton);
        }
        public string GetStaffNameText()
        {
            return DriverUtils.GetTextFromElement(_getStaffName);
        }
        public string GetStaffCodeText()
        {
            return DriverUtils.GetTextFromElement(_getStaffCode);
        }
        public string GetErrorMessage()
        {
            return DriverUtils.GetTextFromElement(_getErrorMessage);
        }
        public string GetStaffCode()
        {
            return DriverUtils.GetTextFromElement(_staffCode);
        }
        public string GetStaffName()
        {
            return DriverUtils.GetTextFromElement(_staffName);
        }
        public string GetUserName()
        {
            return DriverUtils.GetTextFromElement(_userName);
        }
        public void ClickOnDetailUser()
        {
            DriverUtils.ClickOnElement(_staffName);
        }
        public string CompareStaffCode()
        {
            return DriverUtils.GetTextFromElement(_staffCodeValue);
        }
        public string CompareStaffName()
        {
            return DriverUtils.GetTextFromElement(_staffNameValue);
        }
        public string CompareStaffUserName()
        {
            return DriverUtils.GetTextFromElement(_userNameValue);
        }

    }
}