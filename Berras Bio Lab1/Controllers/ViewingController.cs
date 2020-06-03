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
            var viewingsList = await _context.Viewings
                .Where(v => v.StartTime.Date == DateTime.Today)
                .Include(v => v.Movie)
                .Include(v => v.Theater)
                .ToListAsync();

            return View(viewingsList.OrderBy(v => v.StartTime).ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string SortButton)
        {
            var viewings = await _context.Viewings
                .Where(v => v.StartTime.Date == DateTime.Today)
                .Include(v => v.Movie)
                .Include(v => v.Theater)
                .ToListAsync();

            if (SortButton == "Start time")
            {
                viewings = viewings.OrderBy(v => v.StartTime).ToList();
            }
            else if (SortButton == "Avaible seats")
            {
                viewings = viewings
                    .OrderByDescending(v => v.AvaibleSeats)
                    .ThenBy(v => v.StartTime)
                    .ToList();
            }

            return View(viewings);
        }


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

        //// GET: Viewing/Create756Aa
        //// Only for development purposes
        //public IActionResult Create756Aa()
        //{
        //    ViewData["MovieModelId"] = new SelectList(_context.Movies, "MovieModelId", "Name");
        //    ViewData["TheaterModelId"] = new SelectList(_context.Theaters, "TheaterModelId", "Name");
        //    return View();
        //}

        //// POST: Viewing/Create756Aa
        //// Only for development purposes
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create756Aa([Bind("ViewingModelId,StartTime,AvaibleSeats,TotalSeats,TheaterModelId,MovieModelId")] ViewingModel viewingModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(viewingModel);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["MovieModelId"] = new SelectList(_context.Movies, "MovieModelId", "Category", viewingModel.MovieModelId);
        //    ViewData["TheaterModelId"] = new SelectList(_context.Theaters, "TheaterModelId", "Name", viewingModel.TheaterModelId);
        //    return View(viewingModel);
        //}

        //// GET: Viewing/Delete756Aa/5
        //// Only for development purposes
        //public async Task<IActionResult> Delete756Aa(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var viewingModel = await _context.Viewings
        //        .Include(v => v.Movie)
        //        .Include(v => v.Theater)
        //        .FirstOrDefaultAsync(m => m.ViewingModelId == id);
        //    if (viewingModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(viewingModel);
        //}

        //// POST: Viewing/Delete756Aa/5
        //// Only for development purposes
        //[HttpPost, ActionName("Delete756Aa")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed756Aa(int id)
        //{
        //    var viewingModel = await _context.Viewings.FindAsync(id);
        //    _context.Viewings.Remove(viewingModel);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

    }
}
