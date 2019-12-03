using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Database;
using Database.Database.Entities;
using Database.Database.Enums;
using InstituteApp.Services.Institutes.Abstractions;
using InstituteApp.Services.Institutes.Models;
using Microsoft.EntityFrameworkCore;

namespace InstituteApp.Services.Institutes
{
    public class InstitutesService : IInstitutesService
    {
        private readonly DatabaseContext _dbContext;
        public InstitutesService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<InstituteModel>> GetInstitutes(string directionCode, List<Subject> subjects)
        {
            var institutes = await _dbContext.Institutes.ToListAsync();

            var specialties = await _dbContext.Specialties.ToListAsync();

            var institutesModels = institutes.Select(institute =>
            {
                return new InstituteModel()
                {
                    Id = institute.Id,
                    Address = institute.Address,
                    Director = institute.Director,
                    Name = institute.Name,
                    Phone = institute.Phone,
                    Type = institute.Type,
                    Url = institute.Url,
                    Specialties = specialties.Where( specialtyFromDb => institute.SpecialtiesGuids.Contains(specialtyFromDb.Id)).ToList()
                };
            });
            if (directionCode != null)
            {
                institutesModels = institutesModels.Where(institute => institute.Specialties.Any(e => e.DirectionCode.Contains(directionCode)));
            }
            if (subjects.Count != 0)
            {
                institutesModels = institutesModels.Where(institute => institute.Specialties.Any(e => e.AdmissionSubjects.Any(a => subjects.Contains(((Subject)a)))));
            }

            return institutesModels.ToList();
        }
        public async Task<InstituteModel> GetInstitute(Guid instituteGuid)
        {
            var specialties = await _dbContext.Specialties.ToListAsync();
            var institute = await _dbContext.Institutes.FirstOrDefaultAsync(e => e.Id == instituteGuid);
            var instituteModel = new InstituteModel()
            {
                Id = institute.Id,
                Address = institute.Address,
                Director = institute.Director,
                Name = institute.Name,
                Phone = institute.Phone,
                Type = institute.Type,
                Url = institute.Url,
                Specialties = specialties.Where(specialtyFromDb => institute.SpecialtiesGuids.Contains(specialtyFromDb.Id)).ToList()

            };
            return instituteModel;
        }

        public async Task<Guid> CreateInstitute(InstituteInfo instituteInfo)
        {
            var institute = new Institute()
            {
                Id = Guid.NewGuid(),
                Name = instituteInfo.Name,
                SpecialtiesGuids = instituteInfo.SpecialtiesGuids,
                Address = instituteInfo.Address,
                Director = instituteInfo.Director,
                Url = instituteInfo.Url,
                Phone = instituteInfo.Phone,
                Type = instituteInfo.Type
            };
            await _dbContext.Institutes.AddAsync(institute);
            await _dbContext.SaveChangesAsync();
            return institute.Id;
        }
        public async Task UpdateInstitute(InstituteInfo instituteInfo, Guid instituteGuid)
        {
            var institute = await _dbContext.Institutes.FirstOrDefaultAsync(e => e.Id == instituteGuid);
            institute.Name = instituteInfo.Name;
            institute.SpecialtiesGuids = instituteInfo.SpecialtiesGuids;
            institute.Address = instituteInfo.Address;
            institute.Director = instituteInfo.Director;
            institute.Url = instituteInfo.Url;
            institute.Phone = instituteInfo.Phone;
            institute.Type = instituteInfo.Type;
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteInstitute(Guid instituteGuid)
        {
            var institute = await _dbContext.Institutes.FirstOrDefaultAsync(e => e.Id == instituteGuid);
            _dbContext.Institutes.Remove(institute);
            await _dbContext.SaveChangesAsync();
        }
    }
}
