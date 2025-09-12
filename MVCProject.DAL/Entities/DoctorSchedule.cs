using System.ComponentModel.DataAnnotations;

namespace MVCProject.DAL.Entities
{
    public class DoctorSchedule
    {
        [Key]
        public int ScheduleID { get; set; }
        public int DoctorID { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
