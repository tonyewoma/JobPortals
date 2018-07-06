using JobPortals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortals.Areas.Administrator.Models;
using JobPortals.Areas.Administrator.ViewModels;
using System.Data.Entity;

namespace JobPortals.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            var vacancies = _context.Vacancies.Include(v => v.CompanyType).ToList();

            return View(vacancies);
        }

        public ActionResult Details(int id)
        {
            var vacancy = _context.Vacancies.Include(v => v.CompanyType).SingleOrDefault(v => v.Id == id);

            if (vacancy == null)
                return HttpNotFound();

            return View(vacancy);
        }


        public ActionResult Project()
        {
            return View();
        }
        public ActionResult Freelancer()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}