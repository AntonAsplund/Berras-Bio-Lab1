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
    public class TicketController : Controller
    {
        private readonly BerrasBioDbContext _context;

        public TicketController(BerrasBioDbContext context)
        {
            _context = context;
        }

        // GET: Ticket
        public async Task<IActionResult> Index()
        {
            var berrasBioDbContext = _context.Tickets.Include(t => t.Viewing);
            return View(await berrasBioDbContext.ToListAsync());
        }

        public async Task<IActionResult> OrderTicket(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewingModel = await _context.Viewings.Include(v => v.Theater).Include(v => v.Movie).FirstOrDefaultAsync(v => v.ViewingModelId == id);



            //Quickfix to be able to send a ticketmodel to view, personname and phonenumber is required //TO:DO fix call via attributes.

            var ticket = new TicketModel
            {
                Viewing = viewingModel,
                PersonName = "x",
                PhoneNumber = "x"
            };

            _context.Tickets.Add(ticket);
            _context.SaveChanges();

            ticket.PersonName = "";
            ticket.PhoneNumber = "";

            return View(ticket);
        }

        [HttpPost]
        public async Task<IActionResult> OrderTicketValidation(TicketModel ticket)
        {
            

            var ticketsInBooking = ticket.NumberOfViewingTickets;
            var nameInBooking = ticket.PersonName;
            var phoneNumberInBooking = ticket.PhoneNumber;

            if (ticket == null)
            {
                return NotFound();
            }

            ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.TicketModelId == ticket.TicketModelId);
            ticket.NumberOfViewingTickets = ticketsInBooking;
            ticket.PersonName = nameInBooking;
            ticket.PhoneNumber = phoneNumberInBooking;

            var viewing = await _context.Viewings.FirstOrDefaultAsync(v => v.ViewingModelId == ticket.ViewingModelId);


            if (viewing.AvaibleSeats - ticket.NumberOfViewingTickets < 0)
            {

                TempData["TicketLimitation"] = "Not enough seats are avaible";
                return Redirect($"OrderTicket/{viewing.ViewingModelId}");
            }

            if (ticket.NumberOfViewingTickets > 12)
            {

                TempData["TicketLimitation"] = "No more than 12 tickets are allowed per person";
                return Redirect($"OrderTicket/{viewing.ViewingModelId}");
            }

            if (ticket.NumberOfViewingTickets == 0)
            {
                return Redirect($"OrderTicket/{viewing.ViewingModelId}");
            }

            if (ticket.PersonName == null || ticket.PersonName == "")
            {
                TempData["TicketLimitation"] = "A name must be entered";
                return Redirect($"OrderTicket/{viewing.ViewingModelId}");
            }

            if (ticket.PhoneNumber == null || ticket.PhoneNumber == "")
            {
                TempData["TicketLimitation"] = "A phonenumber must be entered";
                return Redirect($"OrderTicket/{viewing.ViewingModelId}");
            }

            viewing.AvaibleSeats -= ticket.NumberOfViewingTickets;
            await _context.SaveChangesAsync();

            ticket.Viewing = viewing;

            ticket.Viewing.Movie = await _context.Movies.FirstOrDefaultAsync(m => m.MovieModelId == viewing.MovieModelId);
            ticket.Viewing.Theater = await _context.Theaters.FirstOrDefaultAsync(t => t.TheaterModelId == viewing.TheaterModelId);

            ticket.OrderDateTime = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return View(ticket);
        }
    }
}
