using DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class TicketRepository : ITicketRepository
    {
        private readonly TheaterDbContext theaterDbContext;
        public TicketRepository(TheaterDbContext theaterDbContext)
        {
            this.theaterDbContext = theaterDbContext;
        }
        public void Add(TicketEntity ticket)
        {
            theaterDbContext.Add(ticket);
            theaterDbContext.SaveChanges();
        }

        public List<TicketEntity> GetAll()
        {
            return theaterDbContext.TicketEntities.ToList();
        }

        public void DeleteTicketById(TicketEntity ticket)
        {
            theaterDbContext.Remove(ticket);
            theaterDbContext.SaveChanges();
        }
        public void UpdateTicket(TicketEntity ticket)
        {
            theaterDbContext.TicketEntities.Update(ticket);
            theaterDbContext.SaveChanges();
        }

        public TicketEntity GetTicketById(int Id)
        {
            return theaterDbContext.TicketEntities.Where(x => x.Id == Id).FirstOrDefault();
        }

        public List<TicketEntity> GetAllTicketsPerShow(int ShowId)
        {
            return theaterDbContext.TicketEntities.ToList();
        }
    }
}
