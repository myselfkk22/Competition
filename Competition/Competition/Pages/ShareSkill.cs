using Competition.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Competition.Global.GlobalDefinitions;

namespace Competition.Pages
{
    internal class ShareSkill
    {
        #region Page objects for Create Listing
        //Click on ShareSkill Button
        private IWebElement ShareSkillButton => driver.FindElement(By.LinkText("Share Skill"));

        //Enter the Title in textbox
        private IWebElement Title => driver.FindElement(By.Name("title"));

        //Enter the Description in textbox
        private IWebElement Description => driver.FindElement(By.Name("description"));

        //Click on Category Dropdown
        private IWebElement CategoryDropDown => driver.FindElement(By.Name("categoryId"));

        //Click on SubCategory Dropdown
        private IWebElement SubCategoryDropDown => driver.FindElement(By.Name("subcategoryId"));

        //Enter Tag names in textbox
        private IWebElement Tags => driver.FindElement(By.XPath("//div[@class='form-wrapper field  ']//input"));

        //Select the Service type
        private IList<IWebElement> radioServiceType => driver.FindElements(By.Name("serviceType"));

        //Select the Location Type
        private IList<IWebElement> radioLocationType => driver.FindElements(By.Name("locationType"));
       

        //Click on Start Date dropdown
        private IWebElement StartDateDropDown => driver.FindElement(By.Name("startDate"));

        //Click on End Date dropdown
        private IWebElement EndDateDropDown => driver.FindElement(By.Name("endDate"));

        //Storing the table of available days
        private IList<IWebElement> Days => driver.FindElements(By.XPath("//input[@name='Available']"));

        //Storing the starttime
        private IList<IWebElement> StartTime => driver.FindElements(By.Name("StartTime"));
       
        private IList<IWebElement> EndTime => driver.FindElements(By.Name("EndTime"));
            
        //Click on StartTime dropdown
        private IWebElement StartTimeDropDown => driver.FindElement(By.XPath("//div[3]/div[2]/input[1]"));

        //Click on EndTime dropdown
        private IWebElement EndTimeDropDown => driver.FindElement(By.XPath("//div[3]/div[3]/input[1]"));

        //Click on Skill Trade option
        private IList<IWebElement> radioSkillTrade => driver.FindElements(By.Name("skillTrades"));

        //Enter Skill Exchange
        private IWebElement SkillExchange => driver.FindElement(By.XPath("//div[@class='form-wrapper']//input[@type='text']"));

        //Enter the amount for Credit
        private IWebElement CreditAmount => driver.FindElement(By.XPath("//input[@placeholder='Amount']"));

        //Click on work samples button
        private IWebElement WorkSamples => driver.FindElement(By.XPath("//div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i"));

        //Click on Active/Hidden option
        private IList<IWebElement> radioActiveOption => driver.FindElements(By.XPath("//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']"));

        //Click on Save button
        private IWebElement Save => driver.FindElement(By.XPath("//input[@value='Save']"));
        #endregion




        internal void EnterShareSkill()
        {
            ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");
            
            //Click on Share Skill button
            ShareSkillButton.Click();
            wait(1);

            //Enter Title 
            Title.SendKeys(ExcelLib.ReadData(2,"Title"));

            //Enter Description
            Description.SendKeys(ExcelLib.ReadData(2,"Description"));

            //Select category
            var selectCategory = new SelectElement(CategoryDropDown);
            selectCategory.SelectByText(ExcelLib.ReadData(2, "Category"));
            Thread.Sleep(5000);
            
             //Select Subcategory
            //SubCategoryDropDown.Click();
            var selectSubcategory = new SelectElement(SubCategoryDropDown);
            selectSubcategory.SelectByText(ExcelLib.ReadData(2, "Subcategory"));


            //Enter tag
            Tags.Click();
            Tags.SendKeys(ExcelLib.ReadData(2, "Tags"));
            Tags.SendKeys(Keys.Return);

            //Select Service type
            string expectedServiceType = ExcelLib.ReadData(2, "ServiceType");
            string expectedServiceValue = "0";

            if (expectedServiceType.Equals("One-off service"))
                expectedServiceValue = "1";
            else expectedServiceValue = "0";
            for (int i = 0; i <radioServiceType.Count(); i++)
            {
                string actualServiceValue = radioServiceType[i].GetAttribute("Value");
                if (expectedServiceValue.Equals(actualServiceValue))
                {
                    radioServiceType[i].Click();
                }
            }

            //Select Location type
            string expectedLocationType = ExcelLib.ReadData(2, "LocationType");
            string expectedLocationValue = "1";

            if (expectedLocationType.Equals("On-site"))
                expectedLocationValue = "0";
            else expectedLocationValue = "1";
            for (int i = 0; i < radioServiceType.Count(); i++)
            {
                string actualLocationValue = radioServiceType[i].GetAttribute("Value");
                if (expectedLocationValue.Equals(actualLocationValue))
                {
                    radioLocationType[i].Click();
                }
            }


            //Enter Start date
            StartDateDropDown.SendKeys (ExcelLib.ReadData(2,"Startdate"));

            //Enter End date
            EndDateDropDown.SendKeys(ExcelLib.ReadData(2, "Enddate"));
            Thread.Sleep(2000);

            //Enter available Days
            string expectedDays = ExcelLib.ReadData(2, "Days");
            string indexValue = "";
            switch(expectedDays)
            {
               
                 case "Sun": indexValue = "0";
                    break;

                case "Mon": indexValue = "1";
                    break;

                case "Tue": indexValue = "2";
                    break;

                case "Wed": indexValue = "3";
                    break;

                case "Thu": indexValue = "4";
                    break;

                case "Fri": indexValue = "5";
                    break;
                case "Sat": indexValue = "6";
                    break;
                    default:break;
            }

            for (int i = 0; i < Days.Count; i++)
            {
                if (indexValue.Equals(Days[i].GetAttribute("index")))
                  
                {
                    Days[i].Click();
                    StartTime[i].SendKeys(ExcelLib.ReadData(2, "StartTime"));

                    EndTime[i].SendKeys(ExcelLib.ReadData(2, "EndTime"));
                }
            }

            Thread.Sleep(1000);
            
            //Skill Trade radio button
            string expectedSkillTrade = ExcelLib.ReadData(2, "SkillTrade");
            string expectedSkillValue = "true";

            if (expectedSkillTrade.Equals("Credit"))
                expectedSkillValue = "false";

            Thread.Sleep(2000);
            for (int i = 0; i < radioSkillTrade.Count(); i++)
            {
                string actualSkillTradeValue = radioSkillTrade[i].GetAttribute("Value");
                if (expectedSkillValue.Equals(actualSkillTradeValue))
                {
                    //Select Skill Exchange or Credit option
                    radioSkillTrade[i].Click();
                    wait(1);
                    if (expectedSkillTrade.Equals("Skill-exchange"))
                        //Enter tags for skill exchange
                    {
                        SkillExchange.Click();
                        SkillExchange.SendKeys(ExcelLib.ReadData(2, "Skill-Exchange"));
                        SkillExchange.SendKeys(Keys.Return);
                    }
                    else
                    {
                        //Entering Credit amount
                        CreditAmount.SendKeys(ExcelLib.ReadData(2, "Credit"));
                    }
                }
            }

            //Click on work samples button
            WorkSamples.Click();
            wait(3);
            //Run AutoIt Script to Execute file uploading
            using (Process exeProcess = Process.Start(Base.AutoScriptPath))
            {
                exeProcess.WaitForExit();
            }

            Thread.Sleep(1000);

            //Select Active Option
            string expectedActiveOption = ExcelLib.ReadData(2, "ActiveOption");
            string expectedActiveValue = "true";
            
            if (expectedActiveOption.Equals("Hidden"))              
                expectedActiveValue = "false";
  
            for (int i = 0; i < radioActiveOption.Count(); i++)
            {
                string actualActiveValue = radioActiveOption[i].GetAttribute("Value");
                if(expectedActiveValue.Equals(actualActiveValue))
                    radioActiveOption[i].Click();
            }
            

            //Click on save
            Save.Click();
            wait(3);
            
        }

        internal void ValidateShareSkill()
        {

        }



        internal void EditShareSkill()
        {
         
        }
    }
}
