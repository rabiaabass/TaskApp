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
        /// Open ticketlar�n listelendi�i sayfada  herhangi bir open ticket �n detail sayfas�na gitmek i�in butona bas�ld���nda o ticket�n id sini kullanarak OnGet methodu i�inde Find ile o ticket� bulup, ticketin customer id sine ula�t�k.
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
        /// Zorluk derecesi se�ildikten sonra ticket� g�ncelleme i�lemi yap�ld�.
        /// </summary>
        public void OnPostSetDifficultLevel() {

            if (ModelState.IsValid)
            {
                TicketInput.DifficultyLevel = difficultyLevel;
                tService.UpdateDifficultyLevel(TicketInput,difficultyLevel);
                
            }
            
        }

        /// <summary>
        /// Rank se�ildikten sonra ticket� g�ncelleme i�lemi yap�ld�.
        /// </summary>
        public void OnPostSetRank()
        {
            if (ModelState.IsValid)
            {
                TicketInput.Rank = rank;
                tService.UpdateRank(TicketInput,rank);
            }

        }
    }
}
