using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StatiumSystem.Models;

namespace StatiumSystem.Controllers
{
    public class ReservationController : Controller
    {
        private readonly StadiumDbContext _context;
        private readonly IMapper _mapper;

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ReservationDTO reservationDTO)
        {
            if (ModelState.IsValid)
            {
                var reservation = _mapper.Map<Reservation>(reservationDTO);
                reservation.Status = "Pending"; // Set default status
                _context.Reservations.Add(reservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reservationDTO);
        }
    }
}
