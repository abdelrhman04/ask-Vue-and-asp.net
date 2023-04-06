using AutoMapper;
using BLL.Services;
using Core.DAL;
using CORE.DTO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Mapper : Profile
    {
        public Mapper() 
        {
            //Roles Mapper
            CreateMap<IdentityRole, AddRolesCommand>().ReverseMap();
            CreateMap<IdentityRole, UpdateRolesCommand>().ReverseMap();
            CreateMap<RolesOutput, IdentityRole>().ReverseMap();
            //Product Mapper
            CreateMap<Product, ProductOutput>().ReverseMap();
            CreateMap<Product, ProductInput>().ReverseMap(); 
                CreateMap<Product, ProductInputUpdate>().ReverseMap();
        }
    }
}
