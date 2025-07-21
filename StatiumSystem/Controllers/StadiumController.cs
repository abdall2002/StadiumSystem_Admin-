using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StatiumSystem.Models;

namespace StatiumSystem.Controllers
{
    [Authorize(Roles = "Admin")]

    public class StadiumController : Controller
    {
      
        private readonly StadiumDbContext _context;
        private readonly IMapper _mapper;

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var stadiums = await _context.Stadiums.ToListAsync();
            return View(stadiums);
        }
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var stadium = await _context.Stadiums.FindAsync(id);
            if (stadium == null) return NotFound();

            var stadiumDTO = _mapper.Map<StadiumDTO>(stadium);
            return View(stadiumDTO);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StadiumDTO stadiumDTO)
        {
            if (!ModelState.IsValid) return View(stadiumDTO);

            var stadium = await _context.Stadiums.FindAsync(id);
            if (stadium == null) return NotFound();

            stadium.Name = stadiumDTO.Name;
            stadium.ImageUrl = stadiumDTO.ImageUrl;

            _context.Update(stadium);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // حذف ملعب
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var stadium = await _context.Stadiums.FirstOrDefaultAsync(m => m.Id == id);
            if (stadium == null) return NotFound();

            return View(stadium);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stadium = await _context.Stadiums.FindAsync(id);
            if (stadium != null)
            {
                _context.Stadiums.Remove(stadium);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var stadium = await _context.Stadiums.FirstOrDefaultAsync(s => s.Id == id);
            if (stadium == null) return NotFound();

            return View(stadium);
        }

    }
}
