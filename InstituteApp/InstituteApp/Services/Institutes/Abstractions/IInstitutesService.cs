using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Database.Entities;
using InstituteApp.Services.Institutes.Models;

namespace InstituteApp.Services.Institutes.Abstractions
{
    public interface IInstitutesService
    {
        Task<List<Institute>> GetInstitutes();
        Task<Institute> GetInstitute(Guid instituteGuid);
        Task<Guid> CreateInstitute(InstituteInfo instituteInfo);
        Task UpdateInstitute(InstituteInfo instituteInfo, Guid instituteGuid);
        Task DeleteInstitute(Guid instituteGuid);

    }
}
