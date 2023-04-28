﻿using AutoMapper;
using SIG.Core.Domain;
using SIG.Services;

namespace SIG.UI.AutoMapper
{
    public class MapperConfig:Profile
    {
        public MapperConfig()
        {
            CreateMap<Computer,ComputerViewModel>().ReverseMap();
        }
    }
}