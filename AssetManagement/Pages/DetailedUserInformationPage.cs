using OpenQA.Selenium;
using AssetManagement.Library;

namespace AssetManagement.Pages
{
    public class DetailedUserInformationPage
    {
        private WebObject _recordItem = new WebObject(By.XPath("//div[normalize-space()='SD0020']"), "Record Item");
        private WebObject _staffCodeInfor = new WebObject(By.XPath("//div[@class='ams_detail__item__label'][normalize-space()='Staff Code']"), "Staff Code");
        private WebObject _fullNameInfor = new WebObject(By.XPath("//div[@class='ams_detail__item__label'][normalize-space()='Full Name']"), "Full Name Information");
        private WebObject _userNameInfor = new WebObject(By.XPath("//div[@class='ams_detail__item__label'][normalize-space()='Username']"), "User Name Information");
        private WebObject _datOfBirthInfor = new WebObject(By.XPath("//div[normalize-space()='Date of Birth']"), "Date Of Birth Information");
        private WebObject _genderInfor = new WebObject(By.XPath("//div[normalize-space()='Gender']"), "Gender Information");
        private WebObject _joinDateInfor = new WebObject(By.XPath("//div[@class='ams_detail__item__label'][normalize-space()='Joined Date']"), "Join Date Information");
        private WebObject _typeInfor = new WebObject(By.XPath("//div[@class='ams_detail__item__label'][normalize-space()='Type']"), "Type Information");
        private WebObject _locationInfor = new WebObject(By.XPath("//div[normalize-space()='Location']"), "Location Information");


        public DetailedUserInformationPage(){ }

        //Page Methods

        public string GetResultFromRecordItemPage()
        {
            return DriverUtils.GetTextFromElement(_typeInfor)+" "
            +DriverUtils.GetTextFromElement(_staffCodeInfor)+" "+
            DriverUtils.GetTextFromElement( _fullNameInfor)+" "+DriverUtils.GetTextFromElement(_userNameInfor)+" "+
            DriverUtils.GetTextFromElement(_datOfBirthInfor)+" "+DriverUtils.GetTextFromElement(_genderInfor)
            +" "+ DriverUtils.GetTextFromElement(_datOfBirthInfor)+" "+DriverUtils.GetTextFromElement(_joinDateInfor)+
            " "+ DriverUtils.GetTextFromElement(_locationInfor);

        }
        public void ChoosingRecordItem()
        {
            DriverUtils.ClickOnElement(_recordItem);
        }
    }
}