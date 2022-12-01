using System.Net.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using AssetManagement.Library;
using NUnit.Framework;
using AssetManagement.Test;




namespace AssetManagement.Pages
{
    public class ManageUserPage
    {
        //Web Elements
        private WebObject _btnManageUserPage = new WebObject(By.XPath("//span[@class='ant-menu-title-content'][normalize-space()='Manage User']"), "Manage User Button");
        private WebObject _btnFilter = new WebObject(By.CssSelector("div.ams__dropdownfilter__icon"), "Filter Button");
        private WebObject _chkAdminOption = new WebObject(By.XPath("//input[@value='admin']/parent::label"), "Admin Option Checkbox");
        private WebObject _chkStaffOption = new WebObject(By.XPath("//input[@value='staff']/parent::label"), "Staff Option Checkbox");
        private WebObject _filterByAdminRole = new WebObject(By.XPath("//div[contains(text(),'Admin')]"), "Filter By Admin Role");
        private WebObject _filterByStaffRole = new WebObject(By.XPath("//div[contains(text(),'Staff')]"), "Filter By Staff Role");

        private WebObject _txtSearchBox = new WebObject(By.XPath("//input[@type='text']"), "Search Textbox");
        private WebObject _btnSearchIcon = new WebObject(By.CssSelector(".anticon.anticon-search"),"Search button");
        private WebObject _tblStaffCode = new WebObject(By.CssSelector(".ams__record:nth-child(1) div"),"StaffCode value");
        private WebObject _tblStaffName = new WebObject(By.CssSelector(".ams__record:nth-child(2) div"),"Staff's fullname value");
        private WebObject _lblErrorMessageNotFound = new WebObject(By.CssSelector(".ant-empty-description"),"StaffCode value");


        //Contructor
        public ManageUserPage() { }

        //Page Methods
        public void ManageUser()
        {
            DriverUtils.ClickOnElement(_btnManageUserPage);
            DriverUtils.ClickOnElement(_btnFilter);
        }
        public void ClickOnAdminOption()
        {
            DriverUtils.ClickOnElement(_chkAdminOption);
        }
        public void ClickOnStaffOption()
        {
            DriverUtils.ClickOnElement(_chkStaffOption);
        }
        public void VerifyFilteredByAdmin()
        {
            IList < IWebElement > _lblFilterByRole = BaseTest.GetWebDriver().FindElements(By.XPath("//div[contains(text(),'Admin')]"));
            int count = _lblFilterByRole.Count;
            for(int i = 1; i <= count ; i++){
                Assert.That(DriverUtils.GetTextFromElement(_filterByAdminRole), Does.Contain("Admin"));
            }
            
        }
        public void VerifyFilteredByStaff()
        {
            IList < IWebElement > _lblFilterByRole = BaseTest.GetWebDriver().FindElements(By.XPath("//div[contains(text(),'Staff')]"));
            int count = _lblFilterByRole.Count;
            for(int i = 1; i <= count ; i++){
                Assert.That(DriverUtils.GetTextFromElement(_filterByStaffRole), Does.Contain("Staff Code"));
            }
        }
        public void EnterSeachValue(string searchValue)
        {
            DriverUtils.EnterText(_txtSearchBox, searchValue);
            DriverUtils.ClickOnElement(_btnSearchIcon);
        }
        public string GetStaffCodeText()
        {
            return DriverUtils.GetTextFromElement(_tblStaffCode);
        }
        public string GetStaffNameText()
        {
            return DriverUtils.GetTextFromElement(_tblStaffName);
        }

        public string GetErrorMessage()
        {
            return DriverUtils.GetTextFromElement(_lblErrorMessageNotFound);
        }
        
    }
}