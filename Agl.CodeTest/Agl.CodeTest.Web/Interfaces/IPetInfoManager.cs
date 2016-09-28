using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agl.CodeTest.Dal.Entities;
using Agl.CodeTest.Web.Models;

namespace Agl.CodeTest.Web.Interfaces
{
    public interface IPetInfoManager
    {
        PetInfoByGenderModel GetPetNamesByGender(List<Person> people);
    }
}
