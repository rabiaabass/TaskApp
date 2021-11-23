using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskApp.Models;

namespace TaskApp.Repositories
{
    public class TicketRepository
    {

        private readonly ApplicationDbContext _db;

        public TicketRepository()
        {
            _db = new ApplicationDbContext();
        }

        public void Add(Ticket ticket)
        {
            _db.Tickets.Add(ticket);
            _db.SaveChanges();
        }

        public Ticket Find(int ticketTypes)
        {
            return _db.Tickets.Find(ticketTypes);
        }

        public List<Ticket> List()
        {
            return _db.Tickets.ToList();
        }


    }
}
