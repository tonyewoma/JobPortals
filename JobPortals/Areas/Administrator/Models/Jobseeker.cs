using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobPortals.Areas.Administrator.Models
{
    //[Bind(Exclude = "Id")]
    public class Jobseeker
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Full Name")]
        public string J_Name { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Email Address")]
        public string J_Email { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "Address")]
        public string J_Address { get; set; }

        
        [Display(Name = "Date of Birth")]
        public DateTime J_DOB { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "City")]
        public string J_City { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "Contact Number")]
        public string J_Cnumber { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "Country")]
        public string J_Country { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "Gender")]
        public string J_Gender { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "State")]
        public string J_State { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "Certificate")]
        public string Extra_achi { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "Fresher / Experience")]
        public string User_type { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "User Skill Area")]
        public string Skill_area { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Experience Details")]
        public string Exp_detail { get; set; }
    }
}