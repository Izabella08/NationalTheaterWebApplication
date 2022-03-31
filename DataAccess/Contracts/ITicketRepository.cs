using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface ITicketRepository
    {
        List<TicketEntity> GetAll();
        void Add(TicketEntity ticket);
        void DeleteTicketById(TicketEntity ticket);
        void UpdateTicket(TicketEntity ticket);
        TicketEntity GetTicketById(int Id);
        List<TicketEntity> GetAllTicketsPerShow(int ShowId);

    }
}
