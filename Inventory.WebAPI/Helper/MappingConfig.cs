using AutoMapper;
using Inventory.Application.Features.Elements.Queries.GetAllElements;
using Inventory.Application.Features.Elements.Queries.GetElementById;
using Inventory.Application.Features.Racks.Queries.GetAllRacks;
using Inventory.Application.Features.Racks.Queries.GetRackById;
using Inventory.Application.Features.Stores.Queries.GetAllStores;
using Inventory.Application.Features.Stores.Queries.GetStoreById;
using Inventory.Domain.Entities;
using Inventory.Web.Models.Dto;

namespace Inventory.WebAPI.Helper
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Store, StoreDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
                .ReverseMap();
                config.CreateMap<Rack, RackDto>()
                .ForMember(dest=>dest.Id, opt=>opt.MapFrom(src=>src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest=>dest.QuantityOfRacks, opt=>opt.MapFrom(src=>src.QuantityOfRacks))
                .ForMember(dest=>dest.StoreName, opt=>opt.MapFrom(src=>src.Store.Name))
                .ReverseMap();
                config.CreateMap<Element, ElementDto>()
                .ForMember(dest=>dest.Id, opt=>opt.MapFrom(src=>src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Width, opt => opt.MapFrom(src => src.Width))
                .ForMember(dest => dest.Height, opt => opt.MapFrom(src => src.Height))
                .ForMember(dest => dest.RackName, opt => opt.MapFrom(src => src.Rack.Name))
                .ReverseMap();

                config.CreateMap<Store, GetAllStoresDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
                .ReverseMap();
                config.CreateMap<Rack, GetAllRacksDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.QuantityOfRacks, opt => opt.MapFrom(src => src.QuantityOfRacks))
                .ForMember(dest => dest.StoreName, opt => opt.MapFrom(src => src.Store.Name))
                .ReverseMap();
                config.CreateMap<Element, GetAllElementsDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Width, opt => opt.MapFrom(src => src.Width))
                .ForMember(dest => dest.Height, opt => opt.MapFrom(src => src.Height))
                .ForMember(dest => dest.RackName, opt => opt.MapFrom(src => src.Rack.Name))
                .ReverseMap();

                config.CreateMap<Store, GetStoreByIdDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
                .ReverseMap();
                config.CreateMap<Rack, GetRackByIdDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.QuantityOfRacks, opt => opt.MapFrom(src => src.QuantityOfRacks))
                .ForMember(dest => dest.StoreName, opt => opt.MapFrom(src => src.Store.Name))
                .ReverseMap();
                config.CreateMap<Element, GetElementByIdDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Width, opt => opt.MapFrom(src => src.Width))
                .ForMember(dest => dest.Height, opt => opt.MapFrom(src => src.Height))
                .ForMember(dest => dest.RackName, opt => opt.MapFrom(src => src.Rack.Name))
                .ReverseMap();
            });

            return mappingConfig;
        }
    }
}
