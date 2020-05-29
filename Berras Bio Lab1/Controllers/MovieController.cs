using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Berras_Bio_Lab1.Models;
using Berras_Bio_Lab1.Repository;

namespace Berras_Bio_Lab1.Controllers
{
    public class MovieController : Controller
    {
        private readonly BerrasBioDbContext _context;

        public MovieController(BerrasBioDbContext context)
        {
            _context = context;
        }

        // GET: Movie
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movies.ToListAsync());
        }

        // GET: Movie/Create
        public IActionResult Create42Aa()
        {
            return View();
        }

        // POST: Movie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create42Aa([Bind("MovieModelId,Name,RunTime,Category,Description")] MovieModel movieModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movieModel);
        }


        // GET: Movie/Delete/5
        public async Task<IActionResult> Delete42Aa(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieModel = await _context.Movies
                .FirstOrDefaultAsync(m => m.MovieModelId == id);
            if (movieModel == null)
            {
                return NotFound();
            }

            return View(movieModel);
        }

        // POST: Movie/Delete/5
        [HttpPost, ActionName("Delete42Aa")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed42Aa(int id)
        {
            var movieModel = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(movieModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieModelExists(int id)
        {
            return _context.Movies.Any(e => e.MovieModelId == id);
        }
    }
}
