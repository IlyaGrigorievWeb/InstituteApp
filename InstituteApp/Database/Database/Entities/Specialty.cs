using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Database.Enums;

namespace Database.Database.Entities
{
    public class Specialty
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DirectionCode { get; set; }
        public List<int> AdmissionSubjects { get; set; }
    }
}
