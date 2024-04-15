using APIEcommerce.Domain.Models;
using APIEcommerce.Domain.Models.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIEcommerce.Infrastructure.Mappings
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category,CategoryDTO>().ReverseMap();
            CreateMap<AddCategoryDTO,Category>().ReverseMap();
            CreateMap<UpdateCategoryDTO,Category>().ReverseMap();
        }
    }
}
