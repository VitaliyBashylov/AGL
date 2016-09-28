using System.Collections.Generic;

namespace Agl.CodeTest.Dal.Entities
{
    public enum Gender
    {
        Male,
        Female,
    }
    public class Person
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public List<Pet> Pets { get; set; }
    }

    public enum PetType
    {
        Cat,
        Dog,
        Fish,
    }
    public class Pet
    {
        public string Name { get; set; }
        public PetType Type { get; set; }
    }
}