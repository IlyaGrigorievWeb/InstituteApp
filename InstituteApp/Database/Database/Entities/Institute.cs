using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Database.Enums;

namespace Database.Database.Entities
{
    public class Institute
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public InstituteType Type { get; set; }
        public List<Guid> SpecialtiesGuids { get; set; }
        public string Address { get; set; }
        public string Url { get; set; }
        public string Director { get; set; }
        public string Phone { get; set; }
    }
}
