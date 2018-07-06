using JobPortals.Areas.Administrator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobPortals.Areas.Administrator.ViewModels
{
    public class CompanyTypeFormViewModel
    {
        public IEnumerable<CompanyType> CompanyTypes { get; set; }
        public CompanyReg CompanyReg { get; set; }
    }
}