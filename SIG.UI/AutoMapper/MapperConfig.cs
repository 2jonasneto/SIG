using AutoMapper;
using SIG.Core.Domain;
using SIG.Core.Services;
using SIG.Services;

namespace SIG.UI.AutoMapper
{
    public class MapperConfig:Profile
    {
        public MapperConfig()
        {
            CreateMap<Computer,ComputerViewModel>().ReverseMap();
            CreateMap<ActingArea,ActingAreaModel>().ReverseMap();
            CreateMap<Brand, BrandModel>().ReverseMap();
            CreateMap<EquipType, EquipTypeModel>().ReverseMap();
            CreateMap<Locacity, LocacityModel>().ReverseMap();
            CreateMap<Sector, SectorModel>().ReverseMap();
        }
    }
}
