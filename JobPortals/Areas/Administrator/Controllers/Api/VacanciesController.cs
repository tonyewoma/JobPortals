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
    public class VacanciesController : ApiController
    {
        private ApplicationDbContext _context;
        public VacanciesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/vacancies
        public IEnumerable<VacancyDto> GetVacancies()
        {
            return _context.Vacancies.ToList().Select(Mapper.Map<Vacancy, VacancyDto>);
        }

        //GET /api/vacancies/1
        public IHttpActionResult GetVacancy(int id)
        {
            var vacancy = _context.Vacancies.SingleOrDefault(v => v.Id == id);

            if (vacancy == null)
                return NotFound();

            return Ok(Mapper.Map<Vacancy, VacancyDto>(vacancy));

        }

        //POST /api/vacancy
        [HttpPost]
        public IHttpActionResult CreateVacancy(VacancyDto vacancyDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var vacancy = Mapper.Map<VacancyDto, Vacancy>(vacancyDto);

            _context.Vacancies.Add(vacancy);
            _context.SaveChanges();

            vacancyDto.Id = vacancy.Id;

            return Created(new Uri(Request.RequestUri + "/" + vacancy.Id), vacancyDto);
        }

        
        //PUT /api/vacancies/1
        [HttpPut]
        public void UpdateVacancy(int id, VacancyDto vacancyDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var vacancyInDb = _context.Vacancies.SingleOrDefault(v => v.Id == id);

            if (vacancyInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(vacancyDto, vacancyInDb);

            _context.SaveChanges();
        }

        //DELETE /api/vacancies/1
        [HttpDelete]
        public void DeleteVacancy(int id)
        {
            var vacancyInDb = _context.Vacancies.SingleOrDefault(v => v.Id == id);

            if (vacancyInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Vacancies.Remove(vacancyInDb);

            _context.SaveChanges();
        }
    }
}
