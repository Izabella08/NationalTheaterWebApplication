using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public class ShowEntity
    {
        public int Id { get; set; }
        public string Genre { get; set; }
        public string Title { get; set; }
        public string DistributionList { get; set; }
        public DateTime DateOfTheShow { get; set; }
        public int NrOfTicketsPerShow { get; set; }
        public int nrOfSoldTickets { get; set; }
    }
}
