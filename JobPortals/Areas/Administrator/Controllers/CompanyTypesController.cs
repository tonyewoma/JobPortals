using JobPortals.Areas.Administrator.Models;
using JobPortals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobPortals.Areas.Administrator.Controllers
{
    public class CompanyTypesController : Controller
    {
        private ApplicationDbContext _context;
        public CompanyTypesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Authorize(Roles = RoleName.CanManageJobs)]
        public ActionResult Index()
        {
            var companyTypes = _context.CompanyTypes.ToList();

            return View(companyTypes);
        }

        [Authorize(Roles = RoleName.CanManageJobs)]
        public ActionResult New()
        {
            return View("CompanyTypeForm");
        }

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageJobs)]
        public ActionResult Save(CompanyType companyType)
        {
            if (companyType.Id == 0)
            {
                _context.CompanyTypes.Add(companyType);
                companyType.DateAdded = DateTime.Now;
            }
               
            else
            {
                var companyTypeInDb = _context.CompanyTypes.Single(c => c.Id == companyType.Id);
                companyTypeInDb.CompanyTypeName = companyType.CompanyTypeName;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "CompanyTypes");
        }

        [Authorize(Roles = RoleName.CanManageJobs)]
        public ActionResult Edit(int id)
        {
            var companyType = _context.CompanyTypes.SingleOrDefault(c => c.Id == id);

            if (companyType == null)
                return HttpNotFound();

            return View("CompanyTypeForm", companyType);
        }

        [Authorize(Roles = RoleName.CanManageJobs)]
        public ActionResult Details(int id)
        {
            var companyType = _context.CompanyTypes.SingleOrDefault(c => c.Id == id);

            if (companyType == null)
                return HttpNotFound();

            return View(companyType);
        }
        
    }
}