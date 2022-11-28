using System.Net.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using AssetManagement.Library;
using NUnit.Framework;



namespace AssetManagement.Pages
{
    public class ManageUserPage
    {
        //Web Elements
        private WebObject _btnManageUserPage = new WebObject(By.XPath("//span[@class='ant-menu-title-content'][normalize-space()='Manage User']"), "Manage User Button");
        private WebObject _btnFilter = new WebObject(By.CssSelector("span[aria-label='filter']"), "Filter Button");
        private WebObject _chkAdminOption = new WebObject(By.CssSelector("input[value='admin']"), "Admin Option Checkbox");
        private WebObject _chkStaffOption = new WebObject(By.CssSelector("input[value='staff']"), "Staff Option Checkbox");
        private WebObject _btnPage2 = new WebObject(By.CssSelector("a[aria-label='Page 2 is your current page']"), "Page 1 button");
        private WebObject _rowTypeResultLabel;

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
            for (int i = 1; i <= 12; i++)
            {
                _rowTypeResultLabel = new WebObject(By.XPath($"(//div[contains(text(),'Admin')])[{i}]"), $"Admin Type Row {i} ");
                Assert.That(DriverUtils.GetTextFromElement(_rowTypeResultLabel), Does.Contain("Admin"));
            }
        }
        public void VerifyFilteredByStaff()
        {
            for (int i = 1; i <= 9; i++)
            {
                _rowTypeResultLabel = new WebObject(By.XPath($"(//div[contains(text(),'Staff')])[{i}]"), $"Staff Type Row {i} ");
                Assert.That(DriverUtils.GetTextFromElement(_rowTypeResultLabel), Does.Contain("Staff"));
            }
        }
        
    }
}