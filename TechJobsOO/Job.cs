using System;
namespace TechJobsOO
{
    public class Job
    {
        public int Id { get; }
        private static int nextId = 1;

        public string Name { get; set; }
        public Employer EmployerName { get; set; }
        public Location EmployerLocation { get; set; }
        public PositionType JobType { get; set; }
        public CoreCompetency JobCoreCompetency { get; set; }

        // TODO: Add the two necessary constructors.
        public Job()
        {
            Id = nextId;
            nextId++;
        }
        public Job(string name, Employer employerName, Location employerLocation, PositionType jobType, CoreCompetency jobCoreCompetency) : this()
        {
            Name = name;
            EmployerName = employerName;
            EmployerLocation = employerLocation;
            JobType = jobType;
            JobCoreCompetency = jobCoreCompetency;
        }

        public override bool Equals(object obj)
        {
            return obj is Job job &&
                   Id == job.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string ToString()
        {
            string str;
            if (String.IsNullOrEmpty(Name) && EmployerName == null && EmployerLocation == null && JobType == null && JobCoreCompetency == null)
            {
                str = "OOPS! This job does not seem to exist.";
            } else {
                str = "\n" +
                $"ID: {Id}\n" +
                $"Name: {(String.IsNullOrEmpty(Name) ? "Data Not Available" : Name)}\n" +
                $"Employer: {(EmployerName != null && !String.IsNullOrEmpty(EmployerName.Value) ? EmployerName.Value : "Data Not Available")}\n" +
                $"Location: {(EmployerLocation != null && !String.IsNullOrEmpty(EmployerLocation.Value) ? EmployerLocation.Value : "Data Not Available")}\n" +
                $"Position Type: {(JobType != null && !String.IsNullOrEmpty(JobType.Value) ? JobType.Value : "Data Not Available")}\n" +
                $"Core Competency: {(JobCoreCompetency != null && !String.IsNullOrEmpty(JobCoreCompetency.Value) ? JobCoreCompetency.Value : "Data Not Available")}\n" +
                "\n";
            }
            return str;
        }
    }
}
