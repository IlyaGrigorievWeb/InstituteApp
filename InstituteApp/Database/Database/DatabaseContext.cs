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
        /// Пользователи
        /// </summary>
        public virtual DbSet<Institute> Institutes { get; set; }

        /// <summary>
        /// Роботы
        /// </summary>
        public virtual DbSet<Specialty> Specialties { get; set; }

        /// <summary>
        /// Места
        /// </summary>
        public virtual DbSet<Direction> Directions { get; set; }
    }
}
