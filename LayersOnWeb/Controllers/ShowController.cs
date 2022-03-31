using BusinessLayer.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayersOnWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShowController : ControllerBase
    {
        private readonly IShowService showService;
        public ShowController(IShowService showService)
        {
            this.showService = showService;
        }


        [HttpGet("GetAllShows")]
        [Authorize]
        public IEnumerable<Show> Get()
        {
            var result = new List<Show>();
            foreach (var s in showService.GetAllShows())
            {
                result.Add(new Show { Id = s.Id, Genre = s.Genre, Title = s.Title, DistributionList = s.DistributionList, DateOfTheShow = s.DateOfTheShow, NrOfTicketsPerShow = s.NrOfTicketsPerShow, nrOfSoldTickets = s.nrOfSoldTickets });
            }
            return result;
        }


        [HttpPost("AddShow")]
        [Authorize(Roles = "Admin")]
        //[Auth]
        public void Post(Show s)
        {
            showService.AddShowModel(new ShowModel { Genre = s.Genre, Title = s.Title, DistributionList = s.DistributionList, DateOfTheShow = s.DateOfTheShow, NrOfTicketsPerShow = s.NrOfTicketsPerShow, nrOfSoldTickets = s.nrOfSoldTickets });
        }

 
        [HttpDelete("DeleteShowById")]
        [Authorize(Roles = "Admin")]
        public bool DeleteShowById(ShowModel show)
        {
            try
            {
                showService.DeleteShowById(show);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPut("UpdateShow")]
        [Authorize(Roles = "Admin")]
        public bool UpdateShow(ShowModel show)
        {
            try
            {
                showService.UpdateShow(show);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpGet("GetShowById")]
        [Authorize(Roles = "Admin")]
        public Object GetShowById(int Id)
        {
            try
            {
                var data = showService.GetShowById(Id);
                if (data == null) return NotFound();
                return data;
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
    }

    
}
