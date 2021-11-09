using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using S10_NCORE.Domain.Core.DTOs;
using S10_NCORE.Domain.Core.Entities;

namespace S10_NCORE.Domain.Infraestructure.Mappings
{
   public class AutomapperProfile : Profile
    {

        public AutomapperProfile()
        {
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>();
            CreateMap<Customer, CustomerPostDTO>();
            CreateMap<CustomerPostDTO, Customer>();
        }
    }
}
