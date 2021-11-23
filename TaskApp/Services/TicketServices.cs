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

        public void AddTicket(Ticket ticket)
        {
            if (true)
            {

            }
        }
    }
}
