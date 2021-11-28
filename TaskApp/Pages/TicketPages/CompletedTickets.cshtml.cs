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
    public class CompletedTicketsModel : PageModel
    {

        private readonly CustomerRepository cRepo;
        private readonly TicketRepository tRepo;
        private readonly TicketServices tService;

        [BindProperty]
        public List<Ticket> CompletedTickets { get; set; }

        public CompletedTicketsModel(TicketRepository ticketRepository, TicketServices ticketServices, CustomerRepository customerRepository)
        {
            tRepo = ticketRepository;
            tService = ticketServices;
            cRepo = customerRepository;
            CompletedTickets = new List<Ticket>();
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
                if (item.TicketType == TicketType.CompletedTicket)
                {
                    CompletedTickets.Add(item);
                }
            }
        }


    }
}
