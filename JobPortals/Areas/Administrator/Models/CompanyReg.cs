using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobPortals.Areas.Administrator.Models
{
    
    public class CompanyReg
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Name of company")]
        public string Com_Name { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Contact person")]
        public string Contact_person { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Designation")]
        public string Com_designation { get; set; }

        public CompanyType CompanyType { get; set; }

        [Display(Name = "Company Type")]
        [ForeignKey("CompanyType")]
        public int CompanyTypeId { get; set; }


        [Required]
        [StringLength(100)]
        [Display(Name = "Contact No")]
        public string Com_number { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Address")]
        public string Com_address { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "City")]
        public string Com_city { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "country")]
        public string Com_country { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Email of company")]
        public string Com_email { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "State")]
        public string Com_state { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Company Detail’s")]
        public string Com_detail { get; set; }
    }
}