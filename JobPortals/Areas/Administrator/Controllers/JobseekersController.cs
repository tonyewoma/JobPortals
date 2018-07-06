using JobPortals.Areas.Administrator.Models;
using JobPortals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace JobPortals.Areas.Administrator.Controllers
{
    public class JobseekersController : Controller
    {
        private ApplicationDbContext _context;

        public JobseekersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Administrator/Jobseekers
        [Authorize(Roles = RoleName.CanManageJobs)]
        public ActionResult New()
        {
            return View("JobseekerForm");
        }

        [Authorize(Roles = RoleName.CanManageJobs)]
        public ActionResult Index()
        {
            var jobseekers = _context.Jobseekers.ToList();

            return View(jobseekers);
        }

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageJobs)]
        public ActionResult Save(Jobseeker jobseeker)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View("JobseekerForm");
            //}
            if (jobseeker.Id == 0)
                _context.Jobseekers.Add(jobseeker);

            else
            {
                var jobseekerInDb = _context.Jobseekers.Single(c => c.Id == jobseeker.Id);

                jobseekerInDb.J_Name = jobseeker.J_Name;
                jobseekerInDb.J_Email = jobseeker.J_Email;
                jobseekerInDb.J_Address = jobseeker.J_Address;
                jobseekerInDb.J_DOB = jobseeker.J_DOB;
                jobseekerInDb.J_City = jobseeker.J_City;
                jobseekerInDb.J_Cnumber = jobseeker.J_Cnumber;
                jobseekerInDb.J_Country = jobseeker.J_Country;
                jobseekerInDb.J_Gender = jobseeker.J_Gender;
                jobseekerInDb.J_State = jobseeker.J_State;
                jobseekerInDb.Extra_achi = jobseeker.Extra_achi;
                jobseekerInDb.User_type = jobseeker.User_type;
                jobseekerInDb.Skill_area = jobseeker.Skill_area;
                jobseekerInDb.Exp_detail = jobseeker.Exp_detail;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Jobseekers");
        }

        [Authorize(Roles = RoleName.CanManageJobs)]
        public ActionResult Details(int id)
        {
            var jobseeker = _context.Jobseekers.SingleOrDefault(j => j.Id == id);

            if (jobseeker == null)
                return HttpNotFound();

            return View(jobseeker);
        }

        [Authorize(Roles = RoleName.CanManageJobs)]
        public ActionResult Edit(int id)
        {
            var jobseeker = _context.Jobseekers.SingleOrDefault(j => j.Id == id);

            if (jobseeker == null)
                return HttpNotFound();

            return View("JobseekerForm", jobseeker);
        }

        // GET: jobseekers/Delete/5
        [Authorize(Roles = RoleName.CanManageJobs)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jobseeker jobseeker = _context.Jobseekers.Find(id);
            if (jobseeker == null)
            {
                return HttpNotFound();
            }
            return View(jobseeker);
        }


        // POST: jobseeker/Delete/1
        [Authorize(Roles = RoleName.CanManageJobs)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jobseeker jobseeker = _context.Jobseekers.Find(id);
            _context.Jobseekers.Remove(jobseeker);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}