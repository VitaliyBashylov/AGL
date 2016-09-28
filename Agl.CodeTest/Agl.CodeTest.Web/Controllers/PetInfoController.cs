using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Agl.CodeTest.Dal;
using Agl.CodeTest.Web.Interfaces;

namespace Agl.CodeTest.Web.Controllers
{
    public class PetInfoController : Controller
    {
        private readonly IPeopleProvider peopleProvider;
        private readonly IPetInfoManager petInfoManager;

        public PetInfoController(IPeopleProvider peopleProvider, IPetInfoManager petInfoManager)
        {
            this.peopleProvider = peopleProvider;
            this.petInfoManager = petInfoManager;
        }

        public ActionResult Index()
        {
            var people = peopleProvider.GetAll();
            var model = petInfoManager.GetPetNamesByGender(people);
            return View(model);
        }
    }
}