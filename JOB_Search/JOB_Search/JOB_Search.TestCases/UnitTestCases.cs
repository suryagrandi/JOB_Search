using JOB_Search.API.Controllers;
using JOB_Search.Common.Models;
using JOB_Search.Data.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace JOB_Search.TestCases
{
    public class UnitTestCases
    {
        private readonly JobSearchContext db;
        private readonly Mock<JobProfileSearch> _jobProfileSearch;
        readonly JobController _jobController;

        public UnitTestCases()
        {
            _jobProfileSearch = new Mock<JobProfileSearch>();
            _jobController = new JobController(_jobProfileSearch.Object);
            db = new JobSearchContext();
        }

        [Fact]
        public void GetAllJobDetails_Success_Case()
        {
            List<JobProfilesViewModel> jobProfiles = (from j in db.JobProfiles.ToList()
                                                      join s in db.Skill.ToList()
                                                      on j.SkillId equals s.SkillId
                                                      join l in db.Languagedetails.ToList()
                                                      on j.LanguageId equals l.LanguageId
                                                      join u in db.Users.ToList()
                                                      on j.UserId equals u.UserId
                                                      select new JobProfilesViewModel
                                                      {
                                                          JobId = j.JobId,
                                                          JobTitle = j.JobTitle,
                                                          JobDescription = j.JobDescription,
                                                          Country = j.Country,
                                                          State = j.State,
                                                          Availability = j.Availability,
                                                          ReplyRate = j.ReplyRate,
                                                          PayRate = j.PayRate,
                                                          Experience = j.Experience,
                                                          JobType = j.JobType,
                                                          SkillName = s.SkillName,
                                                          Language = l.Language

                                                      }).ToList();
            _jobProfileSearch.Setup(x => x.GetAllJobDetails()).Returns(jobProfiles);
            var result = _jobController.GetAllJobDetails() as OkObjectResult;
            List<JobProfilesViewModel> res = result.Value.GetType().GetProperty("response").GetValue(result.Value) as List<JobProfilesViewModel>;
            Assert.Equal(jobProfiles.Count, res.Count);
        }

        [Fact]
        public void GetAllJobDetails_Failure_Case()
        {
            List<JobProfilesViewModel> job = null;
            _jobProfileSearch.Setup(x => x.GetAllJobDetails()).Returns(job);
            var result = _jobController.GetAllJobDetails() as OkObjectResult;
            string res = result.Value.GetType().GetProperty("response").GetValue(result.Value) as string;
            Assert.Equal("Details not found", res);
        }

        [Fact]
        public void AddJobDetails_Success_Case()
        {
            JobProfiles job = new JobProfiles()
            {
                JobId = 9,
                JobTitle = "Developer",
                JobDescription = "kjfdgldkfjvg",
                Country = "china",
                State = "chingutti",
                Availability = "lkxfl",
                ReplyRate = 4,
                PayRate = 55,
                Experience = 6,
                JobType = "fulltime",
                UserId = 2,
                SkillId = 3,
                LanguageId = 2
            };

            _jobProfileSearch.Setup(x => x.AddJobDetails(job)).Returns(1);
            var result = _jobController.AddJobDetails(job) as OkObjectResult;
            string res = result.Value.GetType().GetProperty("response").GetValue(result.Value) as string;
            Assert.Equal("Data added successfully", res);
        }

        [Fact]
        public void AddJobDetails_Failure_Case()
        {
            JobProfiles job = null;
            _jobProfileSearch.Setup(x => x.AddJobDetails(job)).Returns(0);
            var result = _jobController.AddJobDetails(job) as OkObjectResult;
            string res = result.Value.GetType().GetProperty("response").GetValue(result.Value) as string;
            Assert.Equal("Data not registered", res);
        }

        [Fact]
        public void GetJobDetailsByJobId_Success_Case()
        {           
            int jobId = 1;
            JobProfilesViewModel jobProfiles1 = (from j in db.JobProfiles.ToList()
                                                 join s in db.Skill.ToList()
                                                 on j.SkillId equals s.SkillId
                                                 join l in db.Languagedetails.ToList()
                                                 on j.LanguageId equals l.LanguageId
                                                 where j.JobId == jobId
                                                 select new JobProfilesViewModel
                                                 {
                                                     JobId = j.JobId,
                                                     JobTitle = j.JobTitle,
                                                     JobDescription = j.JobDescription,
                                                     Country = j.Country,
                                                     State = j.State,
                                                     Availability = j.Availability,
                                                     ReplyRate = j.ReplyRate,
                                                     PayRate = j.PayRate,
                                                     Experience = j.Experience,
                                                     JobType = j.JobType,
                                                     SkillName = s.SkillName,
                                                     Language = l.Language
                                                 }).SingleOrDefault();
            _jobProfileSearch.Setup(x => x.GetJobDetailsByJobId(jobId)).Returns(jobProfiles1);
            var result = _jobController.GetJobDetailsByJobId(jobId) as OkObjectResult;
            JobProfilesViewModel res = result.Value.GetType().GetProperty("response").GetValue(result.Value) as JobProfilesViewModel;
            Assert.Equal(res, jobProfiles1);
        }

        [Fact]
        public void GetJobDetailsByJobId_Failure_Case()
        {
            int JobId = 0;
            JobProfilesViewModel j = null;
            _jobProfileSearch.Setup(x => x.GetJobDetailsByJobId(JobId)).Returns(j);
            var result = _jobController.GetJobDetailsByJobId(JobId) as OkObjectResult;
            string res = result.Value.GetType().GetProperty("response").GetValue(result.Value) as string;
            Assert.Equal("JobDetails not found", res);
        }


        [Fact]
        public void GetJobDetailsByAvailability_Success_Case()
        {
            string availability = "fulltime";
            List<JobProfilesViewModel> jobProfiles1 = (from j in db.JobProfiles.ToList()
                                                       join s in db.Skill.ToList()
                                                       on j.SkillId equals s.SkillId
                                                       join l in db.Languagedetails.ToList()
                                                       on j.LanguageId equals l.LanguageId
                                                       where j.Availability == availability.ToLower()
                                                       select new JobProfilesViewModel
                                                       {
                                                           JobId = j.JobId,
                                                           JobTitle = j.JobTitle,
                                                           JobDescription = j.JobDescription,
                                                           Country = j.Country,
                                                           State = j.State,
                                                           Availability = j.Availability,
                                                           ReplyRate = j.ReplyRate,
                                                           PayRate = j.PayRate,
                                                           Experience = j.Experience,
                                                           JobType = j.JobType,
                                                           SkillName = s.SkillName,
                                                           Language = l.Language
                                                       }).ToList();
           
            _jobProfileSearch.Setup(x => x.GetJobDetailsByAvailability(availability)).Returns(jobProfiles1);
            var result = _jobController.GetJobDetailsByAvailability(availability) as OkObjectResult;
            List<JobProfilesViewModel> res = result.Value.GetType().GetProperty("response").GetValue(result.Value) as List<JobProfilesViewModel>;
            Assert.Equal(res, jobProfiles1);
        }


        [Fact]
        public void GetJobDetailsByAvailability_Failure_Case()
        {           
            string availability = "";            
            List<JobProfilesViewModel> data = new List<JobProfilesViewModel>();            
            _jobProfileSearch.Setup(x => x.GetJobDetailsByAvailability(availability)).Returns(data);
            var result = _jobController.GetJobDetailsByAvailability(availability) as OkObjectResult;
            string res = result.Value.GetType().GetProperty("response").GetValue(result.Value) as string;
            Assert.Equal("JobDetails not found", res);
        }

        [Fact]
        public void GetJobDetailsByType_Success_Case()
        {           
            string type = "developer";
            List<JobProfilesViewModel> jobProfiles1 = (from j in db.JobProfiles.ToList()
                                                       join s in db.Skill.ToList()
                                                       on j.SkillId equals s.SkillId
                                                       join l in db.Languagedetails.ToList()
                                                       on j.LanguageId equals l.LanguageId
                                                       where j.JobType == type.ToLower()
                                                       select new JobProfilesViewModel
                                                       {
                                                           JobId = j.JobId,
                                                           JobTitle = j.JobTitle,
                                                           JobDescription = j.JobDescription,
                                                           Country = j.Country,
                                                           State = j.State,
                                                           Availability = j.Availability,
                                                           ReplyRate = j.ReplyRate,
                                                           PayRate = j.PayRate,
                                                           Experience = j.Experience,
                                                           JobType = j.JobType,
                                                           SkillName = s.SkillName,
                                                           Language = l.Language
                                                       }).ToList();
            _jobProfileSearch.Setup(x => x.GetJobDetailsByType(type)).Returns(jobProfiles1);
            var result = _jobController.GetJobDetailsByType(type) as OkObjectResult;
            List<JobProfilesViewModel> res = result.Value.GetType().GetProperty("response").GetValue(result.Value) as List<JobProfilesViewModel>;
            Assert.Equal(res, jobProfiles1);
        }


        [Fact]
        public void GetJobDetailsByType_Failure_Case()
        {
            string type = "";
            List<JobProfilesViewModel> data = new List<JobProfilesViewModel>();
            _jobProfileSearch.Setup(x => x.GetJobDetailsByType(type)).Returns(data);
            var result = _jobController.GetJobDetailsByType(type) as OkObjectResult;
            string res = result.Value.GetType().GetProperty("response").GetValue(result.Value) as string;
            Assert.Equal("JobDetails not found", res);
        }

        [Fact]
        public void GetJobDetailsByExperience_Success_Case()
        {
            int experience = 5;
            List<JobProfilesViewModel> jobProfiles1 = (from j in db.JobProfiles.ToList()
                                                       join s in db.Skill.ToList()
                                                       on j.SkillId equals s.SkillId
                                                       join l in db.Languagedetails.ToList()
                                                       on j.LanguageId equals l.LanguageId
                                                       where j.Experience == experience
                                                       select new JobProfilesViewModel
                                                       {
                                                           JobId = j.JobId,
                                                           JobTitle = j.JobTitle,
                                                           JobDescription = j.JobDescription,
                                                           Country = j.Country,
                                                           State = j.State,
                                                           Availability = j.Availability,
                                                           ReplyRate = j.ReplyRate,
                                                           PayRate = j.PayRate,
                                                           Experience = j.Experience,
                                                           JobType = j.JobType,
                                                           SkillName = s.SkillName,
                                                           Language = l.Language
                                                       }).ToList();
            _jobProfileSearch.Setup(x => x.GetJobDetailsByExperience(experience)).Returns(jobProfiles1);
            var result = _jobController.GetJobDetailsByExperience(experience) as OkObjectResult;
            List<JobProfilesViewModel> res = result.Value.GetType().GetProperty("response").GetValue(result.Value) as List<JobProfilesViewModel>;
            Assert.Equal(res, jobProfiles1);
        }


        [Fact]
        public void GetJobDetailsByExperience_Failure_Case()
        {
            int experience = 0;
            List<JobProfilesViewModel> data = new List<JobProfilesViewModel>();
            _jobProfileSearch.Setup(x => x.GetJobDetailsByExperience(experience)).Returns(data);
            var result = _jobController.GetJobDetailsByExperience(experience) as OkObjectResult;
            string res = result.Value.GetType().GetProperty("response").GetValue(result.Value) as string;
            Assert.Equal("JobDetails not found", res);
        }
        [Fact]
        public void GetJobDetailsByCountry_Success_Case()
        {
            string country ="india";
            List<JobProfilesViewModel> jobProfiles1 = (from j in db.JobProfiles.ToList()
                                                       join s in db.Skill.ToList()
                                                       on j.SkillId equals s.SkillId
                                                       join l in db.Languagedetails.ToList()
                                                       on j.LanguageId equals l.LanguageId
                                                       where j.Country == country.ToLower()
                                                       select new JobProfilesViewModel
                                                       {
                                                           JobId = j.JobId,
                                                           JobTitle = j.JobTitle,
                                                           JobDescription = j.JobDescription,
                                                           Country = j.Country,
                                                           State = j.State,
                                                           Availability = j.Availability,
                                                           ReplyRate = j.ReplyRate,
                                                           PayRate = j.PayRate,
                                                           Experience = j.Experience,
                                                           JobType = j.JobType,
                                                           SkillName = s.SkillName,
                                                           Language = l.Language
                                                       }).ToList();
            _jobProfileSearch.Setup(x => x.GetJobDetailsByCountry(country)).Returns(jobProfiles1);
            var result = _jobController.GetJobDetailsByCountry(country) as OkObjectResult;
            List<JobProfilesViewModel> res = result.Value.GetType().GetProperty("response").GetValue(result.Value) as List<JobProfilesViewModel>;
            Assert.Equal(res, jobProfiles1);
        }


        [Fact]
        public void GetJobDetailsByCountry_Failure_Case()
        {
            string country =  "";
            List<JobProfilesViewModel> data = new List<JobProfilesViewModel>();
            _jobProfileSearch.Setup(x => x.GetJobDetailsByCountry(country)).Returns(data);
            var result = _jobController.GetJobDetailsByCountry(country) as OkObjectResult;
            string res = result.Value.GetType().GetProperty("response").GetValue(result.Value) as string;
            Assert.Equal("JobDetails not found", res);
        }


        [Fact]
        public void GetJobDetailsByPayrate_Success_Case()
        {
            int payRate = 45;
            List<JobProfilesViewModel> jobProfiles1 = (from j in db.JobProfiles.ToList()
                                                       join s in db.Skill.ToList()
                                                       on j.SkillId equals s.SkillId
                                                       join l in db.Languagedetails.ToList()
                                                       on j.LanguageId equals l.LanguageId
                                                       where j.PayRate == payRate
                                                       select new JobProfilesViewModel
                                                       {
                                                           JobId = j.JobId,
                                                           JobTitle = j.JobTitle,
                                                           JobDescription = j.JobDescription,
                                                           Country = j.Country,
                                                           State = j.State,
                                                           Availability = j.Availability,
                                                           ReplyRate = j.ReplyRate,
                                                           PayRate = j.PayRate,
                                                           Experience = j.Experience,
                                                           JobType = j.JobType,
                                                           SkillName = s.SkillName,
                                                           Language = l.Language
                                                       }).ToList();
            _jobProfileSearch.Setup(x => x.GetJobDetailsByPayrate(payRate)).Returns(jobProfiles1);
            var result = _jobController.GetJobDetailsByPayrate(payRate) as OkObjectResult;
            List<JobProfilesViewModel> res = result.Value.GetType().GetProperty("response").GetValue(result.Value) as List<JobProfilesViewModel>;
            Assert.Equal(res, jobProfiles1);
        }

        [Fact]
        public void GetJobDetailsByPayrate_Failure_Case()
        {
            int payRate =  0;
            List<JobProfilesViewModel> data = new List<JobProfilesViewModel>();
            _jobProfileSearch.Setup(x => x.GetJobDetailsByPayrate(payRate)).Returns(data);
            var result = _jobController.GetJobDetailsByPayrate(payRate) as OkObjectResult;
            string res = result.Value.GetType().GetProperty("response").GetValue(result.Value) as string;
            Assert.Equal("JobDetails not found", res);
        }
      
        [Fact]
        public void GetJobDetailsBySkills_Success_Case()
        {
            string skillName = "mvc";
            List<JobProfilesViewModel> job = (from j in db.JobProfiles.ToList()
                                     join s in db.Skill.ToList()
                                     on j.SkillId equals s.SkillId
                                     join l in db.Languagedetails.ToList()
                                     on j.LanguageId equals l.LanguageId
                                     where s.SkillName == skillName.ToLower()
                                     select new JobProfilesViewModel
                                     {
                                         JobId = j.JobId,
                                         JobTitle = j.JobTitle,
                                         JobDescription = j.JobDescription,
                                         Country = j.Country,
                                         State = j.State,
                                         Availability = j.Availability,
                                         ReplyRate = j.ReplyRate,
                                         PayRate = j.PayRate,
                                         Experience = j.Experience,
                                         JobType = j.JobType,
                                         SkillName = s.SkillName,
                                         Language = l.Language
                                     }).ToList();
            _jobProfileSearch.Setup(x => x.GetJobDetailsBySkills(skillName)).Returns(job);
            var result = _jobController.GetJobDetailsBySkills(skillName) as OkObjectResult;
            List<JobProfilesViewModel> res = result.Value.GetType().GetProperty("response").GetValue(result.Value) as List<JobProfilesViewModel>;
            Assert.Equal(res, job);
        }

        [Fact]
        public void GetJobDetailsBySkills_Failure_Case()
        {
            string skillName = "";
            List<JobProfilesViewModel> data = new List<JobProfilesViewModel>();                      
            _jobProfileSearch.Setup(x => x.GetJobDetailsBySkills(skillName)).Returns(data);
            var result = _jobController.GetJobDetailsBySkills(skillName) as OkObjectResult;
            string res = result.Value.GetType().GetProperty("response").GetValue(result.Value) as string;
            Assert.Equal("JobDetails not found", res);
        }

        [Fact]
        public void GetJobDetailsByLanguage_Success_Case()
        {
            string language = "english";

            List<JobProfilesViewModel> job = (from j in db.JobProfiles.ToList()
                                              join s in db.Skill.ToList()
                                              on j.SkillId equals s.SkillId
                                              join l in db.Languagedetails.ToList()
                                              on j.LanguageId equals l.LanguageId
                                              where l.Language == language.ToLower()
                                              select new JobProfilesViewModel
                                              {
                                                  JobId = j.JobId,
                                                  JobTitle = j.JobTitle,
                                                  JobDescription = j.JobDescription,
                                                  Country = j.Country,
                                                  State = j.State,
                                                  Availability = j.Availability,
                                                  ReplyRate = j.ReplyRate,
                                                  PayRate = j.PayRate,
                                                  Experience = j.Experience,
                                                  JobType = j.JobType,
                                                  SkillName = s.SkillName,
                                                  Language = l.Language
                                              }).ToList();
            _jobProfileSearch.Setup(x => x.GetJobDetailsByLanguage(language)).Returns(job);
            var result = _jobController.GetJobDetailsByLanguage(language) as OkObjectResult;
            List<JobProfilesViewModel> res = result.Value.GetType().GetProperty("response").GetValue(result.Value) as List<JobProfilesViewModel>;
            Assert.Equal(res, job);
        }

        [Fact]
        public void GetJobDetailsByLanguage_Failure_Case()
        {
            string language = "";
            List<JobProfilesViewModel> data = new List<JobProfilesViewModel>();
            _jobProfileSearch.Setup(x => x.GetJobDetailsByLanguage(language)).Returns(data);
            var result = _jobController.GetJobDetailsByLanguage(language) as OkObjectResult;
            string res = result.Value.GetType().GetProperty("response").GetValue(result.Value) as string;
            Assert.Equal("JobDetails not found", res);
        }

        [Fact]
        public void AddJobDetailsByExcelData_Success_Case()
        {
            string fileName = "Utilies.csv";
            string message = "Data inserted successfully";
            _jobProfileSearch.Setup(x => x.AddJobDetailsByExcelData(fileName)).Returns(message);
            var result = _jobController.AddJobDetailsByExcelData(fileName) as OkObjectResult;
            string res = result.Value.GetType().GetProperty("response").GetValue(result.Value) as string;
            Assert.Equal(message, res);
        }

        [Fact]
        public void AddJobDetailsByExcelData_Failure_Case()
        {
            string fileName = "";
            string message = null;
            _jobProfileSearch.Setup(x => x.AddJobDetailsByExcelData(fileName)).Returns(message);
            var result = _jobController.AddJobDetailsByExcelData(fileName) as OkObjectResult;
            string res = result.Value.GetType().GetProperty("response").GetValue(result.Value) as string;
            Assert.Equal("Record not inserted", res);
        }

    }
}
