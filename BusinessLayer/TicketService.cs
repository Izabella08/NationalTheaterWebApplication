using BusinessLayer.Contracts;
using DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository repository;
        private readonly IShowRepository showRepository;


        public TicketService(ITicketRepository repository, IShowRepository showRepository)
        {
            this.repository = repository;
            this.showRepository = showRepository;
        }


        public int AddTicketModel(TicketModel ticket)
        {
            ShowEntity show = showRepository.GetShowById(ticket.Show.Id);
            int nr = show.nrOfSoldTickets;
            if(nr == show.NrOfTicketsPerShow)
            {
                return -1;
            }
            else
            {
                show.nrOfSoldTickets++;
                repository.Add(new TicketEntity { SeatRow = ticket.SeatRow, SeatNumber = ticket.SeatNumber, Show = show });
                return show.NrOfTicketsPerShow - show.nrOfSoldTickets;
            }
        }


        public List<TicketModel> GetAllTickets()
        {
            List<TicketModel> result = new List<TicketModel>();
            var getTickets = repository.GetAll().ToList();
            foreach (var ticket in getTickets)
            {
                var x = showRepository.GetAllShows().Where(y => y.Id == ticket.Show.Id).FirstOrDefault();
                ShowModel getShow = new ShowModel { Id = x.Id, Genre = x.Genre, Title = x.Title, DistributionList = x.DistributionList, DateOfTheShow = x.DateOfTheShow, NrOfTicketsPerShow = x.NrOfTicketsPerShow, nrOfSoldTickets = x.nrOfSoldTickets };
                result.Add(new TicketModel { Id = ticket.Id, SeatRow = ticket.SeatRow, SeatNumber = ticket.SeatNumber, Show = getShow });
            }
            return result;
        }


        public bool DeleteTicketById(TicketModel ticket)
        {
            ShowEntity show = showRepository.GetShowById(ticket.Show.Id);
            try
            {
                var DataList = repository.GetAll().Where(x => x.Id == ticket.Id).ToList();
                foreach (var item in DataList)
                {
                    repository.DeleteTicketById(item);
                    show.nrOfSoldTickets--;
                    showRepository.UpdateShow(show);
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }


        public bool UpdateTicket(TicketModel ticket)
        {
            try
            {
                var item = repository.GetAll().Where(x => x.Id == ticket.Id).FirstOrDefault();
                item.SeatRow = ticket.SeatRow;
                item.SeatNumber = ticket.SeatNumber;
                repository.UpdateTicket(item);
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }


        public List<TicketModel> GetAllTicketsPerShow(int showId)
        {
            List<TicketModel> result = new List<TicketModel>();
            var show = showRepository.GetAllShows().Where(x => x.Id == showId).FirstOrDefault();
            foreach(var t in repository.GetAll())
            {
                ShowModel showModel = new ShowModel { Id = show.Id, Genre = show.Genre, Title = show.Title, DistributionList = show.DistributionList, DateOfTheShow = show.DateOfTheShow, NrOfTicketsPerShow = show.NrOfTicketsPerShow, nrOfSoldTickets = show.nrOfSoldTickets };
                if(t.Show.Id == showId)
                {
                    result.Add(new TicketModel { SeatRow = t.SeatRow, SeatNumber = t.SeatNumber, Show = showModel });
                }

            }
            return result;
        }
    }
}
