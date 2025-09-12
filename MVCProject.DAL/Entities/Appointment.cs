namespace MVCProject.DAL.Entities
{
    public class Appointment
    {
        public int AppointmentID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public int VisitLength { get; set; } = 30; // default
        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
