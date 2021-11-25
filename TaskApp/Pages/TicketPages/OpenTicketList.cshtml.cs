using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaskApp.Models;
using TaskApp.Repositories;
using TaskApp.Services;

namespace TaskApp.Pages.TicketPages
{
    public class OpenTicketListModel : PageModel
    {
        private readonly CustomerRepository cRepo;
        private readonly TicketRepository tRepo;
        private readonly TicketServices tService;

        [BindProperty]
        public List<Ticket> OpenTickets { get; set; }

        public OpenTicketListModel(TicketRepository ticketRepository, TicketServices ticketServices, CustomerRepository customerRepository)
        {
            tRepo = ticketRepository;
            tService = ticketServices;
            cRepo = customerRepository;
            OpenTickets = new List<Ticket>();
        }

        

        [BindProperty]
        public Ticket Ticket { get; set; }       

        [BindProperty]
        public List<Ticket> Tickets { get; set; }

        public void OnGet()
        {
            Tickets = tRepo.List();

            foreach (var item in Tickets)
            {
                if (item.TicketType == TicketType.OpenTicket)
                {
                    OpenTickets.Add(item);
                }
            }



        }
    }
}
