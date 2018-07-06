using JobPortals.Areas.Administrator.Models;
using JobPortals.Areas.Administrator.ViewModels;
using JobPortals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace JobPortals.Areas.Administrator.Controllers
{
    public class VacanciesController : Controller
    {
        private ApplicationDbContext _context;

        public VacanciesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Administrator/Vacancies
        [Authorize(Roles = RoleName.CanManageJobs)]
        public ActionResult Index()
        {
            var vacancies = _context.Vacancies.Include(v => v.CompanyType).ToList();

            return View(vacancies);
        }

        [Authorize(Roles = RoleName.CanManageJobs)]
        public ActionResult New()
        {
            var companyTypess = _context.CompanyTypes.ToList();

            var viewModel = new CompanyRegFormViewModel
            {
                Vacancy = new Vacancy(),
                CompanyTypes = companyTypess
            };

            return View("VacancyForm", viewModel);
        }

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageJobs)]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Vacancy vacancy)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CompanyRegFormViewModel
                {
                    Vacancy = vacancy,
                    CompanyTypes = _context.CompanyTypes.ToList()
                };
                return View("VacancyForm", viewModel);
            }

            if (vacancy.Id == 0)
            {
                _context.Vacancies.Add(vacancy);
                vacancy.DateAdded = DateTime.Now;
            }

            else
            {
                var vacancyInDb = _context.Vacancies.Single(c => c.Id == vacancy.Id);

                vacancyInDb.CompanyName = vacancy.CompanyName;
                vacancyInDb.AboutCompany = vacancy.AboutCompany;
                vacancyInDb.CompanyTypeId = vacancy.CompanyTypeId;
                vacancyInDb.Postion = vacancy.Postion;
                vacancyInDb.JobType = vacancy.JobType;
                vacancyInDb.Qualification = vacancy.Qualification;
                vacancyInDb.Experience = vacancy.Experience;
                vacancyInDb.Location = vacancy.Location;
                vacancyInDb.Responsibility = vacancy.Responsibility;
                vacancyInDb.SkillsRequired = vacancy.SkillsRequired;


            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Vacancies");
        }

        [Authorize(Roles = RoleName.CanManageJobs)]
        public ActionResult Details(int id)
        {
            var vacancy = _context.Vacancies.Include(v => v.CompanyType).SingleOrDefault(v => v.Id == id);

            if (vacancy == null)
                return HttpNotFound();

            return View(vacancy);
        }

        [Authorize(Roles = RoleName.CanManageJobs)]
        public ActionResult Edit(int id)
        {
            var vacancy = _context.Vacancies.SingleOrDefault(v => v.Id == id);

            if (vacancy == null)
                return HttpNotFound();

            var viewModel = new CompanyRegFormViewModel
            {
                Vacancy = vacancy,
                CompanyTypes = _context.CompanyTypes.ToList()
            };

            return View("VacancyForm", viewModel);
        }

        // GET: jobseekers/Delete/5
        [Authorize(Roles = RoleName.CanManageJobs)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacancy vacancy = _context.Vacancies.Find(id);
            if (vacancy == null)
            {
                return HttpNotFound();
            }
            return View(vacancy);
        }

        // POST: vacancy/Delete/1
        [Authorize(Roles = RoleName.CanManageJobs)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vacancy vacancy = _context.Vacancies.Find(id);
            _context.Vacancies.Remove(vacancy);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}