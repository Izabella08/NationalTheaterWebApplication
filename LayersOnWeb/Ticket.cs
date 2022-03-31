using BusinessLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayersOnWeb
{
    public class Ticket
    {
        public int SeatRow { get; set; }
        public int SeatNumber { get; set; }
        public ShowModel Show { get; set; }

    }
}
