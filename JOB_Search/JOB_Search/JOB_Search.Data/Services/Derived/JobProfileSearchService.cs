using JOB_Search.Common.Models;
using JOB_Search.Data.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JOB_Search.Data.Services.Derived
{
    public class JobProfileSearchService : JobProfileSearch
    {
        readonly JobSearchContext db = new JobSearchContext();

        public override List<JobProfilesViewModel> GetAllJobDetails()
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
                                                 SkillName=s.SkillName,
                                                 Language = l.Language,
                                                
                                             }).ToList();
            return jobProfiles;
        }

        public override int AddJobDetails(JobProfiles jobProfiles)
        {
            db.JobProfiles.Add(jobProfiles);
            int insertedValue = db.SaveChanges();
            return insertedValue;
        }

        public override JobProfilesViewModel GetJobDetailsByJobId(int jobId)
        {
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
            return jobProfiles1;
        }

        public override List<JobProfiles> SearchJobDetails(JobProfiles jobProfiles)
        {
            List<JobProfiles> jobProfiles1 = db.JobProfiles.Where(x => x.Availability == jobProfiles.Availability.ToLower() || x.SkillId == jobProfiles.SkillId
            || x.JobType == jobProfiles.JobType.ToLower() || x.JobId == jobProfiles.JobId || x.Experience == jobProfiles.Experience
            || x.Country == jobProfiles.Country.ToLower() || x.LanguageId == jobProfiles.LanguageId || x.PayRate == jobProfiles.PayRate).ToList();
            return jobProfiles1;
        }

        public override List<JobProfilesViewModel> GetJobDetailsByType(string jobType)
        {
            List<JobProfilesViewModel> jobProfiles1 = (from j in db.JobProfiles.ToList()
                                                       join s in db.Skill.ToList()
                                                       on j.SkillId equals s.SkillId
                                                       join l in db.Languagedetails.ToList()
                                                       on j.LanguageId equals l.LanguageId
                                                       where j.JobType == jobType.ToLower()
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
            return jobProfiles1;
        }

        public override List<JobProfilesViewModel> GetJobDetailsByExperience(int experience)
        {
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
            return jobProfiles1;
        }

        public override List<JobProfilesViewModel> GetJobDetailsByCountry(string country)
        {
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
            return jobProfiles1;
        }

        public override List<JobProfilesViewModel> GetJobDetailsBySkills(string skillName)
        {
            List<JobProfilesViewModel> jobProfiles1 = (from j in db.JobProfiles.ToList()
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
            return jobProfiles1;
        }

        public override List<JobProfilesViewModel> GetJobDetailsByLanguage(string language)
        {
            List<JobProfilesViewModel> jobProfiles1 = (from j in db.JobProfiles.ToList()
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
            return jobProfiles1;
        }

        public override List<JobProfilesViewModel> GetJobDetailsByPayrate(int payRate)
        {
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
            return jobProfiles1;
        }

        public override List<JobProfilesViewModel> GetJobDetailsByAvailability(string availability)
        {
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
            return jobProfiles1;
        }

        public override string AddJobDetailsByExcelData(string fileName)
        {
            string location = @"C:\Users\gsurya\Downloads\";
            string filepath = location + fileName;
            System.IO.File.ReadAllLines(filepath)
                                                     .Skip(1)
                                                     .Select(x => ConvertCSVDataintoModel(x))
                                                     .ToList();
            return "Data inserted successfully";
        }

        public int ConvertCSVDataintoModel(string csvData)
        {
            string[] values = csvData.Split(',');
            int dataInserted = 0;
            JobProfiles j = new JobProfiles();
            List<JobProfiles> listData = db.JobProfiles.ToList();
            JobProfiles data = listData.Where(x => x.JobId == Convert.ToInt32(values[0])).FirstOrDefault();
            if (data == null)
            {
                j.JobId = Convert.ToInt32(values[0]);
                j.JobTitle = values[1].ToString();
                j.JobDescription = values[2].ToString();
                j.Country = values[3].ToString();
                j.State = values[4].ToString();
                j.Availability = values[5].ToString();
                j.ReplyRate = Convert.ToInt32(values[6]);
                j.PayRate = Convert.ToInt32(values[7]);
                j.Experience = Convert.ToInt32(values[8]);
                j.JobType = values[9].ToString();
                j.UserId = Convert.ToInt32(values[10]);
                j.SkillId = Convert.ToInt32(values[11]);
                j.LanguageId = Convert.ToInt32(values[12]);
                db.JobProfiles.Add(j);
                dataInserted = db.SaveChanges();
            }
            return dataInserted;
        }

    }
}
