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
        public void WhenIClickShareSkillAndEnterShareSkill()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            manageListingsObj = new ManageListings();
            manageListingsObj.AddShareSkill(2,"ShareSkill");
            manageListingsObj.ValidateListings(2,"ShareSkill");
        }

        [Test, Order(2)]
        public void WhenIClickShareSkillAndEditShareSkill()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            manageListingsObj = new ManageListings();
            manageListingsObj.AddShareSkill(5, "ManageListings");
            manageListingsObj.EditListings(5,6, "ManageListings");
            manageListingsObj.ValidateListings(6, "ManageListings");
        }

        [Test,Order(3)]
        public void WhenIDeleteListings()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            manageListingsObj=new ManageListings();
            manageListingsObj.DeleteListings(6,"ManageListings");
            manageListingsObj.ValidateDelete(6, "ManageListings");
        }
    }
}