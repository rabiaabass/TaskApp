using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskApp.Models;
using TaskApp.Repositories;
using TaskApp.Services;

namespace TaskApp.Pages.TicketPages
{
    public class ReviewedTicketsModel : PageModel
    {
        private readonly CustomerRepository cRepo;
        private readonly TicketRepository tRepo;
        private readonly TicketServices tService;

        [BindProperty]
        public List<Ticket> ReviewedTickets { get; set; }

        public ReviewedTicketsModel(TicketRepository ticketRepository, TicketServices ticketServices, CustomerRepository customerRepository)
        {
            tRepo = ticketRepository;
            tService = ticketServices;
            cRepo = customerRepository;
            ReviewedTickets = new List<Ticket>();
        }

        [BindProperty]
        public List<Ticket> Tickets { get; set; }

        [BindProperty]
        public Ticket TicketInput { get; set; }
        public void OnGet()
        {
            Tickets = tRepo.List();

            foreach (var item in Tickets)
            {
                if (item.TicketType == TicketType.ReviewTicket)
                {
                    ReviewedTickets.Add(item);
                }
            }
        }

        public void OnPostClose()
        {
            if (ModelState.IsValid)
            {
                TicketInput.ClosedDate = DateTime.Now;
                TicketInput.TicketType = TicketType.ClosedTicket;

                tRepo.Update(TicketInput);
            }
        }

    }
}
