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
    public class CreateTicketModel : PageModel
    {

        private readonly CustomerRepository cRepo;
        private readonly TicketRepository tRepo;
        private readonly TicketServices tService;
        private readonly SendMailService sMailService;

        public CreateTicketModel(TicketRepository ticketRepository, TicketServices ticketServices, CustomerRepository customerRepository, SendMailService sendMailService)
        {
            tRepo = ticketRepository;
            tService = ticketServices;
            cRepo = customerRepository;
            sMailService = sendMailService;
        }

        [BindProperty]
        public Ticket TicketInput { get; set; }

        public List<SelectListItem> SelectListItem { get; private set; } = new List<SelectListItem>();

        [BindProperty]
        public Employee EmployeeInput { get; set; }


        public void OnGet()
        {
            var Customers = cRepo.List();

            SelectListItem = Customers.Select(a => new SelectListItem { Value = a.ID,
            Text = a.Name }).ToList();
        }

        public void OnPostSave()
        {
            if (ModelState.IsValid)
            {
                TicketInput.OpenDate = DateTime.Now;
                TicketInput.TicketType = TicketType.OpenTicket;

                tService.OpenTicket(TicketInput);



                

                var result = tRepo.Find(TicketInput.ID);

                if (result != null)
                {
                    ViewData["Message"] = "Kayýt Baþarýlý";

                  // sMailService.SendEmail(from: "bassrabiaa@gmail.com", to: , message: $"{TicketInput.ID}", subject: "Ticket ID");

                }
                else
                {
                    ViewData["Message"] = "Tekrar Dene";
                }
            }
        }
    }
}
