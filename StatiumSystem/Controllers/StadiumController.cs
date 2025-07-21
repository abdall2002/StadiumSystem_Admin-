using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StatiumSystem.Models;

namespace StatiumSystem.Controllers
{
    [Authorize(Roles = "Admin")]

    public class StadiumController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly StadiumDbContext _context;
        private readonly IMapper _mapper;

        public StadiumController(StadiumDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }
        // Create Stadium
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(StadiumDTO stadiumDTO)
        {
            if (ModelState.IsValid)
            {
                var stadium = _mapper.Map<Stadium>(stadiumDTO);
                _context.Stadiums.Add(stadium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stadiumDTO);
        }
    }
}
