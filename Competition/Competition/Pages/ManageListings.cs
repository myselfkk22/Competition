using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Competition.Global;
using static Competition.Global.GlobalDefinitions;

namespace Competition.Pages
{
    internal class ManageListings
    {
        //Click on Manage Listings Link
        private IWebElement manageListingsTab => driver.FindElement(By.XPath("//a[@href='/Home/ListingManagement']"));

        //View the listing
        private IWebElement viewIcon => driver.FindElement(By.XPath("(//i[@class='eye icon'])[1]"));

        //Edit the listing
        private IWebElement edit => driver.FindElement(By.XPath("(//i[@class='outline write icon'])[1]"));
        
        //Delete the listing
        private IWebElement delete => driver.FindElement(By.XPath("//div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]/i"));


        //Click on Yes or No
        private IWebElement clickActionsButton => driver.FindElement(By.XPath("//div[@class='actions']"));

        //Click on Yes
        private IWebElement YesButton => driver.FindElement(By.XPath("//div[@class='actions']//button[2]"));

        internal void Listings()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListings");

        }
       public void AddShareSkill(int rowNumber, string Excelsheet)
        {
            ShareSkill shareSkillObj = new ShareSkill();
            wait(1);
            shareSkillObj.EnterShareSkill(rowNumber, Excelsheet);
            wait(2);
           
        }
        public void ValidateListings(int rowNumber, string Excelsheet)
        {
            ShareSkill shareSkillObj = new ShareSkill();
            Thread.Sleep(3000);
            manageListingsTab.Click();
            
            ////Populate the Excel sheet
            //ExcelLib.PopulateInCollection(Base.ExcelPath, Excelsheet);

            ////Read Data
            //string ExpectedTitle = ExcelLib.ReadData(rowNumber, "Title");

            //Click on edit button
            //string viewTab = "//*[@id='listing-management-section']//tbody/tr[1]/td[8]/div/button[1]";
            //IWebElement viewIcon = driver.FindElement(By.XPath(viewTab));
            viewIcon.Click();
            Thread.Sleep(2000);
            //calling the verify share skill
            shareSkillObj.ValidateShareSkill(rowNumber, Excelsheet);
            wait(2);
        }

       
        public void EditListings(int rowNumber1,int rowNumber2, string Excelsheet)
        {

            ShareSkill shareSkillObj = new ShareSkill();
            //Click on manage listings
            Thread.Sleep(2000);
            manageListingsTab.Click();
            
            //Populate the Excel sheet
            ExcelLib.PopulateInCollection(Base.ExcelPath, Excelsheet);
           
            //Read Data from manage listings page
            string ExpectedTitle = ExcelLib.ReadData(rowNumber1,"Title");

            //click on button edit
            //string Edit = "//div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[2]";
            //IWebElement edit = driver.FindElement(By.XPath(Edit));
            edit.Click();
            wait(1);

            //shareSkillObj.ClearData();
            shareSkillObj.EditShareSkill(rowNumber2, Excelsheet);
        }


        public void DeleteListings(int rowNumber, string Excelsheet)
        {
            //Click on Manage Listings button
            manageListingsTab.Click();
            wait(1);

            //populate the excel sheet
            ExcelLib.PopulateInCollection(Base.ExcelPath, Excelsheet);
            string ListingToDelete = ExcelLib.ReadData(rowNumber, "Title");
           
            wait(3);
            //Click on Delete Button
            delete.Click();
            Thread.Sleep(1000);
           
            //Click on Yes button
            //clickActionsButton.Click();
            YesButton.Click();  
             Thread.Sleep(1000);
        }
        public void ValidateDelete(int rowNumber1, string Excelsheet)
        {
            //Click on Manage Listings button
            manageListingsTab.Click();
            wait(1);
            //Populate the Excel sheet
            ExcelLib.PopulateInCollection(Base.ExcelPath, Excelsheet);
            wait(2);
            //Read Data from manage listings page
            string ExpectedTitle = ExcelLib.ReadData(rowNumber1, "Title");


        }
    }

}