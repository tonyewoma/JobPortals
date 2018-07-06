using AutoMapper;
using JobPortals.Areas.Administrator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using JobPortals.Dtos;
using JobPortals.Models;

namespace JobPortals.Areas.Administrator.Controllers.Api
{
    public class CompanyRegsController : ApiController
    {
        private ApplicationDbContext _context;
        public CompanyRegsController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/companyRegs
        public IEnumerable<CompanyRegDto> GetCompanyRegs()
        {
            return _context.CompanyRegs.ToList().Select(Mapper.Map<CompanyReg, CompanyRegDto>);
        }

        //GET /api/companyRegs/1
        public IHttpActionResult GetCompanyReg(int id)
        {
            var companyReg = _context.CompanyRegs.SingleOrDefault(c => c.Id == id);

            if (companyReg == null)
                return NotFound();

            return Ok(Mapper.Map<CompanyReg, CompanyRegDto>(companyReg));
        }

        //POST /api/companyReg
        [HttpPost]
        public IHttpActionResult CreateCompanyReg(CompanyRegDto companyRegDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var companyReg = Mapper.Map<CompanyRegDto, CompanyReg>(companyRegDto);


            _context.CompanyRegs.Add(companyReg);
            _context.SaveChanges();

            companyRegDto.Id = companyReg.Id;

            return Created(new Uri(Request.RequestUri + "/" + companyReg.Id), companyRegDto);
        }

        //PUT /api/companyRegs/1
        [HttpPut]
        public void UpdateCompanyReg(int id, CompanyRegDto companyRegDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var companyRegInDb = _context.CompanyRegs.SingleOrDefault(c => c.Id == id);

            if (companyRegInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(companyRegDto, companyRegInDb);


            _context.SaveChanges();
        }

        //DELETE /api/companyRegs/1
        [HttpDelete]
        public void DeleteCompanyReg(int id)
        {
            var companyRegInDb = _context.CompanyRegs.SingleOrDefault(c => c.Id == id);

            if (companyRegInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.CompanyRegs.Remove(companyRegInDb);

            _context.SaveChanges();
        }
    }
}
