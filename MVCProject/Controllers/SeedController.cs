using Microsoft.AspNetCore.Mvc;
using MVCProject.Data;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class SeedController : Controller
    {
        //    private readonly ApplicationDbContext _context;

        //    public SeedController(ApplicationDbContext context)
        //    {
        //        _context = context;
        //    }

        //    public IActionResult SeedData()
        //    {


        //        // 1️⃣ Insert Clinic
        //        var clinic = new Clinic { Name = "Central Clinic" ,Address="sadat"};
        //        _context.Clinics.Add(clinic);
        //        _context.SaveChanges();

        //        // 2️⃣ Insert Doctor
        //        var doctor = new Doctor
        //        {
        //            Name = "Dr. Ahmed",
        //            Specialty = "Cardiology",
        //            ClinicID = clinic.ClinicID
        //        };
        //        _context.Doctors.Add(doctor);
        //        _context.SaveChanges();

        //        // 3️⃣ Insert DoctorSchedule
        //        var schedule = new DoctorSchedule
        //        {
        //            DoctorID = doctor.DoctorID,
        //            DayOfWeek = DayOfWeek.Monday,
        //            StartTime = new TimeSpan(16, 0, 0), // 4 PM
        //            EndTime = new TimeSpan(20, 0, 0)    // 8 PM
        //        };
        //        _context.DoctorSchedules.Add(schedule);
        //        _context.SaveChanges();

        //        // 4️⃣ Insert Patient
        //        var patient = new Patient
        //        {
        //            Name = "Esraa Osama",
        //            BirthDate = new DateTime(2000, 1, 1)
        //        };
        //        _context.Patients.Add(patient);
        //        _context.SaveChanges();

        //        // 5️⃣ Insert Appointment
        //        var appointment = new Appointment
        //        {
        //            PatientID = patient.PatientID,
        //            DoctorID = doctor.DoctorID,
        //            AppointmentDate = DateTime.Today.AddDays(1),
        //            AppointmentTime = new TimeSpan(16, 30, 0) // 4:30 PM
        //        };
        //        _context.Appointments.Add(appointment);
        //        _context.SaveChanges();

        //        return Content("Seed data inserted successfully!");
        //    }
        //}
    }
}