using BusinessLayer.Contracts;
using DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ShowService : IShowService
    {
        private readonly IShowRepository repository;

        public ShowService(IShowRepository repository)
        {
            this.repository = repository;
        }
        public void AddShowModel(ShowModel show)
        {
            repository.Add(new ShowEntity { Genre = show.Genre, Title = show.Title, DistributionList = show.DistributionList, DateOfTheShow = show.DateOfTheShow, NrOfTicketsPerShow = show.NrOfTicketsPerShow, nrOfSoldTickets = show.nrOfSoldTickets});
        }

        public List<ShowModel> GetAllShows()
        {
            List<ShowModel> result = new List<ShowModel>();
            foreach (var x in repository.GetAllShows())
            {
                result.Add(new ShowModel { Id = x.Id, Genre = x.Genre, Title = x.Title, DistributionList = x.DistributionList, DateOfTheShow = x.DateOfTheShow, NrOfTicketsPerShow = x.NrOfTicketsPerShow, nrOfSoldTickets = x.nrOfSoldTickets });
            }
            return result;
        }

        public bool DeleteShowById(ShowModel show)
        {
            try
            {
                var DataList = repository.GetAllShows().Where(x => x.Id == show.Id).ToList();
                foreach (var item in DataList)
                {
                    repository.DeleteShowById(item);
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public bool UpdateShow(ShowModel show)
        {
            try
            {
                var item = repository.GetAllShows().Where(x => x.Id == show.Id).FirstOrDefault();
                item.Genre = show.Genre;
                item.Title = show.Title;
                item.NrOfTicketsPerShow = show.NrOfTicketsPerShow;
                item.nrOfSoldTickets = show.nrOfSoldTickets;
                repository.UpdateShow(item);
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public ShowModel GetShowById(int Id)
        {
            ShowModel res = new ShowModel();
            var x = repository.GetShowById(Id);
            return new ShowModel{Id = x.Id, Genre = x.Genre, Title = x.Title, DistributionList = x.DistributionList, DateOfTheShow = x.DateOfTheShow, NrOfTicketsPerShow = x.NrOfTicketsPerShow, nrOfSoldTickets = x.nrOfSoldTickets };
        }
    }
}
