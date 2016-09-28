using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agl.CodeTest.Dal.Entities;
using Agl.CodeTest.Web.ModelManagers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Agl.CodeTest.Tests
{
    [TestClass]
    public class PetInfoManagerTests
    {
        [TestMethod]
        public void TestEmptyData()
        {
            var manager = new PetInfoManager();
            var result = manager.GetPetNamesByGender(new List<Person>());

            Assert.AreEqual(0, result.Male.Names.Count);
            Assert.AreEqual(0, result.Female.Names.Count);
        }

        [TestMethod]
        public void TestNullPets()
        {
            var manager = new PetInfoManager();
            var result = manager.GetPetNamesByGender(new List<Person>()
            {
                new Person()
                {
                    Gender = Gender.Male,
                },
                new Person()
                {
                    Gender = Gender.Male,
                    Pets = new List<Pet>() { new Pet()
                        {
                            Type = PetType.Cat,
                            Name = "asd",
                        }
                    }
                }
            });

            Assert.AreEqual(1, result.Male.Names.Count);
            Assert.AreEqual(0, result.Female.Names.Count);
        }
        [TestMethod]
        public void TestMaleAndFemale()
        {
            var manager = new PetInfoManager();
            var result = manager.GetPetNamesByGender(new List<Person>()
            {
                new Person()
                {
                    Gender = Gender.Female,
                    Pets = new List<Pet>() { new Pet()
                        {
                            Type = PetType.Cat,
                            Name = "qwe",
                        }
                    }
                },
                new Person()
                {
                    Gender = Gender.Male,
                    Pets = new List<Pet>() { new Pet()
                        {
                            Type = PetType.Cat,
                            Name = "asd",
                        }
                    }
                }
            });

            Assert.AreEqual(1, result.Male.Names.Count);
            Assert.AreEqual(1, result.Female.Names.Count);
        }
        [TestMethod]
        public void TestNamesAreSorted()
        {
            var manager = new PetInfoManager();
            var result = manager.GetPetNamesByGender(new List<Person>()
            {
                new Person()
                {
                    Gender = Gender.Male,
                    Pets = new List<Pet>() { new Pet()
                        {
                            Type = PetType.Cat,
                            Name = "qwe",
                        }
                    }
                },
                new Person()
                {
                    Gender = Gender.Male,
                    Pets = new List<Pet>() { new Pet()
                        {
                            Type = PetType.Cat,
                            Name = "asd",
                        }
                    }
                }
            });

            Assert.AreEqual(2, result.Male.Names.Count);
            Assert.AreEqual(0, result.Female.Names.Count);
            Assert.AreEqual("asd", result.Male.Names.First());
            Assert.AreEqual("qwe", result.Male.Names.Last());
        }
        [TestMethod]
        public void TestDogAndFishNotIncluded()
        {
            var manager = new PetInfoManager();
            var result = manager.GetPetNamesByGender(new List<Person>()
            {
                new Person()
                {
                    Gender = Gender.Male,
                    Pets = new List<Pet>() {
                        new Pet()
                        {
                            Type = PetType.Dog,
                            Name = "asd",
                        },
                        new Pet()
                        {
                            Type = PetType.Cat,
                            Name = "qwe",
                        },
                        new Pet()
                        {
                            Type = PetType.Fish,
                            Name = "zxc",
                        },
                    }
                },
            });

            Assert.AreEqual(1, result.Male.Names.Count);
            Assert.AreEqual(0, result.Female.Names.Count);
            Assert.AreEqual("qwe", result.Male.Names.First());
        }
    }
}
