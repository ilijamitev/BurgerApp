using AutoMapper;
using BurgerApp.Domain.Models;
using BurgerApp.ViewModels.UserViewModels;

namespace BurgerApp.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserViewModel>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
        }
    }
}
