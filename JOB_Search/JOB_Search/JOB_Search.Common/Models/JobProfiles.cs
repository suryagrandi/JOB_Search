using System.ComponentModel.DataAnnotations;

namespace JOB_Search.Common.Models
{
    public partial class JobProfiles
    {
        [Required(ErrorMessage = "JobId is required")]
        public int JobId { get; set; }

        [Required(ErrorMessage = "JobTitle is required")]
        public string JobTitle { get; set; }
        
        [Required(ErrorMessage = "JobDescription is required")]
        public string JobDescription { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }

        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }

        [Required(ErrorMessage = "Availability is required")]
        public string Availability { get; set; }

        [Required(ErrorMessage = "ReplyRate is required")]
        public int? ReplyRate { get; set; }

        [Required(ErrorMessage = "Payrate is required")]
        public int? PayRate { get; set; }

        [Required(ErrorMessage = "Experience is required")]
        public int? Experience { get; set; }

        [Required(ErrorMessage = "Jobtype is required")]
        public string JobType { get; set; }

        [Required(ErrorMessage = "Userid is required")]
        public int? UserId { get; set; }

        [Required(ErrorMessage = "SkillId is required")]
        public int? SkillId { get; set; }

        [Required(ErrorMessage = "LanguageId is required")]
        public int? LanguageId { get; set; }
    }

    public partial class JobProfilesViewModel
    {
        public int JobId { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Availability { get; set; }
        public int? ReplyRate { get; set; }
        public int? PayRate { get; set; }
        public int? Experience { get; set; }
        public string JobType { get; set; }
        //public int? UserName { get; set; }
        public string SkillName { get; set; }
        public string Language { get; set; }
    }

}
