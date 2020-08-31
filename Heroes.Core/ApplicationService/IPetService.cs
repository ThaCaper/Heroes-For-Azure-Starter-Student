using Heroes.Entity;
using System.Collections.Generic;

namespace Heroes.Core.ApplicationService
{
    public interface IPetService
    {
        Pet CreateCover(Pet createdPet);

        Pet GetPetById(int id);

        Pet DeletePet(int id);

        List<Pet> GetAllCovers();

        Pet UpdatePet(Pet updatedPet);
    }
}