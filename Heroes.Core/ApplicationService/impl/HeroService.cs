using System.Collections.Generic;
using Heroes.Core.DomainService;
using Heroes.Entity;

namespace Heroes.Core.ApplicationService.impl
{
    public class HeroService : IHeroService
    {
        private readonly IHeroRepository _heroRepository;

        public HeroService(IHeroRepository heroRepository)
        {
            _heroRepository = heroRepository;
        }

        public Hero CreateHero(Hero createdHero)
        {
            return _heroRepository.CreateHero(createdHero);
        }

        public Hero GetHeroById(int id)
        {
            return _heroRepository.GetHeroById(id);
        }

        public List<Hero> GetAllHeroes()
        {
            return _heroRepository.GetAllHeroes();
        }

        public Hero UpdateHero(Hero updatedHero)
        {
            return _heroRepository.UpdateHero(updatedHero);
        }

        public Hero DeleteHero(int id)
        {
            return _heroRepository.DeleteHero(id);
        }
    }
}