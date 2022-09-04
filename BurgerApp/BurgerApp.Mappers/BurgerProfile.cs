using AutoMapper;
using BurgerApp.Domain.Models;
using BurgerApp.ViewModels.BurgerViewModels;

namespace BurgerApp.Mappers
{
    public class BurgerProfile : Profile
    {
        public BurgerProfile()
        {
            CreateMap<Burger, BurgerViewModel>().ReverseMap();
            CreateMap<CreateBurgerViewModel, Burger>();
            CreateMap<BurgerOrder, BurgerViewModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(x => x.Burger.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(x => x.Burger.Price))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(x => x.Burger.Description));
        }
    }
}
