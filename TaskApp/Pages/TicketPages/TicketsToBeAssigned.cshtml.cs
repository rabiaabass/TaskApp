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
    public class TicketsToBeAssignedModel : PageModel
    {

        private readonly CustomerRepository cRepo;
        private readonly EmployeeRepository eRepo;
        private readonly TicketRepository tRepo;
        private readonly TicketServices tService;

        [BindProperty]
        public List<Ticket> ToBeAssigned { get; set; }
        public TicketsToBeAssignedModel(TicketRepository ticketRepository, TicketServices ticketServices, CustomerRepository customerRepository, EmployeeRepository employeeRepository)
        {
            tRepo = ticketRepository;
            tService = ticketServices;
            cRepo = customerRepository;
            eRepo = employeeRepository;
            ToBeAssigned = new List<Ticket>();
        }

        [BindProperty]
        public List<Ticket> Tickets { get; set; }

        [BindProperty]
        public Ticket TicketInput { get; set; }

        public List<SelectListItem> SelectListItem { get; private set; } = new List<SelectListItem>();

        public void OnGet()
        {
            // Employees tablosundaki datalardan ID ve Name i çektik
            var Employees = eRepo.List();

            SelectListItem = Employees.Select(a => new SelectListItem
            {
                Value = a.ID,
                Text = a.Name
            }).ToList();


            //Tickets lar içinde dönüp zorluk derecesi ve rank seviyesi belirlenmiþ olan open ticketlarý ToBeAssigned listesine atýyor.
            Tickets = tRepo.List();

            foreach (var item in Tickets)
            {
                if (item.TicketType == TicketType.OpenTicket && item.DifficultyLevel != null && item.Rank != null)
                {
                    ToBeAssigned.Add(item);
                }
            }
        }

        public void OnPostSave()
        {
            if (ModelState.IsValid)
            {
                TicketInput.AssignedDate = DateTime.Now;
                TicketInput.TicketType = TicketType.AssignedTicket;

                tService.UdateAsignedTckets(TicketInput);
            }
        }
    }
}
