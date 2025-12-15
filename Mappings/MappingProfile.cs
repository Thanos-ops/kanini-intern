using AutoMapper;
using Foodapi.Models;
using Foodapi.DTOs;

namespace Foodapi.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserProfileDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FullName))
            .ForMember(dest => dest.Mobile, opt => opt.MapFrom(src => src.Phone ?? string.Empty));
        CreateMap<UserProfileDto, User>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Mobile));

        CreateMap<Address, AddressDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AddressId))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.AddressLine))
            .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City.CityName))
            .ForMember(dest => dest.StateName, opt => opt.MapFrom(src => src.State.StateName));
        CreateMap<AddressDto, Address>()
            .ForMember(dest => dest.AddressLine, opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.AddressId, opt => opt.Ignore());

        CreateMap<Order, OrderDto>()
            .ForMember(dest => dest.RestaurantName, opt => opt.MapFrom(src => src.Restaurant.Name))
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.OrderItems));
        
        CreateMap<OrderItem, OrderItemDto>()
            .ForMember(dest => dest.ItemName, opt => opt.MapFrom(src => src.MenuItem.Name));

        CreateMap<Favorite, FavoriteDto>();
        CreateMap<FavoriteDto, Favorite>();
        CreateMap<UserSettings, UserSettingsDto>();
        CreateMap<UserSettingsDto, UserSettings>();
    }
}