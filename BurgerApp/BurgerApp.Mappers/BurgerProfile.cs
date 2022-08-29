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
        }
    }
}
