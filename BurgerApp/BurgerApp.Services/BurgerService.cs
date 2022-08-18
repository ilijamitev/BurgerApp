using AutoMapper;
using BurgerApp.DataAccess.Repositories.Interfaces;
using BurgerApp.Domain.Models;
using BurgerApp.Services.Interfaces;
using BurgerApp.ViewModels.BurgerViewModels;

namespace BurgerApp.Services
{
    public class BurgerService : IBurgerService
    {
        private readonly IRepository<Burger> _burgerRepository;
        private readonly IMapper _mapper;
        public BurgerService(IRepository<Burger> burgerRepository, IMapper mapper)
        {
            _burgerRepository = burgerRepository;
            _mapper = mapper;
        }
        public List<BurgerViewModel> GetAllBurgers()
        {
            var burgersFromDb = _burgerRepository.GetAll();
            var mappedBurgers = burgersFromDb.Select(_mapper.Map<Burger, BurgerViewModel>).ToList();
            return mappedBurgers;
        }

        public BurgerViewModel GetBurgerById(int id)
        {
            var burgerFromDb = _burgerRepository.GetById(id);
            ArgumentNullException.ThrowIfNull(burgerFromDb);
            var mappedBurger = _mapper.Map<BurgerViewModel>(burgerFromDb);
            return mappedBurger;
        }

        public void AddNewBurger(CreateBurgerViewModel model)
        {
            ArgumentNullException.ThrowIfNull(model);
            Burger newBurger = _mapper.Map<Burger>(model);
            _burgerRepository.Insert(newBurger);
        }

        public void EditBurger(BurgerViewModel editedBurger)
        {
            var burger = _mapper.Map<Burger>(editedBurger);
            _burgerRepository.Update(burger);
        }
        public void DeleteBurger(int id)
        {
            Burger burger = _burgerRepository.GetById(id);
            ArgumentNullException.ThrowIfNull(burger);
            _burgerRepository.Delete(id);
        }


    }
}
