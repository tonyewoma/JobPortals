using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortals.Dtos
{
    public class CompanyTypeDto
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Company Type")]

        public string CompanyTypeName { get; set; }

        public DateTime DateAdded { get; set; }
    }
}