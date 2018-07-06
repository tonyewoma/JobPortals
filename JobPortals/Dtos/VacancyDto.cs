using JobPortals.Areas.Administrator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortals.Dtos
{
    public class VacancyDto
    {
        public int Id { get; set; }

        public int CompanyRegId { get; set; }

        [Required]
        [Display(Name = "Post")]
        [StringLength(100)]
        public string Post { get; set; }

        [Required]
        [Display(Name = "Description")]
        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Number of vacancy")]

        public int No_vacancy { get; set; }

        [Required]
        [Display(Name = "Location")]
        [StringLength(100)]
        public string Location { get; set; }

        [Required]
        [Display(Name = "Experience")]
        public string Experience { get; set; }

        [Required]
        [StringLength(100)]
        public string Industry { get; set; }

        [Required]
        [StringLength(50)]
        public string Gender { get; set; }

        [Required]
        [StringLength(255)]
        public string Skill_area { get; set; }
    }
}