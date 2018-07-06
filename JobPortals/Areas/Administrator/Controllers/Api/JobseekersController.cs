using AutoMapper;
using JobPortals.Areas.Administrator.Models;
using JobPortals.Dtos;
using JobPortals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace JobPortals.Areas.Administrator.Controllers.Api
{
    public class JobseekersController : ApiController
    {
        private ApplicationDbContext _context;
        public JobseekersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/jobseekers
        public IEnumerable<JobseekerDto> GetJobseekers()
        {
            return _context.Jobseekers.ToList().Select(Mapper.Map<Jobseeker, JobseekerDto>);
        }

        //GET /api/jobseekers/1
        public IHttpActionResult GetJobseeker(int id)
        {
            var jobseeker = _context.Jobseekers.SingleOrDefault(j => j.Id == id);

            if (jobseeker == null)
                return NotFound();

            return Ok(Mapper.Map<Jobseeker, JobseekerDto>(jobseeker));
        }

       //POST /api/companyReg
        [HttpPost]
        public IHttpActionResult CreateJobseeker(JobseekerDto jobseekerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var jobseeker = Mapper.Map<JobseekerDto, Jobseeker>(jobseekerDto);

            _context.Jobseekers.Add(jobseeker);
            _context.SaveChanges();

            jobseekerDto.Id = jobseeker.Id;

            return Created(new Uri(Request.RequestUri + "/" + jobseeker.Id), jobseekerDto);
        }

        //PUT /api/jobseekers/1
        [HttpPut]
        public void UpdateJobseeker(int id, JobseekerDto jobseekerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var jobseekerInDb = _context.Jobseekers.SingleOrDefault(j => j.Id == id);

            if (jobseekerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(jobseekerDto, jobseekerInDb);

            _context.SaveChanges();
        }


       

        //DELETE /api/jobseekers/1
        [HttpDelete]
        public void DeleteJobseeker(int id)
        {
            var jobseekerInDb = _context.Jobseekers.SingleOrDefault(j => j.Id == id);

            if (jobseekerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Jobseekers.Remove(jobseekerInDb);

            _context.SaveChanges();
        }
    }
}
