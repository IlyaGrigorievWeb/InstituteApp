using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }

        /// <summary>
        /// Учебные заведения
        /// </summary>
        public virtual DbSet<Institute> Institutes { get; set; }

        /// <summary>
        /// Специальности
        /// </summary>
        public virtual DbSet<Specialty> Specialties { get; set; }

        /// <summary>
        /// Направления
        /// </summary>
        public virtual DbSet<Direction> Directions { get; set; }
    }
}
