using System.ComponentModel.DataAnnotations.Schema;

namespace SacramentMeetingPlanner.Models
{
    public class Speaker
    {
        public int SpeakerId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Topic { get; set; } = string.Empty;

        [InverseProperty("Speakers")]
        // public virtual ICollection<MeetingPlanSpeaker>? MeetingPlanSpeakers { get; set; }
        // public virtual ICollection<MeetingPlanSpeaker>? MeetingPlans { get; set; }
        public virtual ICollection<MeetingPlan>? MeetingPlans { get; set; }

        public override string ToString()
        {
            return $"Id: {SpeakerId} :: Name: {Name}";
        }
    }
}
