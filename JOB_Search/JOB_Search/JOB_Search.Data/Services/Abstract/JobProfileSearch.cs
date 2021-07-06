
using JOB_Search.Common.Models;
using System.Collections.Generic;

namespace JOB_Search.Data.Services.Abstract
{
    public abstract class JobProfileSearch
    {      
        public abstract List<JobProfilesViewModel> GetAllJobDetails();
        public abstract int AddJobDetails(JobProfiles jobProfiles);
        public abstract JobProfilesViewModel GetJobDetailsByJobId(int jobId);
        public abstract List<JobProfiles> SearchJobDetails(JobProfiles jobProfiles);
        public abstract List<JobProfilesViewModel> GetJobDetailsByAvailability(string availability);
        public abstract List<JobProfilesViewModel> GetJobDetailsByType(string jobType);
        public abstract List<JobProfilesViewModel> GetJobDetailsByExperience(int experience);
        public abstract List<JobProfilesViewModel> GetJobDetailsByCountry(string country);
        public abstract List<JobProfilesViewModel> GetJobDetailsBySkills(string skillName);
        public abstract List<JobProfilesViewModel> GetJobDetailsByLanguage(string language);
        public abstract List<JobProfilesViewModel> GetJobDetailsByPayrate(int payRate);
        public abstract string AddJobDetailsByExcelData(string fileName);  
    }
}
