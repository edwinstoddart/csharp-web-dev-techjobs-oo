using System;
namespace TechJobsOO
{
    public class Job
    {
        public int Id { get; }
        private static int nextId = 1;

        public string Name { get; set; }
        public string dataNotFound = "Data Not Available";
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
            if (String.IsNullOrEmpty(Name) && !IsDataAvailable(EmployerName) && !IsDataAvailable(EmployerLocation)
                && !IsDataAvailable(JobType) && !IsDataAvailable(JobCoreCompetency))
            {
                str = "OOPS! This job does not seem to exist.";
            } else {
                str = "\n" +
                $"ID: {Id}\n" +
                $"Name: {(String.IsNullOrEmpty(Name) ? dataNotFound : Name)}\n" +
                $"Employer: {(IsDataAvailable(EmployerName) ? EmployerName.Value : dataNotFound)}\n" +
                $"Location: {(IsDataAvailable(EmployerLocation) ? EmployerLocation.Value : dataNotFound)}\n" +
                $"Position Type: {(IsDataAvailable(JobType) ? JobType.Value : dataNotFound)}\n" +
                $"Core Competency: {(IsDataAvailable(JobCoreCompetency) ? JobCoreCompetency.Value : dataNotFound)}\n" +
                "\n";
            }
            return str;
        }

        private bool IsDataAvailable(JobField field)
        {
            if (field != null && !String.IsNullOrEmpty(field.Value))
            {
                return true;
            } else {
                return false;
            }
        }
    }
}
