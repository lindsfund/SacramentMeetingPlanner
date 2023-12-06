using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Data
{
    public class HymnsContext : DbContext
    {
        public HymnsContext (DbContextOptions<HymnsContext> options)
            : base(options)
        {
        }

        public DbSet<SacramentMeetingPlanner.Models.Hymn> Hymn { get; set; } = default!;
    }
}
