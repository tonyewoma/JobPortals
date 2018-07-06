using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobPortals.Areas.Administrator.Models
{
    //[Bind(Exclude = "Id")]
    public class CompanyType
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Company Type")]

        public string CompanyTypeName { get; set; }

        public DateTime? DateAdded { get; set; }
    }
}