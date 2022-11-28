using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using AssetManagement.Library;

namespace AssetManagement.Pages
{
    public class ManageUserPage
    {
        private WebObject _createNewUserButton = new WebObject(By.XPath("//button[normalize-space()='Create new user']"), "Create New User Button");
        private WebObject _searchBar = new WebObject(By.XPath("//input[@placeholder='Search...']"), "Search Bar");
        private WebObject _staffCode = new WebObject(By.XPath("//div[contains(text(),'Staff Code')]"), "Staff Code");
        private WebObject _fullName = new WebObject(By.XPath("//div[contains(text(),'Full Name')]"), "Full Name Information");
        private WebObject _userName = new WebObject(By.XPath("//div[contains(text(),'Username')]"), "User Name Information");
        private WebObject _joinDate = new WebObject(By.XPath("//div[contains(text(),'Joined Date')]"), "Join Date Information");
        private WebObject _type = new WebObject(By.XPath("//div[@class='ams__columnname']//div[contains(text(),'Type')]"), "Type Information");
        private WebObject _locationHCM = new WebObject(By.XPath("//div[normalize-space()='HCM']"), "Location Information");


        public ManageUserPage() { }

        //Page Methods

        public string GetResultFromManageUserPage()
        {
            return DriverUtils.GetTextFromElement(_createNewUserButton)
            + DriverUtils.GetTextFromElement(_staffCode) + " " +
            DriverUtils.GetTextFromElement(_fullName) + " " + DriverUtils.GetTextFromElement(_userName) + " " +
            DriverUtils.GetTextFromElement(_joinDate) + " " + DriverUtils.GetTextFromElement(_type);
        }
    }
}