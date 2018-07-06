using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortals.Areas.Administrator.Models
{
    public class SeeProject
    {
        public int Id { get; set; }
        public CompanyType CompanyType { get; set; }
        [Display(Name = "Company Type")]
        public int CompanyTypeId { get; set; }

        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        [Display(Name = "Project Description")]
        public string ProjectDescription { get; set; }

        [Display(Name = "Skills Required")]
        public string SkillsRequired { get; set; }

        [Display(Name = "Budget")]
        public string Budget { get; set; }

        [Display(Name = "Project Deadline")]
        public DateTime ProjectDeadline { get; set; }

        public DateTime DateAdded { get; set; }

        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }
    }
}