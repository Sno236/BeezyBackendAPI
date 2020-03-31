using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BeezyBackend.Web.Models;
using BeezyBackend.Service.Interfaces;
using BeezyBackend.Repository.Data;

namespace BeezyBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheatreManagersController : ControllerBase
    {
        private readonly IMoviesService _movieService;
        private readonly DataContext _context;
        public TheatreManagersController(IMoviesService movieService,DataContext context)
        {
            _context = context;
            _movieService = movieService;
        }
        
        [HttpGet("GetUpcomingMovies")]
        public async Task<ActionResult<IEnumerable<CommonRecommendationProperties>>> GetUpcomingMovies(int ageRate,string genre, DateTime futureDate)
        {
            throw new NotImplementedException("Functionality not implemented");            
        }

        [HttpGet("GetTheatreBillboard")]
        public async Task<ActionResult<IEnumerable<CommonRecommendationProperties>>> GetTheatreBillboard(int noOfScreens, DateTime futureDate)
        {
            throw new NotImplementedException("Functionality not implemented");
        }

        [HttpGet("GetIntelligentBillboard")]
        public async Task<ActionResult<IEnumerable<object>>> GetIntelligentBillboard(int smallScreens, int bigScreens, int noOfWeeks, bool otherRecomendations)
        {
            return _movieService.GetMoviesBasedonRooms(smallScreens, bigScreens,  noOfWeeks, otherRecomendations);
        }
    }
}

