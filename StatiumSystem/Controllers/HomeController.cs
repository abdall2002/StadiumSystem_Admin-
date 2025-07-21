
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StatiumSystem.Models;

namespace StatiumSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly StadiumDbContext _context;
        private readonly IMapper _mapper;

        public HomeController(StadiumDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var reservations = await _context.Reservations
                .Include(r => r.Stadium)
                .OrderByDescending(r => r.ReservationDate)
                .ThenByDescending(r => r.StartTime)
                .ToListAsync();

            var reservationsDTO = _mapper.Map<List<ReservationFullViewDTO>>(reservations);

            return View(reservationsDTO);
        }
    }

}
