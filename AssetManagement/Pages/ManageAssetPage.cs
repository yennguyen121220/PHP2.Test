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
    public class ManageAssetPage
    {
        private WebObject _txtNameAsset = new WebObject(By.Id("name-asset"), "Name Asset Textfield");
        private WebObject _txaSpecification = new WebObject(By.Id("specification"), "Specification Textarea");
        private WebObject _ddlCategory = new WebObject(By.CssSelector("div.buttom-choosen-category button"), "Category Dropdown List");
        private WebObject _ddlSelectCategory = new WebObject(By.XPath("//button[@value='Desktop']"), "Select Category Dropdown List");
        private WebObject _dtpInstallDate = new WebObject(By.CssSelector(".MuiInputBase-input"), "Install Date Picker");
        private WebObject _chkState = new WebObject(By.XPath("//label[@for='not-available-asset']"), "Not Available State");
        private WebObject _btnSave = new WebObject(By.CssSelector("button.btn-save-add-asset"), "Save Button");
        private WebObject _btnCancel = new WebObject(By.CssSelector("button.btn-cancel-add-asset"), "Save Button");

        private WebObject _txtGetNameAsset;
        private WebObject _lblNameAssetOverLengthMessage = new WebObject(By.CssSelector(".field-name .alert-danger"), "Name Asset Over MaxLength Error Message");
        private WebObject _lblSpecificationOverLengthMessage = new WebObject(By.CssSelector(".field-specification .alert-danger"), "Specification Over MaxLength Error Message");
        private WebObject _lblAssetList = new WebObject(By.CssSelector("h3.ams__content__title"), "Get Asset List Text");
        private WebObject _lblErrorCategoryMessage = new WebObject(By.XPath("//div[@class='alert-validate-category']//div[contains(text(),'ategory')]"), "Get Category Error Message");
        private WebObject _lblErrorPrefixMessage = new WebObject(By.XPath("//div[@class='alert-validate-category']//div[contains(text(),'refix')]"), "Get Prefix Error Message");
        private WebObject _lnkAddCategory = new WebObject(By.CssSelector(".wrapper-button-add-new-category>button"), "Add New Category Link");
        private WebObject _txtCategory = new WebObject(By.Name("category_name"), "Category Textfield");
        private WebObject _txtPrefix = new WebObject(By.Name("category_prefix"), "Prefix Textfield");
        private WebObject _btnAddCategory = new WebObject(By.CssSelector(".btn-add-category svg"), "Add Category Button");
        private WebObject _btnCancelCategory = new WebObject(By.CssSelector(".btn-close-category svg"), "Cancel Category Button");
        private WebObject _txtSearchBox = new WebObject(By.XPath("//input[@type='text']"), "Search Textbox");
        private WebObject _btnSearchIcon = new WebObject(By.CssSelector(".anticon.anticon-search"),"Search Button");
        private WebObject _tblGetAssetCodeValue = new WebObject(By.CssSelector(".ams__record:nth-child(1) div:nth-child(1)"),"Get Asset Code Value");
        private WebObject _tblGetAssetNameValue = new WebObject(By.CssSelector(".ams__record:nth-child(2) div:nth-child(1)"),"Get Asset Code Value");
        private WebObject _lblErrorMessageNotFoundAsset = new WebObject(By.CssSelector(".ant-empty-description"),"StaffCode value");


        private WebObject _lblGetCategoryName;
        public ManageAssetPage() { }

        // ============== Add New Asset ==================
        public void EnterAllAssetValue(string nameAsset, string specification, string datePicker)
        {
            DriverUtils.EnterText(_txtNameAsset, nameAsset);
            DriverUtils.EnterText(_txaSpecification, specification);
            DriverUtils.EnterText(_dtpInstallDate, datePicker);
        }
        public void SelectCategory()
        {
            DriverUtils.ClickOnElement(_ddlCategory);
            DriverUtils.ClickOnElement(_ddlSelectCategory);
        }
        public void SelectState()
        {
            DriverUtils.MoveToElement(_btnSave);
            DriverUtils.ClickOnElement(_chkState);
        }
        public void ClickSaveButton()
        {
            DriverUtils.ClickOnElement(_btnSave);
        }
        public void ClickCancelButton()
        {
            DriverUtils.ClickOnElement(_btnCancel);
        }
        public string GetNameAsset(string assetName)
        {
            _txtGetNameAsset = new WebObject(By.XPath("//div[contains(text(),'"+assetName+"')]"), "Get Asset Name Just Created");
            return DriverUtils.GetTextFromElement(_txtGetNameAsset);
        }

        // ============New Asset Get error over maxlength=========
        public string GetNameAssetOverLengthErrorMessage()
        {
            return DriverUtils.GetTextFromElement(_lblNameAssetOverLengthMessage);
        }
        public string GetSpecificationOverLengthErrorMessage()
        {
            return DriverUtils.GetTextFromElement(_lblSpecificationOverLengthMessage);
        }

        // ====New Asset cancel====
        public string GetAssetListText()
        {
            return DriverUtils.GetTextFromElement(_lblAssetList);
        }

        // ========= Element Add Category ==========
        public void ClickAddCategoryLink()
        {
            
            DriverUtils.ClickOnElement(_ddlCategory);
            DriverUtils.ClickOnElement(_lnkAddCategory);
        }

        public void EnterCategoryValue(string category, string prefix)
        {
            DriverUtils.EnterText(_txtCategory, category);
            DriverUtils.EnterText(_txtPrefix, prefix);
        }

        public void ClickOnAddCategoryIcon()
        {
            DriverUtils.ClickOnElement(_btnAddCategory);
        }
        public void ClickOnCancelCategoryIcon()
        {
            DriverUtils.ClickOnElement(_btnCancelCategory);
        }

        public string GetTextFromAssetLink()
        {
            return DriverUtils.GetTextFromElement(_lnkAddCategory);
        }
        public string GetCategoryName(string categoryName)
        {
            _lblGetCategoryName = new WebObject(By.XPath($"//span[text()='{categoryName}']"), "Get Asset Name Just Created");
            return DriverUtils.GetTextFromElement(_lblGetCategoryName); 
        }
        public string GenerateRandomString(int length)
        {
            Random random = new Random();
            var charsUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var charsLower = "abcdefghijklmnopqrstuvwxyz";
            var stringChars = new char[length];

            for (int i = 0; i < stringChars.Length; i++)
            {
                if(i == 0)
                {
                    stringChars[0]=charsUpper[random.Next(charsUpper.Length)];
                }
                else{
                    stringChars[i]=charsLower[random.Next(charsLower.Length)];

                }
            }

            return new String(stringChars);
        }

        // ======== Get duplicate error for Category and Prefix============
        public string GetCategoryErrorMessage()
        {
            return DriverUtils.GetTextFromElement(_lblErrorCategoryMessage);
        }

        public string GetPrefixErrorMessage()
        {
            return DriverUtils.GetTextFromElement(_lblErrorPrefixMessage);
        }

        // ============== Manage Asset ===============
        public void EnterSearchValue(string searchValue)
        {
            DriverUtils.EnterText(_txtSearchBox, searchValue);
            DriverUtils.ClickOnElement(_btnSearchIcon);
        }
        public bool IfSearchValueExist()
        {
            return DriverUtils.IsElementDisplayed(_tblGetAssetCodeValue);
        }

        public string GetAssetCodeValue()
        {
            return DriverUtils.GetTextFromElement(_tblGetAssetCodeValue);
        }

        public string GetAssetNameValue()
        {
            return DriverUtils.GetTextFromElement(_tblGetAssetNameValue);
        }

        
        public string GetErrorMessageNotFound()
        {
            return DriverUtils.GetTextFromElement(_lblErrorMessageNotFoundAsset);
        }
    }
}