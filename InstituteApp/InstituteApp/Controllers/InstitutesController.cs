using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Database.Entities;
using Database.Database.Enums;
using InstituteApp.Services.Institutes.Abstractions;
using InstituteApp.Services.Institutes.Models;
using Microsoft.AspNetCore.Mvc;

namespace InstituteApp.Controllers
{
    /// <summary>
    /// Контроллер учебных заведений
    /// </summary>
    //[Authorize("Bearer")]
    [Route("/Institutes")]
    public class InstitutesController
    {
        private readonly IInstitutesService _institutesService;

        public InstitutesController(IInstitutesService institutesService)
        {
            _institutesService = institutesService;
        }


        /// <summary>
        /// Получение всех учебных заведений
        /// </summary>
        /// <param name="directionCode"></param>
        /// <param name="subjects">Russian,Math, Biology, Chemistry,Social,Physics,Language</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<InstituteModel>> GetInstitutes([FromQuery]string directionCode, [FromQuery] List<Subject> subjects)
        {
            return await _institutesService.GetInstitutes(directionCode, subjects);
        }

        /// <summary>
        /// Получние учебного заведения
        /// </summary>
        /// <param name="instituteGuid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{instituteGuid}")]
        public async Task<Institute> GetInstitute(Guid instituteGuid)
        {
            return await _institutesService.GetInstitute(instituteGuid);
        }

        /// <summary>
        /// Добавление  учебного заведения
        /// </summary>
        /// <param name="instituteInfo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Guid> AddInstitute([FromBody] InstituteInfo instituteInfo)
        {
            return await _institutesService.CreateInstitute(instituteInfo);
        }
        /// <summary>
        /// Изменение  учебного заведения
        /// </summary>
        /// <param name="instituteInfo"></param>
        /// <param name="instituteGuid"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("{instituteGuid}")]
        public async Task UpdateInstitute([FromBody] InstituteInfo instituteInfo, Guid instituteGuid)
        {
            await _institutesService.UpdateInstitute(instituteInfo, instituteGuid);
        }
        /// <summary>
        /// Удаление  учебного заведения
        /// </summary>
        /// <param name="instituteGuid"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{instituteGuid}")]
        public async Task DeleteInstitute(Guid instituteGuid)
        {
            await _institutesService.DeleteInstitute(instituteGuid);
        }
    }
}
