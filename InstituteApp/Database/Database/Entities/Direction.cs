using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Database.Entities
{
    public class Direction
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string DirectionCode { get; set; }
    }
}
