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
        //private readonly beezycinemaContext _context;
        //private readonly IMapper _mapper;
        //public ViewersController(beezycinemaContext context,IMapper mapper)
        //{
        //    _context = context;
        //    _mapper = mapper;
        //}
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
        //[HttpGet("[action]/{keywords}/{genres}/{timePeriod}")]
        [HttpGet("GetMovies")]
        public ActionResult<IEnumerable<CommonRecommendationProperties>> GetMovies(string keywords,string genres,DateTime timePeriod)
        {
            throw new NotImplementedException("Functionality not implemented");
            //var movie = _mapper.Map<IEnumerable<MovieViewModel>>(_context.Movie);
            //return movie.ToList();
        }


        [HttpGet("GetTVShows")]
        public async Task<ActionResult<IEnumerable<TVShowRecommendationProperties>>> GetTVShows(string keywords, string genres)
        {
            throw new NotImplementedException("Functionality not implemented");
            //var movie = _mapper.Map<IEnumerable<MovieViewModel>>(_context.Movie);
            //return movie.ToList();
        }


        [HttpGet("GetDocumentaries")]
        public async Task<ActionResult<IEnumerable<TVShowRecommendationProperties>>> GetDocumentaries(string topic)
        {
            throw new NotImplementedException("Functionality not implemented");
            //var movie = _mapper.Map<IEnumerable<MovieViewModel>>(_context.Movie);
            //return movie.ToList();
        }

        //POST : api/commands
        //[HttpPost]
        //public ActionResult<City> PostCommandItem(City city)
        //{
        //    _context.City.Add(city);
        //    _context.SaveChanges();
        //    return CreatedAtAction("GetCommandItem", new City { Id = city.Id,Name = city.Name,Population = city.Population},city);
        //}

        //PUT : api/commands/n
        //[HttpPut]
        //public ActionResult PutCommandItem(int Id,City city)
        //{
        //    if(Id !=  city.Id)
        //    {
        //        return BadRequest();
        //    }
        //    _context.Entry(city).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //    _context.SaveChanges();
        //    return NoContent();
        //}

        //DELETE : api/commands/n
        //[HttpDelete("{id}")]
        //public ActionResult<City> DeleteCommandItem(int id)
        //{
        //    var commandItem = _context.City.Find(id);
        //    if (commandItem == null)
        //    {
        //        return NotFound();
        //    }
        //    _context.City.Remove(commandItem);
        //    _context.SaveChanges();
        //    return commandItem;
        //}

    }
}

