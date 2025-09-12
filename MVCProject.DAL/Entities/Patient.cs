namespace MVCProject.DAL.Entities
{
    public class Patient
    {
        public int PatientID { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string? ContactInfo { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
