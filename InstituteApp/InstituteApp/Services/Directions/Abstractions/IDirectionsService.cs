using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Database.Entities;
using InstituteApp.Services.Directions.Models;

namespace InstituteApp.Services.Directions.Abstractions
{
    public interface IDirectionsService
    {
        Task<List<Direction>> GetDirections();
        Task<Direction> GetDirection(Guid directionGuid);
        Task<Guid> CreateDirection(DirectionInfo directionInfo);
        Task UpdateDirection(DirectionInfo directionInfo, Guid directionGuid);
        Task DeleteDirection(Guid directionGuid);
    }
}
