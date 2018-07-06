using JobPortals.Areas.Administrator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortals.Areas.Administrator.ViewModels
{
    public class SeeProjectFormViewModel
    {
        public IEnumerable<CompanyType> CompanyTypes { get; set; }
        public int Id { get; set; }

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

        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit SeeProject" : "New SeeProject";
            }
        }

        public SeeProjectFormViewModel()
        {
            Id = 0;
        }

        public SeeProjectFormViewModel(SeeProject seeProject)
        {
            Id = seeProject.Id;
            ProjectName = seeProject.ProjectName;
            ProjectDescription = seeProject.ProjectDescription;
            SkillsRequired = seeProject.SkillsRequired;
            Budget = seeProject.Budget;
            ProjectDeadline = seeProject.ProjectDeadline;
            ContactPerson = seeProject.ContactPerson;
            CompanyTypeId = seeProject.CompanyTypeId;
        }

    }
}