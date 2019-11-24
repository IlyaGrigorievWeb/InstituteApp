using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Database.Enums;

namespace InstituteApp.Services.Specialties.Models
{
    public class SpecialtyInfo
    {
        public string Name { get; set; }
        public string DirectionCode { get; set; }
        public List<Subject> AdmissionSubjects { get; set; }
    }
}
