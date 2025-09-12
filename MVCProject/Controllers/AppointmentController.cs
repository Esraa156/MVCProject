using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using MVCProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

public class AppointmentController : Controller
{
    private readonly ApplicationDbContext _context;
    public AppointmentController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Show all appointments
    [Authorize(Roles ="Admin")]
    public IActionResult Index()
    {
        var appointments = _context.Appointments
            .Include(a => a.Patient)
            .Include(a => a.Doctor)
            .ToList();
        return View(appointments);
    }

    //// GET: Create appointment
    //public IActionResult Create()
    //{
    //    ViewBag.Doctors = new SelectList(_context.Doctors, "DoctorID", "Name");
    //    return View();
    //}

    //// POST: Create appointment
    //[HttpPost]
    //public IActionResult Create(Appointment appointment, Patient patient)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        // Save patient first
    //        _context.Patients.Add(patient);
    //        _context.SaveChanges();

    //        // Assign patient to appointment
    //        appointment.PatientID = patient.PatientID;
    //        _context.Appointments.Add(appointment);
    //        _context.SaveChanges();
    //        return RedirectToAction("Index");
    //    }
    //    ViewBag.Doctors = new SelectList(_context.Doctors, "DoctorID", "Name");
    //    return View(appointment);
    //}

    //// Get available slots (AJAX)
    //public JsonResult GetAvailableSlots(int doctorId, DateTime date)
    //{
    //    var schedule = _context.DoctorSchedules
    //        .Where(s => s.DoctorID == doctorId && s.DayOfWeek == date.DayOfWeek)
    //        .FirstOrDefault();

    //    if (schedule == null) return Json(new List<string>());

    //    var appointments = _context.Appointments
    //        .Where(a => a.DoctorID == doctorId && a.AppointmentDate == date.Date)
    //        .Select(a => a.AppointmentTime)
    //        .ToList();

    //    var slots = new List<string>();
    //    TimeSpan slotTime = schedule.StartTime;
    //    while (slotTime + TimeSpan.FromMinutes(30) <= schedule.EndTime)
    //    {
    //        if (!appointments.Contains(slotTime))
    //            slots.Add(slotTime.ToString(@"hh\:mm"));
    //        slotTime = slotTime.Add(TimeSpan.FromMinutes(30));
    //    }
    //    return Json(slots);
    //}
}
