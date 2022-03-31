using BusinessLayer.Contracts;
using BusinessLayer.Factory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayersOnWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService ticketService;
  

        public TicketController(ITicketService ticketService)
        {
            this.ticketService = ticketService;

        }


        [HttpGet("GetAllTickets")]
        [Authorize(Roles = "Cashier, Admin")]
        public IEnumerable<Ticket> Get()
        {
            var result = new List<Ticket>();
            foreach (var t in ticketService.GetAllTickets())
            {
                result.Add(new Ticket { SeatRow = t.SeatRow, SeatNumber = t.SeatNumber, Show = t.Show });
            }
            return result;
        }


        [HttpPost("SellTicket")]
        [Authorize(Roles = "Cashier")]
        public String Post(Ticket t)
        {
            int newTicket = ticketService.AddTicketModel(new TicketModel { SeatRow = t.SeatRow, SeatNumber = t.SeatNumber, Show = t.Show });
            if (newTicket == -1)
            {
                return "There are no more tickets for this show!";
            }
            return "Ticket added successfully!";
        }


        [HttpDelete("CancelReservation")]
        [Authorize(Roles = "Cashier")]
        public bool DeleteTicketById(TicketModel ticket)
        {
            try
            {
                ticketService.DeleteTicketById(ticket);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        [HttpPut("EditReservation")]
        [Authorize(Roles = "Cashier")]
        public bool UpdateTicket(TicketModel ticket)
        {
            try
            {
                ticketService.UpdateTicket(ticket);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        [HttpGet("SeeSoldTicketsForAShow")]
        [Authorize(Roles = "Cashier, Admin")]
        public IEnumerable<Ticket> SeeSoldTicketsForAShow(int ShowId)
        {
            var result = new List<Ticket>();
            foreach (var t in ticketService.GetAllTicketsPerShow(ShowId))
            {
                if(t.Show.Id == ShowId)
                {
                    result.Add(new Ticket { SeatRow = t.SeatRow, SeatNumber = t.SeatNumber, Show = t.Show });
                }
            }
            return result;
        }


        [HttpPost("ExportTickets")]
        [Authorize(Roles = "Admin")]
        public String Export(int id)
        {
            try
            {
                ConcreteCreator c = new ConcreteCreator(ticketService);
                c.getWriter().ExportTickets(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetBaseException().ToString());
                return ex.GetBaseException().ToString();
            }
            return "Tickets exported successfully!";

        }
    }
}
