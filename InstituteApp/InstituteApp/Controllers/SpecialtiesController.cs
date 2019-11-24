using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Database.Entities;
using InstituteApp.Services.Specialties.Abstractions;
using InstituteApp.Services.Specialties.Models;
using Microsoft.AspNetCore.Mvc;

namespace InstituteApp.Controllers
{
    /// <summary>
    /// Контроллер специальностей
    /// </summary>
    //[Authorize("Bearer")]
    [Route("/Specialties")]
    public class SpecialtiesController
    {
        private readonly ISpecialtiesService _specialtiesService;

        public SpecialtiesController(ISpecialtiesService specialtiesService)
        {
            _specialtiesService = specialtiesService;
        }

        /// <summary>
        /// Получение всех специальностей
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<Specialty>> GetSpecialties()
        {
            return await _specialtiesService.GetSpecialties();
        }

        /// <summary>
        /// Получние специальности
        /// </summary>
        /// <param name="specialtyGuid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{specialtyGuid}")]
        public async Task<Specialty> GetSpecialty(Guid specialtyGuid)
        {
            return await _specialtiesService.GetSpecialty(specialtyGuid);
        }

        /// <summary>
        /// Добавление  специальности
        /// </summary>
        /// <param name="specialtyInfo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Guid> AddSpecialty([FromBody] SpecialtyInfo specialtyInfo)
        {
            return await _specialtiesService.CreateSpecialty(specialtyInfo);
        }
        /// <summary>
        /// Изменение  специальности
        /// </summary>
        /// <param name="specialtyInfo"></param>
        /// <param name="specialtyGuid"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("{specialtyGuid}")]
        public async Task UpdateSpecialty([FromBody] SpecialtyInfo specialtyInfo, Guid specialtyGuid)
        {
            await _specialtiesService.UpdateSpecialty(specialtyInfo, specialtyGuid);
        }
        /// <summary>
        /// Удаление  специальности
        /// </summary>
        /// <param name="specialtyGuid"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{specialtyGuid}")]
        public async Task DeleteSpecialty(Guid specialtyGuid)
        {
            await _specialtiesService.DeleteSpecialty(specialtyGuid);
        }
    }
}
