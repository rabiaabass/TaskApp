using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskApp.Models;
using TaskApp.Repositories;

namespace TaskApp.Services
{
    public class TicketServices
    {
        TicketRepository _ticketRepository;

        public TicketServices(TicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public void OpenTicket(Ticket ticket)
        {
            if (ticket.Subject == null)
            {
                throw new Exception("Subject alanı boş geçilemez.");
            }

            if (ticket.Subject.Length > 50)
            {
                throw new Exception("50 karakterden fazla bir subject giremezsiniz");
            }

            if (ticket.Description == null)
            {
                throw new Exception("Description alanı boş geçilemez.");
            }

            if (ticket.Description.Length > 500)
            {
                throw new Exception("500 karakterden fazla bir description giremezsiniz");
            }

            _ticketRepository.Add(ticket);
        }

        public void UpdateRankAndDiffcultLevel(Ticket ticket)
        {
            _ticketRepository.Update(ticket);
        }
       
        public void UdateAsignedTckets(Ticket ticket)
        {
            _ticketRepository.Update(ticket);
        }


    }
}
