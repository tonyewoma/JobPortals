using JobPortals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using JobPortals.Areas.Administrator.Models;
using JobPortals.Areas.Administrator.ViewModels;

namespace JobPortals.Controllers
{
    [AllowAnonymous]
    public class ProjectController : Controller
    {
        private ApplicationDbContext _context;

        public ProjectController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Project
        public ActionResult Index()
        {
            var seeProjects = _context.SeeProjects.Include(s => s.CompanyType).ToList();
            return View(seeProjects);
        }
    }
}