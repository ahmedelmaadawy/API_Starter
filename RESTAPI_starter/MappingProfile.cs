﻿using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace RESTAPI_starter
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>()
                .ForCtorParam("FullAddress",
                opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));
        }
    }
}
