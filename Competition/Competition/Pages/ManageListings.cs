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
        private IWebElement manageListingsTab => driver.FindElement(By.Name("//div[@class='ui eight item menu']/a[3]"));

        //View the listing
        private IWebElement viewIcon => driver.FindElement(By.XPath("//*[@id='listing - management - section']//tbody/tr[1]/td[8]/div/button[1]/i"));
        
        //Edit the listing
        private IWebElement edit => driver.FindElement(By.XPath("(//i[@class='outline write icon'])[1]"));

        //Delete the listing
        private IWebElement delete => driver.FindElement(By.XPath("//table[1]/tbody[1]"));


        //Click on Yes or No
        private IList<IWebElement> clickActionsButton => driver.FindElements(By.XPath("//div[@class='actions']"));


        internal void Listings()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListings");

            

           viewIcon.Click();

            edit.Click();

            delete.Click();


        }
        public void DeleteListings()
        {
            //populate the excel sheet
            ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListings");
            string ListingToDelete = ExcelLib.ReadData(2, "Title");
            string index = "";
            //Click on Manage Listings button
            manageListingsTab.Click();
            wait(1);
            
            //Click on Delete Button
            //for (int i = 1; i <= Titles.Count; i++)
            //{
            //    if ((Titles[i].Text).Equals(ListingToDelete))
            //    {
            //        index = i.ToString();
            //        break;
            //    }
            //}

        }
    }

}