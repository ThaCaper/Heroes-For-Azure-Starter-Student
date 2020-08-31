using Heroes.Entity;
using System.Collections.Generic;
using System.IO;
using Heroes.Core.DomainService;

namespace Heroes.Core.ApplicationService.impl
{
    public class PetService : IPetService
    {

        private readonly IPetRepository _petRepository;

        public PetService(IPetRepository petRepo)
        {
            _petRepository = petRepo;
        }
        public Pet CreatePet(Pet createdPet)
        {
            return _petRepository.CreateCover(createdPet);
        }

        public Pet DeletePet(int id)
        {
            if (_petRepository.DeletePet(id) == null)
                throw new InvalidDataException("No pet with id: " + id + " exist");
            return _petRepository.DeletePet(id);
        }

        public List<Pet> GetAllPets()
        {
            return _petRepository.GetAllPet();
        }

        public Pet GetPetById(int id)
        {
            if (_petRepository.GetPetById(id) == null)
                throw new InvalidDataException("Can't find pet with the id: " + id);
            return _petRepository.GetPetById(id);
        }

        public Pet UpdatePet(Pet updatedPet)
        {
            return _petRepository.UpdatePet(updatedPet);
        }
    }
}