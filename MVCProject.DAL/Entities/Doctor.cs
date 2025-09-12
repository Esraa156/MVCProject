namespace MVCProject.DAL.Entities
{
    public class Doctor
    {
        public int DoctorID { get; set; }
        public int ClinicID { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }
        public virtual Clinic Clinic { get; set; }
        public virtual ICollection<DoctorSchedule> Schedules { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
