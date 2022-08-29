using AutoMapper;
using BurgerApp.Domain.Models;
using BurgerApp.ViewModels.OrderViewModels;

namespace BurgerApp.Mappers
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderViewModel>()
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserFullName,
                           opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"))
                .ForMember(dest => dest.TotalPrice,
                           opt => opt.MapFrom(src => src.BurgerOrders.Select(x => x.Burger.Price).Sum()));

            CreateMap<Order, OrderDetailsViewModel>()
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserFullName,
                           opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"))
                .ForMember(dest => dest.TotalPrice,
                           opt => opt.MapFrom(src => src.BurgerOrders.Select(x => x.Burger.Price).Sum()));

        }
    }
}
