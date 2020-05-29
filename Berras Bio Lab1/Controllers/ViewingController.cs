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
    public class ViewingController : Controller
    {
        private readonly BerrasBioDbContext _context;

        public ViewingController(BerrasBioDbContext context)
        {
            _context = context;
        }

        // GET: Viewing
        public async Task<IActionResult> Index()
        {
            var berrasBioDbContext = _context.Viewings.Where(v => v.StartTime.Date == DateTime.Today).Include(v => v.Movie).Include(v => v.Theater);
            var berrasBioDbContextList = await berrasBioDbContext.ToListAsync();


            return View(berrasBioDbContextList.OrderBy(v => v.StartTime).ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string SortButton)
        {
            var berrasBioDbContext = _context.Viewings.Where(v => v.StartTime.Date == DateTime.Today).Include(v => v.Movie).Include(v => v.Theater);
            var berrasBioDbContextList = await berrasBioDbContext.ToListAsync();

            if (SortButton == "Start time")
            {
                berrasBioDbContextList = berrasBioDbContextList.OrderBy(v => v.StartTime).ToList();
            }
            else if (SortButton == "Avaible seats")
            {
                berrasBioDbContextList = berrasBioDbContextList.OrderByDescending(v => v.AvaibleSeats).ThenBy(v => v.StartTime).ToList();
            }

            return View(berrasBioDbContextList);
        }
        //Implementera sortering genom att lägga till action som tar emot en string, beroende på vad de ger så sorteras listan efter det. Sätt som A tag.










        // GET: Viewing/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewingModel = await _context.Viewings
                .Include(v => v.Movie)
                .Include(v => v.Theater)
                .FirstOrDefaultAsync(m => m.ViewingModelId == id);
            if (viewingModel == null)
            {
                return NotFound();
            }

            return View(viewingModel);
        }

        // GET: Viewing/Create
        public IActionResult Create()
        {
            ViewData["MovieModelId"] = new SelectList(_context.Movies, "MovieModelId", "Name");
            ViewData["TheaterModelId"] = new SelectList(_context.Theaters, "TheaterModelId", "Name");
            return View();
        }

        // POST: Viewing/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ViewingModelId,StartTime,AvaibleSeats,TotalSeats,TheaterModelId,MovieModelId")] ViewingModel viewingModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(viewingModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieModelId"] = new SelectList(_context.Movies, "MovieModelId", "Category", viewingModel.MovieModelId);
            ViewData["TheaterModelId"] = new SelectList(_context.Theaters, "TheaterModelId", "Name", viewingModel.TheaterModelId);
            return View(viewingModel);
        }

        // GET: Viewing/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewingModel = await _context.Viewings.FindAsync(id);
            if (viewingModel == null)
            {
                return NotFound();
            }
            ViewData["MovieModelId"] = new SelectList(_context.Movies, "MovieModelId", "Category", viewingModel.MovieModelId);
            ViewData["TheaterModelId"] = new SelectList(_context.Theaters, "TheaterModelId", "Name", viewingModel.TheaterModelId);
            return View(viewingModel);
        }

        // POST: Viewing/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ViewingModelId,StartTime,AvaibleSeats,TotalSeats,TheaterModelId,MovieModelId")] ViewingModel viewingModel)
        {
            if (id != viewingModel.ViewingModelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viewingModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ViewingModelExists(viewingModel.ViewingModelId))
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
            ViewData["MovieModelId"] = new SelectList(_context.Movies, "MovieModelId", "Category", viewingModel.MovieModelId);
            ViewData["TheaterModelId"] = new SelectList(_context.Theaters, "TheaterModelId", "Name", viewingModel.TheaterModelId);
            return View(viewingModel);
        }

        // GET: Viewing/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewingModel = await _context.Viewings
                .Include(v => v.Movie)
                .Include(v => v.Theater)
                .FirstOrDefaultAsync(m => m.ViewingModelId == id);
            if (viewingModel == null)
            {
                return NotFound();
            }

            return View(viewingModel);
        }

        // POST: Viewing/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var viewingModel = await _context.Viewings.FindAsync(id);
            _context.Viewings.Remove(viewingModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ViewingModelExists(int id)
        {
            return _context.Viewings.Any(e => e.ViewingModelId == id);
        }
    }
}
