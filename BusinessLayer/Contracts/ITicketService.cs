using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Contracts
{
    public interface ITicketService
    {
        List<TicketModel> GetAllTickets();
        int AddTicketModel(TicketModel ticket);
        bool DeleteTicketById(TicketModel ticket);
        bool UpdateTicket(TicketModel ticket);
        List<TicketModel> GetAllTicketsPerShow(int showId);
    }
}
