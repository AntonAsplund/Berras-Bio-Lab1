﻿using Berras_Bio_Lab1.Models;
using Berras_Bio_Lab1.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

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
            var berrasBioDbContext = _context.Tickets
                .Include(t => t.Viewing);

            return View(await berrasBioDbContext.ToListAsync());
        }

        public async Task<IActionResult> OrderTicket(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewingModel = await _context.Viewings
                .Include(v => v.Theater)
                .Include(v => v.Movie)
                .FirstOrDefaultAsync(v => v.ViewingModelId == id);

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
        public async Task<IActionResult> OrderTicket(TicketModel ticket)
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

            var viewing = await _context.Viewings
                .Where(v => v.ViewingModelId == ticket.ViewingModelId)
                .Include(v => v.Movie).Include(v => v.Theater)
                .FirstOrDefaultAsync();

            //Failsafe handling if a customer enters invalid number of tickets, or no firstname or phonenumber
            
            if (ticket.NumberOfViewingTickets <= 0 || ticket.PhoneNumber == null || ticket.PhoneNumber == "" || ticket.PersonName == null || ticket.PersonName == "" || ticket.NumberOfViewingTickets > 12)
            {
                return View(ticket);
            }

            if (viewing.AvaibleSeats - ticket.NumberOfViewingTickets < 0)
            {

                TempData["TicketLimitation"] = "Not enough seats are avaible";
                return View(ticket);
            }

            viewing.AvaibleSeats -= ticket.NumberOfViewingTickets;
            await _context.SaveChangesAsync();

            ticket.Viewing = viewing;


            ticket.OrderDateTime = DateTime.Now;
            await _context.SaveChangesAsync();

            return RedirectToAction("OrderTicketValidation", ticket);
        }

        public async Task<IActionResult> OrderTicketValidation(TicketModel ticket)
        {
            ticket.Viewing = await _context.Viewings
                .Where(v => v.ViewingModelId == ticket.ViewingModelId)
                .Include(v => v.Movie).Include(v => v.Theater)
                .FirstOrDefaultAsync();

            return View(ticket);
        }

        //[HttpPost]
        //public async Task<IActionResult> OrderTicketValidation(TicketModel ticket)
        //{


        //    var ticketsInBooking = ticket.NumberOfViewingTickets;
        //    var nameInBooking = ticket.PersonName;
        //    var phoneNumberInBooking = ticket.PhoneNumber;

        //    if (ticket == null)
        //    {
        //        return NotFound();
        //    }

        //    ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.TicketModelId == ticket.TicketModelId);
        //    ticket.NumberOfViewingTickets = ticketsInBooking;
        //    ticket.PersonName = nameInBooking;
        //    ticket.PhoneNumber = phoneNumberInBooking;

        //    var viewing = await _context.Viewings
        //        .Where(v => v.ViewingModelId == ticket.ViewingModelId)
        //        .Include(v => v.Movie).Include(v => v.Theater)
        //        .FirstOrDefaultAsync();

        //    //Failsafe handling if a customer enters invalid number of tickets, or no firstname or phonenumber
        //    if (viewing.AvaibleSeats - ticket.NumberOfViewingTickets < 0)
        //    {

        //        TempData["TicketLimitation"] = "Not enough seats are avaible";
        //        return Redirect($"OrderTicket/{viewing.ViewingModelId}");
        //    }

        //    if (ticket.NumberOfViewingTickets > 12)
        //    {

        //        TempData["TicketLimitation"] = "No more than 12 tickets are allowed per person";
        //        return Redirect($"OrderTicket/{viewing.ViewingModelId}");
        //    }

        //    if (ticket.NumberOfViewingTickets <= 0)
        //    {
        //        return Redirect($"OrderTicket/{viewing.ViewingModelId}");
        //    }

        //    if (ticket.PersonName == null || ticket.PersonName == "")
        //    {
        //        TempData["TicketLimitation"] = "A name must be entered";
        //        return Redirect($"OrderTicket/{viewing.ViewingModelId}");
        //    }

        //    if (ticket.PhoneNumber == null || ticket.PhoneNumber == "")
        //    {
        //        TempData["TicketLimitation"] = "A phonenumber must be entered";
        //        return Redirect($"OrderTicket/{viewing.ViewingModelId}");
        //    }

        //    viewing.AvaibleSeats -= ticket.NumberOfViewingTickets;
        //    await _context.SaveChangesAsync();

        //    ticket.Viewing = viewing;


        //    ticket.OrderDateTime = DateTime.UtcNow;
        //    await _context.SaveChangesAsync();

        //    return View({ticket});
        //}
    }
}
