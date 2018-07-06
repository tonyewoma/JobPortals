using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace JobPortals.Areas.Administrator.Models
{
    public class SmallButtonModel
    {
        public string Action { get; set; }
        public string Text { get; set; }
        public string Glyph { get; set; }
        public string ButtonType { get; set; }
        public int? Id { get; set; }
        public int? JobseekerId { get; set; }
        public int? CompanyRegId { get; set; }
        public int? VacancyId { get; set; }
        public int? CompanyTypeId { get; set; }
        public string ActionParameters {
            get {
                var param = new StringBuilder("?");
                if (Id != null && Id > 0)
                    param.Append(String.Format("{0}={1}&", "Id", Id));

                if (JobseekerId != null && JobseekerId > 0)
                    param.Append(String.Format("{0}={1}&", "jobseekerId", JobseekerId));

                if (CompanyRegId != null && CompanyRegId > 0)
                    param.Append(String.Format("{0}={1}&", "companyRegId", CompanyRegId));

                if (VacancyId != null && VacancyId > 0)
                    param.Append(String.Format("{0}={1}&", "vacancyId", VacancyId));

                if (CompanyTypeId != null && CompanyTypeId > 0)
                    param.Append(String.Format("{0}={1}&", "companyTypeId", CompanyTypeId));

                return param.ToString().Substring(0, param.Length - 1);
            }
        }
    }
} 