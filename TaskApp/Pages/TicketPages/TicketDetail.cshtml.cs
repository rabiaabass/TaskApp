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
        public DifficultyLevel  difficultyLevel { get; set; }

        [BindProperty]
        public Rank rank { get; set; }

        /// <summary>
        /// Open ticketlarýn listelendiði sayfada  herhangi bir open ticket ýn detail sayfasýna gitmek için butona basýldýðýnda o ticketýn id sini kullanarak OnGet methodu içinde Find ile o ticketý bulup, ticketin customer id sine ulaþtýk.
        /// </summary>
        /// <param name="id"></param>
        public void OnGet(string id)
        {
            ID = id;

            TicketInput = tRepo.Find(id);
            CustomerID = TicketInput.CustomerID.ToString();
            //CustomerName = cRepo.Find(ID).ToString();

     
        }

        /// <summary>
        /// Zorluk derecesi seçildikten sonra ticketý güncelleme iþlemi yapýldý.
        /// </summary>
        public void OnPostSetDifficultLevel() {

            if (ModelState.IsValid)
            {
                TicketInput.DifficultyLevel = difficultyLevel;
                tService.UpdateRankAndDiffcultLevel(TicketInput);
            }
            
        }

        /// <summary>
        /// Rank seçildikten sonra ticketý güncelleme iþlemi yapýldý.
        /// </summary>
        public void OnPostSetRank()
        {
            if (ModelState.IsValid)
            {
                TicketInput.Rank = rank;
                tService.UpdateRankAndDiffcultLevel(TicketInput);
            }

        }
    }
}
