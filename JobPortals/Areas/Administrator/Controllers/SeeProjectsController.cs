using JobPortals.Areas.Administrator.Models;
using JobPortals.Areas.Administrator.ViewModels;
using JobPortals.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace JobPortals.Areas.Administrator.Controllers
{
    public class SeeProjectsController : Controller
    {
        private ApplicationDbContext _context;
        public SeeProjectsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Administrator/SeeProjects
        public ActionResult Index()
        {
            var seeProjects = _context.SeeProjects.Include(s => s.CompanyType).ToList();

            return View(seeProjects);
        }
        public ActionResult New()
        {
            var companyTypes = _context.CompanyTypes.ToList();

            var viewModel = new SeeProjectFormViewModel
            {
               
                CompanyTypes = companyTypes
            };

            return View("SeeProjectForm", viewModel);
        }
        

        [HttpPost]
        public ActionResult Save(SeeProject seeProject)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new SeeProjectFormViewModel(seeProject)
                {
                    CompanyTypes = _context.CompanyTypes.ToList()
                };
                return View("MovieForm", viewModel);
            }
            if (seeProject.Id == 0)
            {
                seeProject.DateAdded = DateTime.Now;
                _context.SeeProjects.Add(seeProject);
            }
            else
            {
                var seeProjectInDb = _context.SeeProjects.Single(c => c.Id == seeProject.Id);
                seeProjectInDb.CompanyTypeId = seeProject.CompanyTypeId;
                seeProjectInDb.ProjectName = seeProject.ProjectName;
                seeProjectInDb.ProjectDescription = seeProject.ProjectDescription;
                seeProjectInDb.SkillsRequired = seeProject.SkillsRequired;
                seeProjectInDb.Budget = seeProject.Budget;
                seeProjectInDb.ProjectDeadline = seeProject.ProjectDeadline;
                seeProjectInDb.ContactPerson = seeProject.ContactPerson;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "SeeProjects");
        }




        public ActionResult Details(int id)
        {
            var seeProject = _context.SeeProjects.Include(v => v.CompanyType).SingleOrDefault(v => v.Id == id);

            if (seeProject == null)
                return HttpNotFound();

            return View(seeProject);
        }

        public ActionResult Edit(int id)
        {
            var seeProject = _context.SeeProjects.SingleOrDefault(v => v.Id == id);

            if (seeProject == null)
                return HttpNotFound();

            var viewModel = new SeeProjectFormViewModel(seeProject)
            {
                //SeeProject = seeProject,
                CompanyTypes = _context.CompanyTypes.ToList()
            };

            return View("SeeProjectForm", viewModel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeeProject seeProject = _context.SeeProjects.Find(id);
            if (seeProject == null)
            {
                return HttpNotFound();
            }
            return View(seeProject);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SeeProject seeProject = _context.SeeProjects.Find(id);
            _context.SeeProjects.Remove(seeProject);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}