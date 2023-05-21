using AutoMapper;
using SIG.Core.Domain;
using SIG.Services;

namespace SIG.UI.AutoMapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Computer, ComputerViewModel>().ForMember(
                dest => dest.Historics,
                opt => opt.MapFrom(src => src.Historics)
                );
            CreateMap<ComputerViewModel, Computer>();
            CreateMap<ActingArea, ActingAreaViewModel>().ReverseMap();
            CreateMap<Brand, BrandViewModel>().ReverseMap();
            CreateMap<EquipType, EquipTypeViewModel>().ReverseMap();
            CreateMap<Locacity, LocacityViewModel>().ForMember(
                dest => dest.ActingArea,
                opt => opt.MapFrom(src => src.ActingArea)
                );
            CreateMap<LocacityViewModel, Locacity>();
            CreateMap<Sector, SectorViewModel>().ReverseMap();
            CreateMap<Historic, HistoricViewModel>().ReverseMap();
        }
    }
}
