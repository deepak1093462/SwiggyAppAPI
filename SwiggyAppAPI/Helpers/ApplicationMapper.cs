using AutoMapper;
using SwiggyAppAPI.Data;
using SwiggyAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwiggyAppAPI.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Customers, CustomerModel>().ReverseMap();
        }
    }
}
