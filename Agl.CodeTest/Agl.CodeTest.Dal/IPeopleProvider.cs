using System.Collections.Generic;
using Agl.CodeTest.Dal.Entities;

namespace Agl.CodeTest.Dal
{
    public interface IPeopleProvider
    {
        List<Person> GetAll();
    }
}
