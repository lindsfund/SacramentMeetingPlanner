using System.ComponentModel.DataAnnotations;

namespace SacramentMeetingPlanner.Models
{
    public class MeetingPlan
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime MeetingDate { get; set; }
        public string? ConductingLeader { get; set; }
        public string? PresidingLeader { get; set; }
        public string? OpeningHymn {  get; set; }
        public string? OpeningPrayer { get; set; }
        public string? Buisness { get; set; }
        public string? SacramentHymn { get; set; }
        public string? Speaker {  get; set; }
        public string? MusicalNumber { get; set; }
        public string? ClosingHymn { get; set; }
        public string? ClosingPrayer { get; set; }
        

    }
}
