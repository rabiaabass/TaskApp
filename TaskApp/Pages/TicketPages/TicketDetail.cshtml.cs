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
    public class TicketDetailModel : PageModel
    {
        private readonly CustomerRepository cRepo;
        private readonly TicketRepository tRepo;
        private readonly TicketServices tService;

        public TicketDetailModel(TicketRepository ticketRepository, TicketServices ticketServices, CustomerRepository customerRepository)
        {
            tRepo = ticketRepository;
            tService = ticketServices;
            cRepo = customerRepository;

        }

        public Ticket TicketInput { get; set; } = new Ticket();

        [BindProperty]
        public string CustomerID { get; set; }

        [BindProperty]
        public string CustomerName { get; set; }

        [BindProperty]
        public string ID { get; set; }

        [BindProperty]
        public DifficultyLevel  DifficultlyLevel { get; set; }

        [BindProperty]
        public List<Ticket> Rank { get; set; }

        public void OnGet(string id)
        {
            ID = id;

            TicketInput = tRepo.Find(id);
            CustomerID = TicketInput.CustomerID.ToString();
            //CustomerName = cRepo.Find(ID).ToString();

            

            


        }
        public void OnPostSetDifficultLevel() {

        }
    }
}
