using System.Collections.Generic;
using System.Linq;
using Agl.CodeTest.Dal.Entities;
using Agl.CodeTest.Web.Interfaces;
using Agl.CodeTest.Web.Models;

namespace Agl.CodeTest.Web.ModelManagers
{
    public class PetInfoManager: IPetInfoManager
    {
        public PetInfoByGenderModel GetPetNamesByGender(List<Person> people)
        {
            var result = new PetInfoByGenderModel()
            {
                Male = GetPetNames(people, Gender.Male),
                Female = GetPetNames(people, Gender.Female)
            };

            return result;
        }

        private PetInfoModelPart GetPetNames(IEnumerable<Person> people, Gender gender)
        {
            var result = new PetInfoModelPart()
            {
                GenderName = gender.ToString(),
                Names = people
                    .Where(p => p.Gender == gender)
                    .Where(p => p.Pets != null)
                    .SelectMany(p => p.Pets)
                    .Where(pet => pet.Type == PetType.Cat)
                    .Select(pet => pet.Name)
                    .OrderBy(n => n)
                    .ToList(),
            };

            return result;
        }
    }
}