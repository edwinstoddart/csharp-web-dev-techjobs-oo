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

        [TestMethod]
        public void TestForBlankLinesSurroundingData()
        {
            Job testJob = new Job("name", new Employer("employerName"), new Location("employerLocation"), new PositionType("jobType"), new CoreCompetency("jobCoreCompetency"));
            Assert.AreEqual("\n", testJob.ToString().Substring(0, 1));
            Assert.AreEqual("\n", testJob.ToString().Substring(testJob.ToString().Length - 1));
        }

        [TestMethod]
        public void TestIfFieldNamesAndValuesAreOnTheirOwnLines()
        {
            Job testJob = new Job("name", new Employer("employerName"), new Location("employerLocation"), new PositionType("jobType"), new CoreCompetency("jobCoreCompetency"));
            Assert.AreEqual("\n" +
                "ID: 2\n" +
                "Name: name\n" +
                "Employer: employerName\n" +
                "Location: employerLocation\n" +
                "Position Type: jobType\n" +
                "Core Competency: jobCoreCompetency\n" +
                "\n", testJob.ToString());
        }

        [TestMethod]
        public void TestThatEmptyFieldsReturnDataNotAvailable()
        {
            Job testJob = new Job();
            testJob.Name = "Name";
            Assert.AreEqual("\n" +
                "ID: 9\n" +
                "Name: Name\n" +
                "Employer: Data Not Available\n" +
                "Location: Data Not Available\n" +
                "Position Type: Data Not Available\n" +
                "Core Competency: Data Not Available\n" +
                "\n", testJob.ToString());
            testJob.Name = null;
            testJob.EmployerName = new Employer("Employer");
            Assert.AreEqual("\n" +
                "ID: 9\n" +
                "Name: Data Not Available\n" +
                "Employer: Employer\n" +
                "Location: Data Not Available\n" +
                "Position Type: Data Not Available\n" +
                "Core Competency: Data Not Available\n" +
                "\n", testJob.ToString());
        }

        [TestMethod]
        public void TestThatAnEmptyJobReturnsOOPSThisJobDoesNotSeemToExist()
        {
            Job testJob = new Job();
            Assert.AreEqual("OOPS! This job does not seem to exist.", testJob.ToString());
        }
    }
}