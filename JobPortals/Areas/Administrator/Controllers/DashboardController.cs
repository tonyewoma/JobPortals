using JobPortals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace JobPortals.Areas.Administrator.Controllers
{
    public class DashboardController : Controller
    {
        private ApplicationDbContext _context;

        public DashboardController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Administrator/Dashboard
        public ActionResult Index()
        {
            return View();
        }

    }
}