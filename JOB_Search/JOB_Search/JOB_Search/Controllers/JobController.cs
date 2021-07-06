using JOB_Search.Common.Models;
using JOB_Search.Data.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace JOB_Search.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        #region Global variables declarartion
        private readonly JobProfileSearch _jobProfileSearch;
        #endregion

        #region Constructor with declared parameters
        public JobController(JobProfileSearch jobProfileSearch)
        {
            _jobProfileSearch = jobProfileSearch;
        }
        #endregion

        #region This method is to get all Jobdetails in the database
        [HttpGet("GetAllJobDetails")]
        public IActionResult GetAllJobDetails()
        {
            List<JobProfilesViewModel> data = _jobProfileSearch.GetAllJobDetails();
            if (data != null)
            {
                return Ok(new { status = 200, success = true, response = data });
            }
            else
            {
                return Ok(new { status = 204, success = false, response = "Details not found" });
            }
        }
        #endregion

        #region This method is to add an Job detail based on requirement
        [HttpPost("AddJobDetails")]
        public IActionResult AddJobDetails(JobProfiles jobProfiles)
        {
            int data = _jobProfileSearch.AddJobDetails(jobProfiles);
            if (data > 0)
            {
                return Ok(new { status = 200, success = true, response = "Data added successfully" });
            }
            else
            {
                return Ok(new { status = 400, success = false, response = "Data not registered" });
            }
        }
        #endregion

        #region This method is to get the JobDetails based upon the JobId
        [HttpPost("GetJobDetailsByJobId")]
        public IActionResult GetJobDetailsByJobId(int jobId)
        {
            JobProfilesViewModel data = _jobProfileSearch.GetJobDetailsByJobId(jobId);
            if (data != null)
            {
                return Ok(new { status = 200, success = true, response = data });
            }
            else
            {
                return Ok(new { status = 400, success = false, response = "JobDetails not found" });
            }
        }
        #endregion

        #region This method is to get the search the Job details based upon various requirements
        [HttpPost("SearchJobDetails")]
        public IActionResult SearchJobDetails(JobProfiles jobProfiles)
        {
            List<JobProfiles> data = _jobProfileSearch.SearchJobDetails(jobProfiles);
            if (data.Count > 0)
            {
                return Ok(new { status = 200, success = true, response = data });
            }
            else
            {
                return Ok(new { status = 400, success = false, response = "JobDetails not found" });
            }
        }
        #endregion

        #region This method is to get the JobDetails based upon the type
        [HttpPost("GetJobDetailsByType")]
        public IActionResult GetJobDetailsByType(string jobType)
        {
            List<JobProfilesViewModel> data = _jobProfileSearch.GetJobDetailsByType(jobType);
            if (data.Count > 0)
            {
                return Ok(new { status = 200, success = true, response = data });
            }
            else
            {
                return Ok(new { status = 400, success = false, response = "JobDetails not found" });
            }
        }
        #endregion

        #region This method is to get the JobDetails based upon the experience
        [HttpPost("GetJobDetailsByExperience")]
        public IActionResult GetJobDetailsByExperience(int experience)
        {
            List<JobProfilesViewModel> data = _jobProfileSearch.GetJobDetailsByExperience(experience);
            if (data.Count > 0)
            {
                return Ok(new { status = 200, success = true, response = data });
            }
            else
            {
                return Ok(new { status = 400, success = false, response = "JobDetails not found" });
            }
        }
        #endregion

        #region This method is to get the JobDetails based upon the Country
        [HttpPost("GetJobDetailsByCountry")]
        public IActionResult GetJobDetailsByCountry(string country)
        {
            List<JobProfilesViewModel> data = _jobProfileSearch.GetJobDetailsByCountry(country);
            if (data.Count > 0)
            {
                return Ok(new { status = 200, success = true, response = data });
            }
            else
            {
                return Ok(new { status = 400, success = false, response = "JobDetails not found" });
            }
        }
        #endregion


        #region This method is to get the JobDetails based upon the skills
        [HttpPost("GetJobDetailsBySkills")]
        public IActionResult GetJobDetailsBySkills(string skillName)
        {
            List<JobProfilesViewModel> data = _jobProfileSearch.GetJobDetailsBySkills(skillName);
            if (data.Count > 0)
            {
                return Ok(new { status = 200, success = true, response = data });
            }
            else
            {
                return Ok(new { status = 400, success = false, response = "JobDetails not found" });
            }
        }
        #endregion

        #region This method is to get the JobDetails based upon the language
        [HttpPost("GetJobDetailsByLanguage")]
        public IActionResult GetJobDetailsByLanguage(string language)
        {
            List<JobProfilesViewModel> data = _jobProfileSearch.GetJobDetailsByLanguage(language);
            if (data.Count > 0)
            {
                return Ok(new { status = 200, success = true, response = data });
            }
            else
            {
                return Ok(new { status = 400, success = false, response = "JobDetails not found" });
            }
        }
        #endregion

        #region This method is to get the JobDetails based upon the payrate
        [HttpPost("GetJobDetailsByPayrate")]
        public IActionResult GetJobDetailsByPayrate(int payRate)
        {
            List<JobProfilesViewModel> data = _jobProfileSearch.GetJobDetailsByPayrate(payRate);
            if (data.Count > 0)
            {
                return Ok(new { status = 200, success = true, response = data });
            }
            else
            {
                return Ok(new { status = 400, success = false, response = "JobDetails not found" });
            }
        }
        #endregion

        #region This method is to get the JobDetails based upon the availability
        [HttpPost("GetJobDetailsByAvailability")]
        public IActionResult GetJobDetailsByAvailability(string availability)
        {
            List<JobProfilesViewModel> data = _jobProfileSearch.GetJobDetailsByAvailability(availability);
            if (data.Count > 0)
            {
                return Ok(new { status = 200, success = true, response = data });
            }
            else
            {
                return Ok(new { status = 400, success = false, response = "JobDetails not found" });
            }
        }
        #endregion

        #region This method is to add bulk data from Excel
        [HttpPost("AddJobDetailsByExcelData")]
        public IActionResult AddJobDetailsByExcelData(string fileName)
        {
            string value = _jobProfileSearch.AddJobDetailsByExcelData(fileName);
            if (value != null)
            {
                return Ok(new { status = 200, success = true, response = "Data inserted successfully" });
            }
            else
            {
                return Ok(new { status = 400, success = false, response = "Record not inserted" });
            }
        }
        #endregion

    }
}
