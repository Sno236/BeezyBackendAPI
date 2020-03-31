using System;
using System.Collections.Generic;
using System.Text;
using BeezyBackend.Service.Interfaces;
using BeezyBackend.Repository.Data;
using BeezyBackend.Data.Entitites;
using System.Linq;

namespace BeezyBackend.Service
{
    public class MoviesService : IMoviesService
    {
        private readonly DataContext _context;
        public MoviesService(DataContext context)
        {
            _context = context;
        }
        #region Variables        

        private string _genreConnectionKey = "genreApi";
        private string _moviePageConnectionKey = "moviePagewiseApi";

        #endregion

        #region Methods

        /// <summary>
        /// Calculates the total count of movies as per weeks and returns a billboard
        /// </summary>
        /// <param name="smallScreens"></param>
        /// <param name="bigScreens"></param>
        /// <param name="noOfWeeks"></param>
        /// <param name="autoSuggestions"></param>
        /// <returns></returns>
        public List<SmartBillboard> GetMoviesBasedonRooms(int smallScreens, int bigScreens, int noOfWeeks, bool autoSuggestions)
        {
            int totalSmallScreens = smallScreens * noOfWeeks;
            int totalBigScreens = bigScreens * noOfWeeks;

            var lstAllMovies = GetAllMovies(totalBigScreens);

            var lstPopularMovies = FilterMoviesByPopularity(lstAllMovies, totalBigScreens);
            var lstMinorityGenres = GetAllGenresAndFilterByMinority(lstAllMovies, totalSmallScreens);

            return GenerateBillBoard(lstPopularMovies, lstMinorityGenres, autoSuggestions);
        }

        /// <summary>
        /// Gets the  set of  movies
        /// </summary>
        /// <param name="noOfMovies"></param>
        /// <returns></returns>
        public List<MovieDetails> GetAllMovies(int noOfMovies)
        {
            try
            {
                List<MovieDetails> lstAllMovies = new List<MovieDetails>();
                int pageId = 1;

                while (lstAllMovies.Count < noOfMovies)
                {
                    var output = CallApi(_moviePageConnectionKey, pageId);
                    lstAllMovies.AddRange(output.results.Select(x => new MovieDetails
                    {
                        popularity = x.popularity,
                        vote_count = x.vote_count,
                        video = x.video,
                        poster_path = x.poster_path,
                        id = x.id,
                        adult = x.adult,
                        backdrop_path = x.backdrop_path,
                        original_language = x.original_language,
                        original_title = x.original_title,
                        genre_ids = x.genre_ids,
                        title = x.title,
                        vote_average = x.vote_average,
                        overview = x.overview,
                        release_date = x.release_date
                    }));
                    pageId++;
                }

                return lstAllMovies;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Minority is set in the enum.Filters as per enum and returns list
        /// </summary>
        /// <param name="lstAllMovies"></param>
        /// <param name="noOfMovies"></param>
        /// <returns></returns>
        public List<MovieDetails> GetAllGenresAndFilterByMinority(List<MovieDetails> lstAllMovies, int noOfMovies)
        {
            var genreList = ExternalAPIService.GetSpecifiedListFromMovieWebAPI<GenreDBJson>(_genreConnectionKey, 0);

            List<MovieDetails> minorityGenres = new List<MovieDetails>();
            minorityGenres.AddRange(lstAllMovies.Where(x => x.genre_ids.Contains((int)MinorityGenre.Documentary)
                                || x.genre_ids.Contains((int)MinorityGenre.Fantasy)
                                || x.genre_ids.Contains((int)MinorityGenre.History)
                                || x.genre_ids.Contains((int)MinorityGenre.Music)
                                || x.genre_ids.Contains((int)MinorityGenre.ScienceFiction)
                                || x.genre_ids.Contains((int)MinorityGenre.War))
                .Select(x => new MovieDetails
                {
                    popularity = x.popularity,
                    vote_count = x.vote_count,
                    video = x.video,
                    poster_path = x.poster_path,
                    id = x.id,
                    adult = x.adult,
                    backdrop_path = x.backdrop_path,
                    original_language = x.original_language,
                    original_title = x.original_title,
                    genre_ids = x.genre_ids,
                    title = x.title,
                    vote_average = x.vote_average,
                    overview = x.overview,
                    release_date = x.release_date
                }));

            return minorityGenres.Take(noOfMovies).ToList();
        }

        /// <summary>
        /// async call to external Movie Db api API 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="pageId"></param>
        /// <returns></returns>
        private MovieDBAPI CallApi(string connection, int pageId)
        {
            return ExternalAPIService.GetSpecifiedListFromMovieWebAPI<MovieDBAPI>(connection, pageId).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Sorts as per popularity rating
        /// </summary>
        /// <param name="lstAllMovies"></param>
        /// <param name="noOfMovies"></param>
        /// <returns></returns>
        private List<MovieDetails> FilterMoviesByPopularity(List<MovieDetails> lstAllMovies, int noOfMovies)
        {
            return lstAllMovies.OrderByDescending(x => x.popularity).Take(noOfMovies).ToList();
        }

        /// <summary>
        /// Genrates final billboard for theatre managers
        /// </summary>
        /// <param name="lstMovie"></param>
        /// <param name="lstMinority"></param>
        /// <returns></returns>
        private List<SmartBillboard> GenerateBillBoard(List<MovieDetails> lstMovie, List<MovieDetails> lstMinority, bool autoSuggestions)
        {
            List<SmartBillboard> lstSmart = new List<SmartBillboard>();

            lstSmart.AddRange(lstMovie.Select(x => new SmartBillboard { Title = x.title, Type = "Blockbuster", Room = "Big", SeatsSold = "N/A" }));
            lstSmart.AddRange(lstMinority.Select(x => new SmartBillboard { Title = x.title, Type = "Minority", Room = "Small", SeatsSold = "N/A" }));

            if (autoSuggestions)
            {
                var lstSuggestion = GetSuccessfulMoviesInCity();
                lstSmart.AddRange(lstSuggestion);
            }
            return lstSmart;
        }

        /// <summary>
        /// Call if user needs recommendation additionally on top of entered filter criteria
        /// </summary>
        /// <returns></returns>
        public List<SmartBillboard> GetSuccessfulMoviesInCity()
        {
            var temp = (from s in _context.Session
                        join r in _context.Room on s.RoomId equals r.Id
                        join m in _context.Movie on s.MovieId equals m.Id
                        select new
                        {
                            r.Size,
                            m.OriginalTitle,
                            s.SeatsSold
                        }).ToList();

            var suggestedList = (from t in temp
                                 group t by new { t.OriginalTitle, t.Size } into g
                                 select new SmartBillboard
                                 {
                                     Title = g.Key.OriginalTitle,
                                     Room = g.Key.Size,
                                     Type = "Suggestion",
                                     SeatsSold = (from v in g select v.SeatsSold).Max().ToString()
                                 }).ToList();
            return suggestedList;
        }


        #endregion
    }
}
