using Competition.Pages;
using NUnit.Framework;

namespace Competition
{
    [TestFixture]
    internal class Test: Global.Base
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello");

        }


        [Category("Sprint1")]
        [Test]
        public void WhenIClickShareSkillAndEnterShareSkill()

        {
            ShareSkill shareSkillObj;
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            shareSkillObj = new ShareSkill();
            shareSkillObj.EnterShareSkill();
        }
    }
}