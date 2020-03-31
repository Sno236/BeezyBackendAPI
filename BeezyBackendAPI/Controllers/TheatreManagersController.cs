using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BeezyBackend.Web.Models;
using BeezyBackend.Service.Interfaces;

namespace BeezyBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheatreManagersController : ControllerBase
    {
        private readonly IMoviesService _movieService;
        
        public TheatreManagersController(IMoviesService movieService)
        {
            _movieService = movieService;
        }
        
        [HttpGet("GetUpcomingMovies")]
        public async Task<ActionResult<IEnumerable<CommonRecommendationProperties>>> GetUpcomingMovies(int ageRate,string genre, DateTime futureDate,bool autoSuggestions)
        {
            throw new NotImplementedException("Functionality not implemented");            
        }

        [HttpGet("GetTheatreBillboard")]
        public async Task<ActionResult<IEnumerable<CommonRecommendationProperties>>> GetTheatreBillboard(int noOfScreens, DateTime futureDate, bool autoSuggestions)
        {
            throw new NotImplementedException("Functionality not implemented");
        }

        [HttpGet("GetIntelligentBillboard")]
        public async Task<ActionResult<IEnumerable<object>>> GetIntelligentBillboard(int smallScreens, int bigScreens, int noOfWeeks, bool autoSuggestions)
        {
            return _movieService.GetMoviesBasedonRooms(smallScreens, bigScreens,  noOfWeeks, autoSuggestions);
        }
    }
}

