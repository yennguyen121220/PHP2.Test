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
        private WebObject _btnFilter = new WebObject(By.CssSelector(".ams__dropdownfilter__icon"), "Filter Button");
        private WebObject _chkAdminOption = new WebObject(By.CssSelector("input[value='admin']"), "Admin Option Checkbox");
        private WebObject _chkStaffOption = new WebObject(By.CssSelector("input[value='staff']"), "Staff Option Checkbox");
        private WebObject _filterByAdminRole = new WebObject(By.XPath("//div[contains(text(),'Admin')]"), "Filter By Admin Role");
        private WebObject _filterByStaffRole = new WebObject(By.XPath("//div[contains(text(),'Staff')]"), "Filter By Staff Role");


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
        
    }
}