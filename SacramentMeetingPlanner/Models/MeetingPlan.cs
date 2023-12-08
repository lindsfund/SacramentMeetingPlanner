using System.ComponentModel.DataAnnotations;

namespace SacramentMeetingPlanner.Models
{
    public class MeetingPlan
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Meeting Date")]
        [DataType(DataType.Date)]
        public DateTime MeetingDate { get; set; }
        
        [Display(Name = "Conducting")]
        public string? ConductingLeader { get; set; }

        [Display(Name = "Presiding")]
        public string? PresidingLeader { get; set; }

        [Display(Name = "Opening Hymn")]
        public string? OpeningHymn {  get; set; }

        [Display(Name = "Opening Prayer")]
        public string? OpeningPrayer { get; set; }

        [Display(Name = "Stake/Ward/Branch Business")]
        public string? Buisness { get; set; }

        [Display(Name = "Sacrament Hymn")]
        public string? SacramentHymn { get; set; }


        public string? Speaker {  get; set; }

        [Display(Name = "Musical Number (optional)")]
        public string? MusicalNumber { get; set; }

        [Display(Name = "Closing Hymn")]
        public string? ClosingHymn { get; set; }

        [Display(Name = "Closing Prayer")]
        public string? ClosingPrayer { get; set; }
        

    }
}
