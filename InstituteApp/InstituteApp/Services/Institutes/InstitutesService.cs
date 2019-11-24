using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Database.Database;
using Database.Database.Entities;
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

        public async Task<List<Institute>> GetInstitutes()
        {
            return await _dbContext.Institutes.ToListAsync();
        }
        public async Task<Institute> GetInstitute(Guid instituteGuid)
        {
            return await _dbContext.Institutes.FirstOrDefaultAsync(e => e.Id == instituteGuid);
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
            var institute = await GetInstitute(instituteGuid);
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
            var institute = await GetInstitute(instituteGuid);
            _dbContext.Institutes.Remove(institute);
            await _dbContext.SaveChangesAsync();
        }
    }
}
