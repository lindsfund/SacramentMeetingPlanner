using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SacramentMeetingPlanner.Models
{
    public class MeetingPlanSpeaker
    {
        public int Id { get; set; }
        public int MeetingPlanId  { get; set; }
        [ForeignKey("MeetingPlanId")]
        public MeetingPlan? MeetingPlans { get; set; }
        public int SpeakerId { get; set; }
        [ForeignKey("SpeakerId")]
        public Speaker? Speakers { get; set; }
    }
}
