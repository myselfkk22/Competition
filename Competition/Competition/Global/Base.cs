using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Competition.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Competition.Global.GlobalDefinitions;


namespace Competition.Global
{
    class Base
    {
      
        #region To access Path from resource file
        public static int Browser = 2;
        public static string excelPath = @"D:\Competition\Competition\Competition\ExcelData\TestData.xlsx";
        public static string AutoScriptPath = @"D:\Competition\Competition\Competition\TestLibrary\AutoIt\UploadScript.exe";
        public static string ScreenshotPath = @"D:\Competition\Competition\Competition\TestLibrary\ScreenShots\";
        public static string ReportPath = @"D:\Competition\Competition\Competition\TestLibrary\TestReports\";
        public static string IsLogin = "true";
        #endregion

        #region reports
        public static AventStack.ExtentReports.ExtentTest test;
        public static AventStack.ExtentReports.ExtentReports extent;

        public static string ExcelPath { get => excelPath; set => excelPath = value; }
        #endregion

        [OneTimeSetUp]
        public void ExtentStart()
        {
            #region Initialise Reports

            String reportName = System.IO.Directory.GetParent(@"../../../").FullName
                + Path.DirectorySeparatorChar + "TestLibrary/TestReports"
                + Path.DirectorySeparatorChar + "Report_" + DateTime.Now.ToString("_dd-MM-YYYY_HHmmss");
            
            //Start reporters
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(reportName);
            htmlReporter.Config.DocumentTitle = "Automation Report"; //Title of the report
            htmlReporter.Config.ReportName = "Functional reports Results"; //Name of the report
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;

            extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Hostname", "LocalHost");
            extent.AddSystemInfo("Tester Name", "Krishna");
            extent.AddSystemInfo("Browser", "Chrome");

            #endregion


        }

        #region setup and tear down
        [SetUp]
        public void Inititalize()
        {

            switch (Browser)
            {

                case 1:
                    GlobalDefinitions.driver = new FirefoxDriver();
                    break;
                case 2:
                    GlobalDefinitions.driver = new ChromeDriver();
                    GlobalDefinitions.driver.Manage().Window.Maximize();
                    break;
            }

            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignIn");
            GlobalDefinitions.driver.Navigate().GoToUrl(ExcelLib.ReadData(2, "Url"));

            
           
            if (IsLogin == "true")
            {
                SignIn obj = new SignIn();
                obj.LoginSteps();
            }
            else
            {
                SignUp obj = new SignUp();
                obj.Register();
            }

        }

       
        [TearDown]
        public void TearDown()
        {
            //var test = extent.CreateTest("MyFirstTest", "Sample description");
            //Screenshot
           String img = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Screenshot");
           
            test.Log(Status.Info, "Image example: " + img);

            // log with snapshot

            test.Fail("details", MediaEntityBuilder.CreateScreenCaptureFromPath("screenshot.png").Build());

            // test with snapshot
            test.AddScreenCaptureFromPath("screenshot.png");

            // end test. (Reports)
            //extent.endTest(test);



            // Close the driver:)            
            //GlobalDefinitions.driver.Close();
            //GlobalDefinitions.driver.Quit();
        }
       
        [OneTimeTearDown]
        public void ExtentClose()
        {
            // calling Flush writes everything to the log file (Reports)
            extent.Flush();
        }
        #endregion
    }

}