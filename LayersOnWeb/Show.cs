using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayersOnWeb
{
    public class Show
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
