using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Data
{
    public class MusicalNumbersContext : DbContext
    {
        public MusicalNumbersContext (DbContextOptions<MusicalNumbersContext> options)
            : base(options)
        {
        }

        public DbSet<SacramentMeetingPlanner.Models.MusicalNumber> MusicalNumber { get; set; } = default!;
    }
}
