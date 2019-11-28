using Database.Database.Entities;
using Database.Database.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteApp.Services.Institutes.Models
{
    public class InstituteModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public InstituteType Type { get; set; }
        public List<Specialty> Specialties { get; set; }
        public string Address { get; set; }
        public string Url { get; set; }
        public string Director { get; set; }
        public string Phone { get; set; }
    }
}
