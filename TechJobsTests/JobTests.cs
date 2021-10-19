using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechJobsOO;

namespace TechJobsTests
{
    [TestClass]
    public class JobTests
    {
        [TestMethod]
        public void TestSettingJobId()
        {
            Job testJob1 = new Job();
            Job testJob2 = new Job();

            Assert.AreEqual(testJob1.Id, (testJob2.Id - 1));
        }

        [TestMethod]
        public void TestJobConstructorSetsAllFields()
        {
            Job testJob = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));

            Assert.AreEqual("Product tester", testJob.Name);
            Assert.AreEqual("ACME", testJob.EmployerName.Value);
            Assert.AreEqual("Desert", testJob.EmployerLocation.Value);
            Assert.AreEqual("Quality control", testJob.JobType.Value);
            Assert.AreEqual("Persistence", testJob.JobCoreCompetency.ToString());
        }

        [TestMethod]
        public void TestJobsForEquality()
        {
            Job testJob1 = new Job("Same", new Employer("Identical"), new Location("Corresponding"), new PositionType("Duplicate"), new CoreCompetency("Paired"));
            Job testJob2 = new Job("Same", new Employer("Identical"), new Location("Corresponding"), new PositionType("Duplicate"), new CoreCompetency("Paired"));

            Assert.IsFalse(testJob1.Equals(testJob2));
        }
    }
}