using Competition.Pages;
using NUnit.Framework;

namespace Competition
{
    [TestFixture]
    internal class Test : Global.Base
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello");

        }

        ManageListings manageListingsObj;

        [Category("Sprint1")]
        [Test, Order(1)]
        public void TC1_EnterShareSkill()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            manageListingsObj = new ManageListings();
            manageListingsObj.AddShareSkill(2, "ManageListings");

        }
        [Test, Order(2)]
        public void Tc2_ValidateEnterListings()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            manageListingsObj = new ManageListings();
            manageListingsObj.ValidateListings(2, "ManageListings");
        }


        [Test, Order(3)]
        public void TC3_EditShareSkill()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            manageListingsObj = new ManageListings();
            manageListingsObj.EditListings(2, 3, "ManageListings");
           
        }
        [Test, Order(4)]
        public void TC4_ValidateEditListings()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            manageListingsObj = new ManageListings();
            manageListingsObj.ValidateListings(3, "ManageListings");
        }
        [Test, Order(5)]
        public void TC5_DeleteListings()
        {

            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            manageListingsObj = new ManageListings();
            manageListingsObj.DeleteListings(3, "ManageListings");
        }

        [Test,Order(6)]
        public void TC6_ValidateDeleteListings()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            manageListingsObj=new ManageListings();
            manageListingsObj.ValidateDelete(3, "ManageListings");
        }

        [Test, Order(7)]
        public void TC7_InvaidTest1()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            manageListingsObj = new ManageListings();
            manageListingsObj.InvalidTestListings1(2,3, "InvalidTest");
        }

        [Test, Order(8)]
        public void TC8_InvalidTest2()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            manageListingsObj = new ManageListings();
            manageListingsObj.InvalidTestListings2(4, 5, "InvalidTest");
        }


    }
}