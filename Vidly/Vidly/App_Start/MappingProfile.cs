using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // For AutoMapper version upto 4.2
            //Mapper.CreateMap<Customer, CustomerDTO>();
            //Mapper.CreateMap<CustomerDTO, Customer>();

            // Uses Reflection to map
            // For AutoMapper version over 4.2
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>();
            CreateMap<CustomerDTO, Customer>().ForMember(c => c.Id, opt => opt.Ignore());

            CreateMap<Movie, MovieDTO>();
            CreateMap<MovieDTO, Movie>();
            CreateMap<MovieDTO, Movie>().ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}