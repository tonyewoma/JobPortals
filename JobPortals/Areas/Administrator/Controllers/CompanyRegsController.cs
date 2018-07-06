using JobPortals.Areas.Administrator.Models;
using JobPortals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using JobPortals.Areas.Administrator.ViewModels;
using System.Net;

namespace JobPortals.Areas.Administrator.Controllers
{
    public class CompanyRegsController : Controller
    {
        private ApplicationDbContext _context;

        public CompanyRegsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Administrator/CompanyRegs
        [Authorize(Roles = RoleName.CanManageJobs)]
        public ActionResult Index()
        {
            var companyRegs = _context.CompanyRegs.Include(c => c.CompanyType).ToList();
            
            return View(companyRegs);

            //if (User.IsInRole(RoleName.CanManageJobs))
            //    return View("Index");
        }

        [Authorize(Roles = RoleName.CanManageJobs)]
        public ActionResult New()
        {
            var companyTypes = _context.CompanyTypes.ToList();

            var viewModel = new CompanyTypeFormViewModel
            {
                CompanyReg = new CompanyReg(),
                CompanyTypes = companyTypes
            };
            
            return View("CompanyRegForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageJobs)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CompanyReg companyReg)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CompanyTypeFormViewModel
                {
                    CompanyReg = companyReg,
                    CompanyTypes = _context.CompanyTypes.ToList()
                };

                return View("CompanyRegForm", viewModel);
            }

            if (companyReg.Id == 0)
                _context.CompanyRegs.Add(companyReg);

            else
            {
                var companyRegInDb = _context.CompanyRegs.Single(c => c.Id == companyReg.Id);

                companyRegInDb.CompanyTypeId = companyReg.CompanyTypeId;

                companyRegInDb.Com_Name = companyReg.Com_Name;
                companyRegInDb.Contact_person = companyReg.Contact_person;
                companyRegInDb.Com_designation = companyReg.Com_designation;
                companyRegInDb.Com_number = companyReg.Com_number;
                companyRegInDb.Com_address = companyReg.Com_address;
                companyRegInDb.Com_city = companyReg.Com_city;
                companyRegInDb.Com_country = companyReg.Com_country;
                companyRegInDb.Com_email = companyReg.Com_email;
                companyRegInDb.Com_state = companyReg.Com_state;
                companyRegInDb.Com_detail = companyReg.Com_detail;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "CompanyRegs");
        }


        [Authorize(Roles = RoleName.CanManageJobs)]
        public ActionResult Details(int id)
        {
            var companyReg = _context.CompanyRegs.Include(c => c.CompanyType).SingleOrDefault(c => c.Id == id);

            if (companyReg == null)
                return HttpNotFound();

            return View(companyReg);
        }


        [Authorize(Roles = RoleName.CanManageJobs)]
        public ActionResult Edit(int id)
        {
            var companyReg = _context.CompanyRegs.SingleOrDefault(c => c.Id == id);

            if (companyReg == null)
                return HttpNotFound();

            var viewModel = new CompanyTypeFormViewModel
            {
                CompanyReg = companyReg,
                CompanyTypes = _context.CompanyTypes.ToList()
            };
            return View("CompanyRegForm", viewModel);
        }

        // GET: companyRegs/Delete/5
        [Authorize(Roles = RoleName.CanManageJobs)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyReg companyReg = _context.CompanyRegs.Find(id);
            if (companyReg == null)
            {
                return HttpNotFound();
            }
            return View(companyReg);
        }


        // POST: companyReg/Delete/1
        [Authorize(Roles = RoleName.CanManageJobs)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompanyReg companyReg = _context.CompanyRegs.Find(id);
            _context.CompanyRegs.Remove(companyReg);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}