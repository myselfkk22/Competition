using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Competition.Pages;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
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
        public static string AutoScriptPath = @"D:\Competition\Competition\Competition\TestLibrary\AutoIt\AutoITScript.exe";
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
            // Screenshot
            String img = Screenshot.SaveScreenshot(GlobalDefinitions.driver, "Screenshot");

            // log with snapshot
            var exec_status = TestContext.CurrentContext.Result.Outcome.Status;
            var errorMessage = TestContext.CurrentContext.Result.Message;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace) ? ""
            : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);

            string TC_Name = TestContext.CurrentContext.Test.Name;
            string base64 = Screenshot.GetScreenshot();

            Status logStatus = Status.Pass;
            switch (exec_status)
            {
                case TestStatus.Failed:

                    logStatus = Status.Fail;
                    test.Log(Status.Fail, exec_status + errorMessage, MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64).Build());
                    break;

                case TestStatus.Skipped:

                    logStatus = Status.Skip;
                    test.Log(Status.Skip, errorMessage, MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64).Build());
                    break;

                case TestStatus.Inconclusive:

                    logStatus = Status.Warning;
                    test.Log(Status.Warning, "Test ");
                    break;

                case TestStatus.Passed:

                    logStatus = Status.Pass;
                    test.Log(Status.Pass, "Test Passed");
                    break;

                default:
                    break;
            }

            // Close the driver:)            
            GlobalDefinitions.driver.Close();
            GlobalDefinitions.driver.Quit();
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