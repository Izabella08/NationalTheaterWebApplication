using BusinessLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Factory
{
    public class WriteXML : IWriter
    {
        private readonly ITicketService ticketService;

        public WriteXML(ITicketService ticketService)
        {
            this.ticketService = ticketService;
        }
        public void ExportTickets(int showID)
        {
            var result = new List<TicketModel>();
            foreach (var s in ticketService.GetAllTickets())
            {
                if (s.Show.Id == showID)
                {

                }
            }
        }
    }
}
