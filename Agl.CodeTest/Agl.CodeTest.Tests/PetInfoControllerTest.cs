using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Agl.CodeTest.Dal;
using Agl.CodeTest.Dal.Entities;
using Agl.CodeTest.Web.Controllers;
using Agl.CodeTest.Web.Interfaces;
using Agl.CodeTest.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Agl.CodeTest.Tests
{
    [TestClass]
    public class PetInfoControllerTest
    {
        [TestMethod]
        public void TestIndexCallSequence()
        {
            var providerMock = new Mock<IPeopleProvider>(MockBehavior.Strict);
            var managerMock = new Mock<IPetInfoManager>(MockBehavior.Strict);

            var ppl = new List<Person>();
            providerMock.Setup(p => p.GetAll()).Returns(ppl);
            var model = new PetInfoByGenderModel();
            managerMock.Setup(m => m.GetPetNamesByGender(ppl)).Returns(model);

            var ctrl = new PetInfoController(providerMock.Object, managerMock.Object);
            var result = (ViewResult)ctrl.Index();

            Assert.AreEqual(model, result.Model);

            providerMock.VerifyAll();
            managerMock.VerifyAll();
        }
    }
}
