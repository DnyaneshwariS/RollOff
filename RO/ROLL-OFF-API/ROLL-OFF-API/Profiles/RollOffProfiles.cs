using ROLL_OFF_API.DTO;
using ROLL_OFF_API.Models;
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROLL_OFF_API
{
    public class RollOffProfiles : Profile
    {



        public RollOffProfiles()
        {


            CreateMap<Rddb, RollOffDTO>().ReverseMap();   //ReverseMap() is used in case if we want to map DTO to the Domain Model

        }
    }
}
