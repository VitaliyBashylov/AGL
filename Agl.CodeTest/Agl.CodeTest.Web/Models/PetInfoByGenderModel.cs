using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agl.CodeTest.Web.Models
{
    public class PetInfoByGenderModel
    {
        public PetInfoModelPart Male { get; set; }
        public PetInfoModelPart Female { get; set; }
    }
    public class PetInfoModelPart
    {
        public string GenderName { get; set; }
        public List<string> Names { get; set; }
    }
}