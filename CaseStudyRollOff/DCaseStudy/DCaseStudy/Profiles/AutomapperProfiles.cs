using AutoMapper;
using DCaseStudy.DTO;
using DCaseStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCaseStudy.Profiles
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
        }
    }
}
