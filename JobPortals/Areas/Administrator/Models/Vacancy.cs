using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobPortals.Areas.Administrator.Models
{
    //[Bind(Exclude = "Id")]
    public class Vacancy
    {
        public int Id { get; set; }

        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Display(Name = "About Company")]
        public string AboutCompany { get; set; }

        public CompanyType CompanyType { get; set; }
        [Display(Name = "Company type")]
        public int CompanyTypeId { get; set; }

        [Required]
        [Display(Name = "Postion")]
        [StringLength(100)]
        public string Postion { get; set; }

        [Required]
        [Display(Name = "Job Type")]
        [StringLength(255)]
        public string JobType { get; set; }

        [Required]
        [Display(Name = "Qualification")]

        public string Qualification { get; set; }

        [Required]
        [Display(Name = "Experience")]
        public string Experience { get; set; }

        [Required]
        [Display(Name = "Location")]
        public string Location { get; set; }

        [Required]
        [Display(Name = "Responsibility")]
        public string Responsibility { get; set; }

        [Required]
        [Display(Name = "Skills required")]
        public string SkillsRequired { get; set; }

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

    }
}