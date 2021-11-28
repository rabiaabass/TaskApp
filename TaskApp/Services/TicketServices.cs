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
        EmployeeRepository _employeeRepository;

        public TicketServices(TicketRepository ticketRepository, EmployeeRepository employeeRepository)
        {
            _ticketRepository = ticketRepository;
            _employeeRepository = employeeRepository;
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

        public void UpdateRank(Ticket ticket, Rank rank )
        {
            ticket.Rank = rank;   
            _ticketRepository.Update(ticket);
        }

        public void UpdateDifficultyLevel(Ticket ticket, DifficultyLevel difficultyLevel)
        {
            ticket.DifficultyLevel = difficultyLevel;
            _ticketRepository.Update(ticket);
        }

        public void UdateAsignedTckets(Ticket ticket)
        {
            
            _ticketRepository.Update(ticket);
        }

        public void SetWorkHours(Employee employee, Ticket ticket)
        {

            int workhour;

            if ((int)ticket.Rank == 5)
            {
                workhour = 8 * 5;
            }

            if ((int)ticket.Rank == 4)
            {
                workhour = 8 * 4;
            }
            if ((int)ticket.Rank == 3)
            {
                workhour = 8 * 3;
            }
            if ((int)ticket.Rank == 2)
            {
                workhour = 8 * 2;
            }
            if ((int)ticket.Rank == 1)
            {
                workhour = 8 * 1;
            }

            workhour = employee.WorkHours;

            _employeeRepository.Update(employee);


        }

        public void UpdateTicketEmployeeID(Ticket ticket, string id)
        {
            ticket.EmployeeID = id;
            _ticketRepository.Update(ticket);

        }


    }
}
