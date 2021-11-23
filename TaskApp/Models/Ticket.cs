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


        /// <summary>
        /// Girilen Subjectin karakter kontrolü için yazıldı.
        /// </summary>
        /// <param name="subject"></param>
        public void SetSubject(string subject)
        {
            if (subject.Length > 50)
            {
                throw new Exception("50 karakterden fazla bir subject giremezsiniz. ");
            }

            this.Subject = subject;
        }

        /// <summary>
        /// Girilen Description un karakter kontrolü için yazıldı. 
        /// </summary>
        /// <param name="description"></param>
        public void SetDescription(string description)
        {
            if (description.Length > 500)
            {
                throw new Exception("500 karakterden fazla bir description giremezsiniz");
            }

            this.Description = description;
        }









    }
}
