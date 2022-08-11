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
        ShareSkill shareSkillObj;
        ManageListings manageListingsObj;

        [Category("Sprint1")]
        [Test]
        public void WhenIClickShareSkillAndEnterShareSkill()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            shareSkillObj = new ShareSkill();
            shareSkillObj.EnterShareSkill();
        }

        [Test]
        public void ThenShareSkillsCreated()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            shareSkillObj = new ShareSkill();
            shareSkillObj.ValidateShareSkill();
        } 
        
        [Test]
        public void WhenIClickShareSkillAndEditShareSkill()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            shareSkillObj = new ShareSkill();
            shareSkillObj.EditShareSkill();
        }

        [Test]
        public void WhenIDeleteListings()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            manageListingsObj=new ManageListings();
            manageListingsObj.DeleteListings();
        }
    }
}