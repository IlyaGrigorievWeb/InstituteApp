using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Database;
using Database.Database.Entities;
using Database.Database.Enums;
using InstituteApp.Services.Specialties.Abstractions;
using InstituteApp.Services.Specialties.Models;
using Microsoft.EntityFrameworkCore;

namespace InstituteApp.Services.Specialties
{
    public class SpecialtiesService : ISpecialtiesService
    {
        private readonly DatabaseContext _dbContext;

        public SpecialtiesService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Specialty>> GetSpecialties()
        {
            return await _dbContext.Specialties.ToListAsync();
        }
        public async Task<List<Specialty>> GetSpecialties(Guid instituteGuid)
        {
            var specialtiesGuid = (await _dbContext.Institutes.FirstOrDefaultAsync(e => e.Id == instituteGuid)).SpecialtiesGuids;
            return await _dbContext.Specialties.Where(e => specialtiesGuid.Contains(e.Id)).ToListAsync();
        }

        public async Task<Specialty> GetSpecialty(Guid specialtyGuid)
        {
            return await _dbContext.Specialties.FirstOrDefaultAsync( e => e.Id == specialtyGuid);
        }

        public async Task<Guid> CreateSpecialty(SpecialtyInfo specialtyInfo)
        {
            var specialty = new Specialty()
            {
                Id = Guid.NewGuid(),
                Name = specialtyInfo.Name,
                DirectionCode = specialtyInfo.DirectionCode,
                AdmissionSubjects = specialtyInfo.AdmissionSubjects.Select(e => (int)e).ToList()
            };
            await _dbContext.Specialties.AddAsync(specialty);
            await _dbContext.SaveChangesAsync();
            return specialty.Id;
        }
        public async Task UpdateSpecialty(SpecialtyInfo specialtyInfo, Guid specialtyGuid)
        {
            var specialty = await GetSpecialty(specialtyGuid);
            specialty.Name = specialtyInfo.Name;
            specialty.DirectionCode = specialtyInfo.DirectionCode;
            specialty.AdmissionSubjects = specialtyInfo.AdmissionSubjects.Select(e => (int)e).ToList();
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteSpecialty(Guid specialtyGuid)
        {
            var specialty = await GetSpecialty(specialtyGuid);
            _dbContext.Specialties.Remove(specialty);
            await _dbContext.SaveChangesAsync();
        }
    }
}
