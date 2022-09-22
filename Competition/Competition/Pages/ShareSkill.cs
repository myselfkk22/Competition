using Competition.Global;
using NUnit.Framework;
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
        private IWebElement Tags => driver.FindElement(By.XPath("//div[2]/div/form/div[4]/div[2]/div[1]/div/div/div/input"));

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


        #region    Assertions

        //Check the actual title 
        private IWebElement actualTitle => driver.FindElement(By.XPath("//div[2]//div[2]/div[1]/div[1]/div[2]/h1/span"));

        //Check the actual Description
        private IWebElement actualDescription => driver.FindElement(By.XPath("//div[2]//div[2]/div[1]/div[1]/div[2]/div[2]//div[1]//div[2]"));

        //Check the actual Sub Caegory
        private IWebElement actualCategory => driver.FindElement(By.XPath("//div[contains(text(),'Category')]//following-sibling::div"));

         //Check the actual Sub Caegory
        private IWebElement actualSubCategory => driver.FindElement(By.XPath("//div[contains(text(),'Subcategory')]//following-sibling::div"));

        //Check the actual Service
        private IWebElement actualService => driver.FindElement(By.XPath("//div[contains(text(),'Service Type')]//following-sibling::div"));

        //Check the actual start date
        private IWebElement actualStartDate => driver.FindElement(By.XPath("//div[contains(text(),'Start Date')]//following-sibling::div"));

        //Check the actual end date
        private IWebElement actualEndDate => driver.FindElement(By.XPath("//div[contains(text(),'End Date')]//following-sibling::div"));

        //Check the actual location type
        private IWebElement actualLocationType => driver.FindElement(By.XPath("//div[contains(text(),'Location Type')]//following-sibling::div"));

        //Check the actual skillTrade
        private IWebElement actualSkillTrade => driver.FindElement(By.XPath("//div[contains(text(),'Skills Trade')]//following-sibling::div/span"));

        private IWebElement actualSkillExchange => driver.FindElement(By.XPath("//div[contains(text(),'Skills Trade')]//following-sibling::div"));

        #endregion   


        #region Create Invalid messages
        //Title Text box
        private IWebElement errorTitle => driver.FindElement(By.XPath("//div[2]/div/form/div[1]/div/div[2]/div/div[2]/div"));
        //Description Text box
        private IWebElement errorDescription => driver.FindElement(By.XPath("//div[2]/div/form/div[2]/div/div[2]/div[2]/div"));
        //Category                                               
        private IWebElement errorCategory => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div[2]"));
        //Sub Category
        private IWebElement errorSubcategory => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]//div[2]/div[2]/div"));
        //Tags                             
        private IWebElement errorTags => driver.FindElement(By.XPath("//div[2]/div/form/div[4]/div[2]/div[2]"));
        //Start Date
        private IWebElement errorStartDate => driver.FindElement(By.XPath("//div[2]/div/form/div[7]/div[2]/div[2]"));
        //End Date
        private IWebElement errorEndDate => driver.FindElement(By.XPath("//div[2]/div/form/div[7]/div[2]/div[3]"));
       
        //Skill Exchage Tag
        private IWebElement errorSkillsExchangeTags => driver.FindElement(By.XPath("//div[2]/div/form/div[8]/div[4]/div[2]"));

        //Message after save
        private IWebElement message => driver.FindElement(By.XPath("/html/body/div[1]"));

        #endregion

        #region Clear Data
        private IWebElement displayedTags => driver.FindElement(By.XPath("//div[2]/div/form/div[4]/div[2]/div/div/div/span[1]/a"));
        private IWebElement RemoveSkillExchangeTags => driver.FindElement(By.XPath("//div[2]/div/form/div[8]/div[4]/div/div/div/div/span/a"));
        #endregion
        public void EnterShareSkill(int rowNumber, string Excelsheet)
        {
            ExcelLib.PopulateInCollection(Base.ExcelPath, Excelsheet);
            
            //Click on Share Skill button
            ShareSkillButton.Click();
            wait(1);

            //Enter Title 
            Title.SendKeys(ExcelLib.ReadData(rowNumber, "Title"));

            //Enter Description
            Description.SendKeys(ExcelLib.ReadData(rowNumber, "Description"));

            //Select category
            var selectCategory = new SelectElement(CategoryDropDown);
            selectCategory.SelectByText(ExcelLib.ReadData(rowNumber, "Category"));
            Thread.Sleep(5000);
            
             //Select Subcategory          
            var selectSubcategory = new SelectElement(SubCategoryDropDown);
            selectSubcategory.SelectByText(ExcelLib.ReadData(rowNumber, "Subcategory"));


            //Enter tag
            Tags.Click();
            Tags.SendKeys(ExcelLib.ReadData(rowNumber, "Tags"));
            Tags.SendKeys(Keys.Return);

            //Select Service type
            string expectedServiceType = ExcelLib.ReadData(rowNumber, "ServiceType");
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
            string expectedLocationType = ExcelLib.ReadData(rowNumber, "LocationType");
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
            Thread.Sleep(2000);
            StartDateDropDown.Click();
            string startDate = ExcelLib.ReadData(rowNumber, "StartDate");
            StartDateDropDown.SendKeys(startDate);
            Thread.Sleep(1000);
           
            //Enter End date
            string endDate = ExcelLib.ReadData(rowNumber, "EndDate");
            EndDateDropDown.Click();
            EndDateDropDown.SendKeys(endDate);

            //Enter available Days
            Thread.Sleep(2000);
            string expectedDays = ExcelLib.ReadData(rowNumber, "Days");
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
                    StartTime[i].SendKeys(ExcelLib.ReadData(rowNumber, "StartTime"));

                    EndTime[i].SendKeys(ExcelLib.ReadData(rowNumber, "EndTime"));
                }
            }

            Thread.Sleep(1000);
            
            //Skill Trade radio button
            string expectedSkillTrade = ExcelLib.ReadData(rowNumber, "SkillTrade");
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
                        SkillExchange.SendKeys(ExcelLib.ReadData(rowNumber, "Skill-Exchange"));
                        SkillExchange.SendKeys(Keys.Return);
                    }
                    else
                    {
                        //Entering Credit amount
                        CreditAmount.SendKeys(ExcelLib.ReadData(rowNumber, "Credit"));
                    }
                }
            }


            //Click on work samples button
            Thread.Sleep(5000);
            WorkSamples.Click();
            wait(3);
           
            //Run AutoIt Script to Execute file uploading
            using (Process exeProcess = Process.Start(Base.AutoScriptPath))
            {
                exeProcess.WaitForExit();
            }

            Thread.Sleep(1000);

            //Select Active Option
            string expectedActiveOption = ExcelLib.ReadData(rowNumber, "ActiveOption");
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

        public void ValidateShareSkill(int rowNumber, string Excelsheet)
        {
            //Populate Excel data
            ExcelLib.PopulateInCollection(Base.ExcelPath, Excelsheet);

            //Retrieve excel data
            string expectedTitle = ExcelLib.ReadData(rowNumber, "Title");
            string expectedDescription = ExcelLib.ReadData(rowNumber, "Description");

            //Validate actual Title with Expected title

            Assert.AreEqual(expectedTitle, actualTitle.Text);

            //Validate actual Description with Expected Description
            Assert.AreEqual(expectedDescription, actualDescription.Text);

            //Validate actual Category with Expected Category
            Assert.AreEqual(ExcelLib.ReadData(rowNumber, "Category"), actualCategory.Text);

            //Validate actual SubCategory with Expected SubCategory
            Assert.AreEqual(ExcelLib.ReadData(rowNumber, "Subcategory"), actualSubCategory.Text);

            //Validate actual ServiceType with Expected ServiceType
            Assert.AreEqual(ExcelLib.ReadData(rowNumber, "ServiceType"), actualService.Text+ " service");
          

            //Validate actual StartDate with Expected StartDate         
            string start_date = ExcelLib.ReadData(rowNumber, "StartDate");
            Thread.Sleep(1000);
            string expectedStartDate = DateTime.Parse(start_date)
                .ToString("yyyy-MM-dd");
            string actual_StartDate = actualStartDate.Text;
            Assert.AreEqual(expectedStartDate, actual_StartDate);

            //Validate actual EndDate with Expected EndDate
            string expecteEndDate = DateTime.Parse(ExcelLib.ReadData(rowNumber, "EndDate"))
                 .ToString("yyyy-MM-dd");
            Assert.AreEqual(expecteEndDate, actualEndDate.Text);

            //Validate actual LocationType with Expected LocationType
            Assert.AreEqual(ExcelLib.ReadData(rowNumber, "LocationType"), actualLocationType.Text);

            //Validate actual SkillTrade with Expected SkillTrade
            if (ExcelLib.ReadData(2, "SkillTrade") == "Credit")
                Assert.AreEqual("None Specified", actualSkillTrade.Text);
            else
                Assert.AreEqual(ExcelLib.ReadData(rowNumber, "Skill-Exchange"), actualSkillExchange.Text);

        }


        public void EditShareSkill(int rowNumber2, string Excelsheet)
        {
            ExcelLib.PopulateInCollection(Base.ExcelPath, Excelsheet);

            //Click on Share Skill button
            //ShareSkillButton.Click();
            //wait(1);


            //Enter Title 
            Title.Clear();
            Title.SendKeys(ExcelLib.ReadData(rowNumber2,"Title"));

            //Enter Description
            Description.Clear();
            Description.SendKeys(ExcelLib.ReadData(rowNumber2, "Description"));

            //Select category
            CategoryDropDown.Click();
            var selectCategory = new SelectElement(CategoryDropDown);
            selectCategory.SelectByText(ExcelLib.ReadData(rowNumber2, "Category"));
            Thread.Sleep(5000);

            //Select Subcategory
            SubCategoryDropDown.Click();
            var selectSubcategory = new SelectElement(SubCategoryDropDown);
            selectSubcategory.SelectByText(ExcelLib.ReadData(rowNumber2, "Subcategory"));


            //Clear Tags and click
            displayedTags.Click();
            Thread.Sleep(3000);

            Tags.SendKeys(ExcelLib.ReadData(rowNumber2, "Tags"));
            Tags.SendKeys(Keys.Return);

            //Select Service type
            
            string expectedServiceType = ExcelLib.ReadData(rowNumber2, "ServiceType");
            string expectedServiceValue = "0";

            if (expectedServiceType.Equals("One-off service"))
                expectedServiceValue = "1";
            else expectedServiceValue = "0";
            for (int i = 0; i < radioServiceType.Count(); i++)
            {
                string actualServiceValue = radioServiceType[i].GetAttribute("Value");
                if (expectedServiceValue.Equals(actualServiceValue))
                {
                    radioServiceType[i].Click();
                }
            }

            //Select Location type
            string expectedLocationType = ExcelLib.ReadData(rowNumber2, "LocationType");
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
            StartDateDropDown.Click();
            string startDate = ExcelLib.ReadData(rowNumber2, "StartDate");
            StartDateDropDown.SendKeys(startDate);
            Thread.Sleep(1000);
           
            //Enter End date
            string endDate = ExcelLib.ReadData(rowNumber2, "EndDate");
            EndDateDropDown.Click();
            EndDateDropDown.SendKeys(endDate);
            Thread.Sleep(2000);


            //Clear days and Enter available Days

            for (int i = 0; i < Days.Count; i++)
            {
                bool dayState = Days[i].Selected;
                if (dayState.Equals(true))
                {
                    //Unselected day
                    Days[i].Click();

                    //Clear StartTime
                    StartTime[i].SendKeys(Keys.Delete);
                    StartTime[i].SendKeys(Keys.Tab);
                    StartTime[i].SendKeys(Keys.Delete);
                    StartTime[i].SendKeys(Keys.Tab);
                    StartTime[i].SendKeys(Keys.Delete);

                    //Clear Entime
                    EndTime[i].SendKeys(Keys.Delete);
                    EndTime[i].SendKeys(Keys.Tab);
                    EndTime[i].SendKeys(Keys.Delete);
                    EndTime[i].SendKeys(Keys.Tab);
                    EndTime[i].SendKeys(Keys.Delete);
                }
            }
            wait(1);
            string expectedDays = ExcelLib.ReadData(rowNumber2, "Days");
            string indexValue = "";
            switch (expectedDays)
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
                case "Sat":  indexValue = "6";
                    break;
                default: break;
            }

            for (int i = 0; i < Days.Count; i++)
            {
                if (indexValue.Equals(Days[i].GetAttribute("index")))

                {
                    Days[i].Click();
                    StartTime[i].SendKeys(ExcelLib.ReadData(rowNumber2, "StartTime"));

                    EndTime[i].SendKeys(ExcelLib.ReadData(rowNumber2, "EndTime"));
                }
            }

            Thread.Sleep(1000);

            //Skill Trade radio button

          
            string expectedSkillTrade = ExcelLib.ReadData(rowNumber2, "SkillTrade");
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

                        RemoveSkillExchangeTags.Click();
                        SkillExchange.SendKeys(ExcelLib.ReadData(rowNumber2, "Skill-Exchange"));
                        SkillExchange.SendKeys(Keys.Return);
                    }
                    else
                    {
                        //Entering Credit amount
                        CreditAmount.Click();
                        CreditAmount.Clear();
                        CreditAmount.SendKeys(ExcelLib.ReadData(rowNumber2, "Credit"));
                    }
                }
            }

            //Click on work samples button
            Thread.Sleep(5000);
            WorkSamples.Click();
            wait(3);
            //Run AutoIt Script to Execute file uploading
            using (Process exeProcess = Process.Start(Base.AutoScriptPath))
            {
                exeProcess.WaitForExit();
            }

            Thread.Sleep(1000);

            //Select Active Option
            string expectedActiveOption = ExcelLib.ReadData(rowNumber2, "ActiveOption");
            string expectedActiveValue = "true";

            if (expectedActiveOption.Equals("Hidden"))
                expectedActiveValue = "false";

            for (int i = 0; i < radioActiveOption.Count(); i++)
            {
                string actualActiveValue = radioActiveOption[i].GetAttribute("Value");
                if (expectedActiveValue.Equals(actualActiveValue))
                    radioActiveOption[i].Click();
            }


            //Click on save
            Save.Click();
            wait(3);
        }

        public void InvalidShareskill1(int rowNumber1, string Excelsheet)
        {
            ExcelLib.PopulateInCollection(Base.ExcelPath, Excelsheet);

            //Click on Share Skill button
            Thread.Sleep(2000);
            ShareSkillButton.Click();
            wait(1);

            //Enter Title 
            Title.SendKeys(ExcelLib.ReadData(rowNumber1, "Title"));
            
            //Enter Description
            Description.SendKeys(ExcelLib.ReadData(rowNumber1, "Description"));

            //Select category
            Thread.Sleep(2000);
            var selectCategory = new SelectElement(CategoryDropDown);
            selectCategory.SelectByText(ExcelLib.ReadData(rowNumber1, "Category"));
            Thread.Sleep(5000);
           
            //Select Subcategory
            SubCategoryDropDown.Click();          
           
            //Enter tag
            Tags.Click();      
                              
           //Enter Start date
           
            Thread.Sleep(1000);
            StartDateDropDown.Click();
            string startDate = ExcelLib.ReadData(rowNumber1, "StartDate");
            StartDateDropDown.SendKeys(startDate);
            Thread.Sleep(1000);
           
            //Enter End date
            EndDateDropDown.Click();
            string endDate = ExcelLib.ReadData(rowNumber1, "EndDate");
            EndDateDropDown.SendKeys(endDate);
            Thread.Sleep(2000);

            //Enter skill exchange tags
            SkillExchange.Click();
           
            //Click on save
            Save.Click();
            wait(1);

            //message 
            message.Click();          

        }

        public void AssertTC1_ErrorMessage(int rowNumber2)
        {
            errorTitle.Equals(ExcelLib.ReadData(rowNumber2, "Title"));
            errorDescription.Equals(ExcelLib.ReadData(rowNumber2, "Description"));           
            errorSubcategory.Equals(ExcelLib.ReadData(rowNumber2, "Subcategory"));
            errorTags.Equals(ExcelLib.ReadData(rowNumber2, "Tags"));
            errorStartDate.Equals(ExcelLib.ReadData(rowNumber2, "StartDate"));
            errorEndDate.Equals(ExcelLib.ReadData(rowNumber2, "EndDate"));
            errorSkillsExchangeTags.Equals(ExcelLib.ReadData(rowNumber2, "Skill-Exchange"));
            message.Equals(ExcelLib.ReadData(rowNumber2, "Message"));
        }



        public void InvalidShareskill2(int rowNumber1, string Excelsheet)
        {

            ExcelLib.PopulateInCollection(Base.ExcelPath, Excelsheet);

            //Click on Share Skill button
            Thread.Sleep(2000);
            ShareSkillButton.Click();
            wait(1);

            //Enter Title 
            Title.SendKeys(ExcelLib.ReadData(rowNumber1, "Title"));

            //Enter Description
            Description.SendKeys(ExcelLib.ReadData(rowNumber1, "Description"));

            //Select category
            CategoryDropDown.Click();

            //Enter tag
            wait(2);
            Tags.Click();


            //Enter Start date

            Thread.Sleep(1000);
            StartDateDropDown.Click();
            string startDate = ExcelLib.ReadData(rowNumber1, "StartDate");
            StartDateDropDown.SendKeys(startDate);


            //Enter skill exchange tags
            Thread.Sleep(2000);
            SkillExchange.Click();

            //Skill Trade radio button
            string expectedSkillTrade = ExcelLib.ReadData(rowNumber1, "Credit");
            string expectedSkillValue = "false";
            Thread.Sleep(2000);
            for (int i = 0; i < radioSkillTrade.Count(); i++)
            {
                string actualSkillTradeValue = radioSkillTrade[i].GetAttribute("Value");
                if (expectedSkillValue.Equals(actualSkillTradeValue))
                {
                    //Select Skill Exchange or Credit option
                    radioSkillTrade[i].Click();
                    wait(1);
                    //Entering Credit amount
                    CreditAmount.SendKeys(ExcelLib.ReadData(rowNumber1, "Credit"));


                }
            }


            //Click on save
            Save.Click();
            wait(1);

            //message 
            message.Click();

        }

        public void AssertTC2_ErrorMessage(int rowNumber2)
        {
            errorTitle.Equals(ExcelLib.ReadData(rowNumber2, "Title"));
            errorDescription.Equals(ExcelLib.ReadData(rowNumber2, "Description"));
            errorCategory.Equals(ExcelLib.ReadData(rowNumber2, "Category"));
            errorTags.Equals(ExcelLib.ReadData(rowNumber2, "Tags"));
            errorStartDate.Equals(ExcelLib.ReadData(rowNumber2, "StartDate"));
            message.Equals(ExcelLib.ReadData(rowNumber2, "Message"));
        }

    }
}
