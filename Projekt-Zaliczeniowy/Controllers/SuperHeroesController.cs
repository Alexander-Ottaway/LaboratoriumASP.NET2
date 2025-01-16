using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projekt_Zaliczeniowy.Models.SuperHeroes;

namespace Projekt_Zaliczeniowy.Controllers
{
    public class SuperHeroesController : Controller
    {
        private readonly SuperHeroesDbContext _context;

        public SuperHeroesController(SuperHeroesDbContext context)
        {
            _context = context;
        }

        // GET: SuperHeroes
        public async Task<IActionResult> Index()
        {
            var superHeroesDbContext = _context.Superheroes.Include(s => s.Alignment).Include(s => s.EyeColour).Include(s => s.Gender).Include(s => s.HairColour).Include(s => s.Publisher).Include(s => s.Race).Include(s => s.SkinColour);
            return View(await superHeroesDbContext.ToListAsync());
        }

        // GET: SuperHeroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superhero = await _context.Superheroes
                .Include(s => s.Alignment)
                .Include(s => s.EyeColour)
                .Include(s => s.Gender)
                .Include(s => s.HairColour)
                .Include(s => s.Publisher)
                .Include(s => s.Race)
                .Include(s => s.SkinColour)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (superhero == null)
            {
                return NotFound();
            }

            return View(superhero);
        }

        // GET: SuperHeroes/Create
        public IActionResult Create()
        {
            ViewData["AlignmentId"] = new SelectList(_context.Alignments, "Id", "Id");
            ViewData["EyeColourId"] = new SelectList(_context.Colours, "Id", "Id");
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "Id");
            ViewData["HairColourId"] = new SelectList(_context.Colours, "Id", "Id");
            ViewData["PublisherId"] = new SelectList(_context.Publishers, "Id", "Id");
            ViewData["RaceId"] = new SelectList(_context.Races, "Id", "Id");
            ViewData["SkinColourId"] = new SelectList(_context.Colours, "Id", "Id");
            return View();
        }

        // POST: SuperHeroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SuperheroName,FullName,GenderId,EyeColourId,HairColourId,SkinColourId,RaceId,PublisherId,AlignmentId,HeightCm,WeightKg")] Superhero superhero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(superhero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlignmentId"] = new SelectList(_context.Alignments, "Id", "Id", superhero.AlignmentId);
            ViewData["EyeColourId"] = new SelectList(_context.Colours, "Id", "Id", superhero.EyeColourId);
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "Id", superhero.GenderId);
            ViewData["HairColourId"] = new SelectList(_context.Colours, "Id", "Id", superhero.HairColourId);
            ViewData["PublisherId"] = new SelectList(_context.Publishers, "Id", "Id", superhero.PublisherId);
            ViewData["RaceId"] = new SelectList(_context.Races, "Id", "Id", superhero.RaceId);
            ViewData["SkinColourId"] = new SelectList(_context.Colours, "Id", "Id", superhero.SkinColourId);
            return View(superhero);
        }

        // GET: SuperHeroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superhero = await _context.Superheroes.FindAsync(id);
            if (superhero == null)
            {
                return NotFound();
            }
            ViewData["AlignmentId"] = new SelectList(_context.Alignments, "Id", "Id", superhero.AlignmentId);
            ViewData["EyeColourId"] = new SelectList(_context.Colours, "Id", "Id", superhero.EyeColourId);
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "Id", superhero.GenderId);
            ViewData["HairColourId"] = new SelectList(_context.Colours, "Id", "Id", superhero.HairColourId);
            ViewData["PublisherId"] = new SelectList(_context.Publishers, "Id", "Id", superhero.PublisherId);
            ViewData["RaceId"] = new SelectList(_context.Races, "Id", "Id", superhero.RaceId);
            ViewData["SkinColourId"] = new SelectList(_context.Colours, "Id", "Id", superhero.SkinColourId);
            return View(superhero);
        }

        // POST: SuperHeroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SuperheroName,FullName,GenderId,EyeColourId,HairColourId,SkinColourId,RaceId,PublisherId,AlignmentId,HeightCm,WeightKg")] Superhero superhero)
        {
            if (id != superhero.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(superhero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuperheroExists(superhero.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlignmentId"] = new SelectList(_context.Alignments, "Id", "Id", superhero.AlignmentId);
            ViewData["EyeColourId"] = new SelectList(_context.Colours, "Id", "Id", superhero.EyeColourId);
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "Id", superhero.GenderId);
            ViewData["HairColourId"] = new SelectList(_context.Colours, "Id", "Id", superhero.HairColourId);
            ViewData["PublisherId"] = new SelectList(_context.Publishers, "Id", "Id", superhero.PublisherId);
            ViewData["RaceId"] = new SelectList(_context.Races, "Id", "Id", superhero.RaceId);
            ViewData["SkinColourId"] = new SelectList(_context.Colours, "Id", "Id", superhero.SkinColourId);
            return View(superhero);
        }

        // GET: SuperHeroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superhero = await _context.Superheroes
                .Include(s => s.Alignment)
                .Include(s => s.EyeColour)
                .Include(s => s.Gender)
                .Include(s => s.HairColour)
                .Include(s => s.Publisher)
                .Include(s => s.Race)
                .Include(s => s.SkinColour)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (superhero == null)
            {
                return NotFound();
            }

            return View(superhero);
        }

        // POST: SuperHeroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var superhero = await _context.Superheroes.FindAsync(id);
            if (superhero != null)
            {
                _context.Superheroes.Remove(superhero);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuperheroExists(int id)
        {
            return _context.Superheroes.Any(e => e.Id == id);
        }
    }
}