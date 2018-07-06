using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortals.Dtos
{
    public class JobseekerDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string J_Name { get; set; }

        [Required]
        [StringLength(100)]
        public string J_Email { get; set; }

        [Required]
        [StringLength(150)]
        public string J_Address { get; set; }


        [Display(Name = "Date of Birth")]
        public DateTime J_DOB { get; set; }

        [Required]
        [StringLength(150)]
        public string J_City { get; set; }

        [Required]
        [StringLength(150)]
        public string J_Cnumber { get; set; }

        [Required]
        [StringLength(150)]
        public string J_Country { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "Gender")]
        public string J_Gender { get; set; }

        [Required]
        [StringLength(150)]
        public string J_State { get; set; }

        [Required]
        [StringLength(150)]
        public string Extra_achi { get; set; }

        [Required]
        [StringLength(150)]
        public string User_type { get; set; }

        [Required]
        [StringLength(150)]
        public string Skill_area { get; set; }

        [Required]
        [StringLength(250)]
        public string Exp_detail { get; set; }
    }
}