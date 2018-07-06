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

namespace JobPortals.Areas.Administrator.Controllers.Api
{
    public class CompanyTypesController : ApiController
    {
        private ApplicationDbContext _context;
        public CompanyTypesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/jobseekers
        //public IEnumerable<CompanyTypeDto> GetCompanyTypes()
        //{
        //    return _context.CompanyTypes.ToList().Select(Mapper.Map<CompanyType, CompanyTypeDto>);
        //}

        public IHttpActionResult GetCompanyTypes()
        {
            var companyTypeDtos = _context.CompanyTypes
                 .ToList().Select(Mapper.Map<CompanyType, CompanyTypeDto>);

            return Ok(companyTypeDtos);
        }


        //GET /api/companyType/1
        public IHttpActionResult GetCompanyType(int id)
        {
            var companyType = _context.CompanyTypes.SingleOrDefault(c => c.Id == id);

            if (companyType == null)
                return NotFound();

            return Ok(Mapper.Map<CompanyType, CompanyTypeDto>(companyType));
        }

        //POST /api/companyType
        [HttpPost]
        public IHttpActionResult CreateCompanyType(CompanyTypeDto companyTypeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var companyType = Mapper.Map<CompanyTypeDto, CompanyType>(companyTypeDto);

            _context.CompanyTypes.Add(companyType);
            _context.SaveChanges();

            companyTypeDto.Id = companyType.Id;

            return Created(new Uri(Request.RequestUri + "/" + companyType.Id), companyTypeDto);
        }

        //PUT /api/companyTypes/1
        [HttpPut]
        public void UpdateCompanyType(int id, CompanyTypeDto companyTypeDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var companyTypeInDb = _context.CompanyTypes.SingleOrDefault(c => c.Id == id);

            if (companyTypeInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(companyTypeDto, companyTypeInDb);

            _context.SaveChanges();
        }


        //DELETE /api/CompanyTypes/1
        [HttpDelete]
        public void DeleteCompanyType(int id)
        {
            var companyTypeInDb = _context.CompanyTypes.SingleOrDefault(c => c.Id == id);

            if (companyTypeInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.CompanyTypes.Remove(companyTypeInDb);

            _context.SaveChanges();
        }

    }
}
