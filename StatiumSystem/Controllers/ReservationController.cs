using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StadiumSystem.Models;
using AutoMapper;
using StatiumSystem.Models;

[Authorize]
public class ReservationController : Controller
{
    private readonly StadiumDbContext _context;
    private readonly IMapper _mapper;

    public ReservationController(StadiumDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // GET: Reservations/Create
    public async Task<IActionResult> Create(int? stadiumId)
    {
        if (stadiumId == null) return NotFound();

        var stadium = await _context.Stadiums.FindAsync(stadiumId);
        if (stadium == null) return NotFound();

        ViewBag.StadiumName = stadium.Name;
        ViewBag.StadiumId = stadium.Id;

        // تعبئة اسم المستخدم تلقائيا هنا
        return View(new ReservationDTO
        {
            StadiumId = stadium.Id,
            UserName = User.Identity.Name ?? "Unknown"
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ReservationDTO reservationDTO)
    {
        // إعادة تعبئة اسم المستخدم حتى بعد POST
        reservationDTO.UserName = User.Identity.Name ?? "Unknown";

        if (!ModelState.IsValid)
        {
            var stadium = await _context.Stadiums.FindAsync(reservationDTO.StadiumId);
            ViewBag.StadiumName = stadium?.Name ?? "Unknown";
            ViewBag.StadiumId = stadium?.Id ?? 0;
            return View(reservationDTO);
        }

        // تحقق من التعارض
        var hasConflict = await _context.Reservations.AnyAsync(r =>
            r.StadiumId == reservationDTO.StadiumId &&
            r.ReservationDate == reservationDTO.ReservationDate &&
            (
                (reservationDTO.StartTime >= r.StartTime && reservationDTO.StartTime < r.EndTime) ||
                (reservationDTO.EndTime > r.StartTime && reservationDTO.EndTime <= r.EndTime) ||
                (reservationDTO.StartTime <= r.StartTime && reservationDTO.EndTime >= r.EndTime)
            )
        );

        if (hasConflict)
        {
            ModelState.AddModelError("", "This time slot conflicts with an existing reservation.");
            var stadium = await _context.Stadiums.FindAsync(reservationDTO.StadiumId);
            ViewBag.StadiumName = stadium?.Name ?? "Unknown";
            ViewBag.StadiumId = stadium?.Id ?? 0;
            return View(reservationDTO);
        }

        var reservation = _mapper.Map<Reservation>(reservationDTO);
        reservation.Status = "Pending";

        _context.Reservations.Add(reservation);
        await _context.SaveChangesAsync();

        TempData["Success"] = "Reservation created successfully!";
        return RedirectToAction("Index", "Stadium");
    }
}
