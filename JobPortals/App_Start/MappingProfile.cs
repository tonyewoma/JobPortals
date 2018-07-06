using AutoMapper;
using JobPortals.Areas.Administrator.Models;
using JobPortals.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobPortals.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Mapper.CreateMap<CompanyReg, CompanyRegDto>();
            //Mapper.CreateMap<CompanyRegDto, CompanyReg>();

            //Domain to Dto
            Mapper.CreateMap<CompanyReg, CompanyRegDto>();
            Mapper.CreateMap<Jobseeker, JobseekerDto>();
            Mapper.CreateMap<Vacancy, VacancyDto>();
            Mapper.CreateMap<CompanyType, CompanyTypeDto>();

            //Dto to Domain
            Mapper.CreateMap<CompanyRegDto, CompanyReg>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<JobseekerDto, Jobseeker>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<VacancyDto, Vacancy>()
                .ForMember(v => v.Id, opt => opt.Ignore());

            Mapper.CreateMap<CompanyTypeDto, CompanyType>()
                .ForMember(v => v.Id, opt => opt.Ignore());
        }
    }
}