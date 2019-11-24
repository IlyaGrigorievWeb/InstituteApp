using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Database.Database;
using Database.Database.Entities;
using InstituteApp.Services.Directions.Abstractions;
using InstituteApp.Services.Directions.Models;
using Microsoft.EntityFrameworkCore;

namespace InstituteApp.Services.Directions
{
    public class DirectionsService : IDirectionsService
    {
        private readonly DatabaseContext _dbContext;
        public DirectionsService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Direction>> GetDirections()
        {
            return await _dbContext.Directions.ToListAsync();
        }
        public async Task<Direction> GetDirection(Guid directionGuid)
        {
            return await _dbContext.Directions.FirstOrDefaultAsync(e => e.Id == directionGuid);
        }

        public async Task<Guid> CreateDirection(DirectionInfo directionInfo)
        { 
            var direction = new Direction()
            {
                Id = Guid.NewGuid(),
                DirectionCode = directionInfo.DirectionCode,
                Name = directionInfo.Name
            };
            await _dbContext.Directions.AddAsync(direction);
            await _dbContext.SaveChangesAsync();
            return direction.Id;
        }
        public async Task UpdateDirection(DirectionInfo directionInfo,Guid directionGuid)
        {
            var direction = await GetDirection(directionGuid);
            direction.Name = directionInfo.Name;
            direction.DirectionCode = directionInfo.DirectionCode;
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteDirection(Guid directionGuid)
        {
            var direction = await GetDirection(directionGuid);
            _dbContext.Directions.Remove(direction);
            await _dbContext.SaveChangesAsync();
        }

    }
}
