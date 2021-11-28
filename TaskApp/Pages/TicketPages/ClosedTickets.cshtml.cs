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
    
    public class ClosedTicketsModel : PageModel
    {
        private readonly CustomerRepository cRepo;
        private readonly TicketRepository tRepo;
        private readonly TicketServices tService;

        [BindProperty]
        public List<Ticket> ClosedTickets { get; set; }
        public ClosedTicketsModel(TicketRepository ticketRepository, TicketServices ticketServices, CustomerRepository customerRepository)
        {
            tRepo = ticketRepository;
            tService = ticketServices;
            cRepo = customerRepository;
            ClosedTickets = new List<Ticket>();

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
                if (item.TicketType == TicketType.ClosedTicket)
                {
                    ClosedTickets.Add(item);
                }
            }
        }

        public void OnPostComplete()
        {
            if (ModelState.IsValid)
            {
                TicketInput.CompletedDate = DateTime.Now;
                TicketInput.TicketType = TicketType.CompletedTicket;

                tRepo.Update(TicketInput);
            }

        }


        public void OnPostReview()
        {
            if (ModelState.IsValid)
            {
                TicketInput.ReviewDate = DateTime.Now;
                TicketInput.TicketType = TicketType.ReviewTicket;

                tRepo.Update(TicketInput);
            }

        }
    }
}
