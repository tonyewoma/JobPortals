using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortals.Dtos
{
    public class CompanyRegDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Com_Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Contact_person { get; set; }

        [Required]
        [StringLength(255)]
        public string Com_designation { get; set; }

        public int CompanyTypeId { get; set; }

        [Required]
        [StringLength(100)]
        public string Com_number { get; set; }

        [Required]
        [StringLength(255)]
        public string Com_address { get; set; }

        [Required]
        [StringLength(100)]
        public string Com_city { get; set; }

        [Required]
        [StringLength(100)]
        public string Com_country { get; set; }

        [Required]
        [StringLength(100)]
        public string Com_email { get; set; }

        [Required]
        [StringLength(100)]
        public string Com_state { get; set; }

        [Required]
        [StringLength(100)]
        public string Com_detail { get; set; }
    }
}