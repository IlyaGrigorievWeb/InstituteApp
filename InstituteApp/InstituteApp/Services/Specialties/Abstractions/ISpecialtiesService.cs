using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Database.Entities;
using InstituteApp.Services.Specialties.Models;

namespace InstituteApp.Services.Specialties.Abstractions
{
    public interface ISpecialtiesService
    {
        Task<List<Specialty>> GetSpecialties();
        Task<List<Specialty>> GetSpecialties(Guid instituteGuid);
        Task<Specialty> GetSpecialty(Guid specialtyGuid);
        Task<Guid> CreateSpecialty(SpecialtyInfo specialtyInfo);
        Task UpdateSpecialty(SpecialtyInfo specialtyInfo, Guid specialtyGuid);
        Task DeleteSpecialty(Guid specialtyGuid);
    }
}
