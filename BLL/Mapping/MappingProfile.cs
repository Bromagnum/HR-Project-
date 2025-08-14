using AutoMapper;
using BLL.DTOs;
using DAL.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
             CreateMap<PersonelDTO, Personel>().ReverseMap();
             
        }
    }
}
