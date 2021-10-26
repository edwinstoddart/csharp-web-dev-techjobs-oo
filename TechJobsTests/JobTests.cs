using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechJobsOO;

namespace TechJobsTests
{
    [TestClass]
    public class JobTests
    {
        // TODO: Use [TestInitialize] to reduce redundancy in the tests.
        Job testJob0;
        Job testJob1;
        Job testJob2;
        [TestInitialize]
        public void CreateJobObjects()
        {
            testJob0 = new Job();
            testJob1 = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
            testJob2 = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
        }

        [TestMethod]
        public void TestSettingJobId()
        {
            Assert.AreEqual(testJob1.Id, (testJob2.Id - 1));
        }

        [TestMethod]
        public void TestJobConstructorSetsAllFields()
        {
            Assert.AreEqual("Product tester", testJob1.Name);
            Assert.AreEqual("ACME", testJob1.EmployerName.Value);
            Assert.AreEqual("Desert", testJob1.EmployerLocation.Value);
            Assert.AreEqual("Quality control", testJob1.JobType.Value);
            Assert.AreEqual("Persistence", testJob1.JobCoreCompetency.ToString());
        }

        [TestMethod]
        public void TestTwoSeparateJobObjectsWithSameJobFieldsForEquality()
        {
            Assert.IsFalse(testJob1.Equals(testJob2));
        }

        [TestMethod]
        public void TestForBlankLinesSurroundingData()
        {
            Assert.AreEqual("\n", testJob1.ToString().Substring(0, 1));
            Assert.AreEqual("\n", testJob1.ToString().Substring(testJob1.ToString().Length - 1));
        }

        [TestMethod]
        public void TestIfFieldNamesAndValuesAreOnTheirOwnLines()
        {
            Assert.AreEqual("\n" +
                $"ID: {testJob1.Id}\n" +
                $"Name: {testJob1.Name}\n" +
                $"Employer: {testJob1.EmployerName}\n" +
                $"Location: {testJob1.EmployerLocation}\n" +
                $"Position Type: {testJob1.JobType}\n" +
                $"Core Competency: {testJob1.JobCoreCompetency}\n" +
                "\n", testJob1.ToString());
        }

        [TestMethod]
        public void TestThatEmptyFieldsReturnDataNotAvailable()
        {
            testJob0.Name = "Name";
            Assert.AreEqual("\n" +
                $"ID: {testJob0.Id}\n" +
                $"Name: {testJob0.Name}\n" +
                $"Employer: {testJob0.dataNotFound}\n" +
                $"Location: {testJob0.dataNotFound}\n" +
                $"Position Type: {testJob0.dataNotFound}\n" +
                $"Core Competency: {testJob0.dataNotFound}\n" +
                "\n", testJob0.ToString());
            testJob0.Name = null;
            testJob0.EmployerName = new Employer("Employer");
            Assert.AreEqual("\n" +
                $"ID: {testJob0.Id}\n" +
                $"Name: {testJob0.dataNotFound}\n" +
                $"Employer: {testJob0.EmployerName}\n" +
                $"Location: {testJob0.dataNotFound}\n" +
                $"Position Type: {testJob0.dataNotFound}\n" +
                $"Core Competency: {testJob0.dataNotFound}\n" +
                "\n", testJob0.ToString());
            testJob0.EmployerName = null;
        }

        [TestMethod]
        public void TestThatAnEmptyJobReturnsOOPSThisJobDoesNotSeemToExist()
        {
            Job testJob = new Job();
            Assert.AreEqual("OOPS! This job does not seem to exist.", testJob.ToString());
        }
    }
}