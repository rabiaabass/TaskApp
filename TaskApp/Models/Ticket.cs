using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskApp.Models
{

    public enum TicketType
    {
        OpenTicket = 1,
        ClosedTicket = 2,
        AssignedTicket = 3,
        ReviewTicket = 4,
        CompletedTicket = 5
    }
    public class Ticket
    {
        public string ID { get; set; } = Guid.NewGuid().ToString();

        [Required(ErrorMessage = "Subject alanı boş geçilemez")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Description alanı boş geçilemez")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Customer alanı boş geçilemez")]
        public Customer Customer { get; set; }

        public Employee Employee { get; set; }

        public DateTime OpenDate { get; set; }

        public DateTime ClosedDate { get; set; }

        public DateTime AssignedDate { get; set; }

        public DateTime ReviewDate { get; set; }

        public DateTime CompletedDate { get; set; }

        public string DifficultyLevel { get; set; }

        public int Rank { get; set; }

        public TicketType TicketType { get; set; }








    }
}
