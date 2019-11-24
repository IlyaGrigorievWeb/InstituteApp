using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Database.Entities;
using InstituteApp.Services.Directions.Abstractions;
using InstituteApp.Services.Directions.Models;
using Microsoft.AspNetCore.Mvc;

namespace InstituteApp.Controllers
{
    /// <summary>
    /// Контроллер направлений
    /// </summary>
    //[Authorize("Bearer")]
    [Route("/Directions")]
    public class DirectionsController
    {
        private readonly IDirectionsService _directionsService;

        public DirectionsController(IDirectionsService directionsService)
        {
            _directionsService = directionsService;
        }

        /// <summary>
        /// Получение всех направлений
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<Direction>> GetDirections()
        {
            return await _directionsService.GetDirections();
        }

        /// <summary>
        /// Получние направления
        /// </summary>
        /// <param name="directionGuid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{directionGuid}")]
        public async Task<Direction> GetDirection(Guid directionGuid)
        {
            return await _directionsService.GetDirection(directionGuid);
        }

        /// <summary>
        /// Добавление направления
        /// </summary>
        /// <param name="directionInfo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Guid> AddDirection([FromBody] DirectionInfo directionInfo)
        {
            return await _directionsService.CreateDirection(directionInfo);
        }
        /// <summary>
        /// Изменение направления
        /// </summary>
        /// <param name="directionInfo"></param>
        /// <param name="directionGuid"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("{directionGuid}")]
        public async Task UpdateDirection([FromBody] DirectionInfo directionInfo,Guid directionGuid)
        {
            await _directionsService.UpdateDirection(directionInfo,directionGuid);
        }
        /// <summary>
        /// Удаление направления
        /// </summary>
        /// <param name="directionGuid"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{directionGuid}")]
        public async Task DeleteDirection(Guid directionGuid)
        {
            await _directionsService.DeleteDirection(directionGuid);
        }
    }
}
