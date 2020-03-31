using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BeezyBackend.Web.Models;
using BeezyBackend.Service.Interfaces;
using AutoMapper;


namespace BeezyBackendAPI.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class ViewersController : ControllerBase
    {
        private readonly IMoviesService _movieService;
        private readonly ITVShowService _tvshowService;
        private readonly IDocumentaryService _docService;
        public ViewersController(IMoviesService movieService,ITVShowService tvshowService,IDocumentaryService docService)
        {
            _movieService = movieService;
            _tvshowService = tvshowService;
            _docService = docService;
        }

        //GET : api/commands        
        [HttpGet("GetMovies")]
        public ActionResult<IEnumerable<CommonRecommendationProperties>> GetMovies(string keywords,string genres,DateTime timePeriod)
        {
            throw new NotImplementedException("Functionality not implemented");            
        }


        [HttpGet("GetTVShows")]
        public async Task<ActionResult<IEnumerable<TVShowRecommendationProperties>>> GetTVShows(string keywords, string genres)
        {
            throw new NotImplementedException("Functionality not implemented");
        }


        [HttpGet("GetDocumentaries")]
        public async Task<ActionResult<IEnumerable<TVShowRecommendationProperties>>> GetDocumentaries(string topic)
        {
            throw new NotImplementedException("Functionality not implemented");
        }     

    }
}

