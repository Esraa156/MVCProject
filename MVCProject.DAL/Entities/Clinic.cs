namespace MVCProject.DAL.Entities
{
    public class Clinic
    {
        public int ClinicID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
