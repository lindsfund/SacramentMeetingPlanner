using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Data
{
    public class MeetingPlanContext : DbContext
    {
        public MeetingPlanContext (DbContextOptions<MeetingPlanContext> options)
            : base(options)
        {
        }

        public DbSet<SacramentMeetingPlanner.Models.MeetingPlan> MeetingPlan { get; set; } = default!;
    }
}
