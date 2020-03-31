using System;
using System.Collections.Generic;
using System.Text;
using BeezyBackend.Service.Interfaces;
using BeezyBackend.Repository.Data;
using System.Linq;

namespace BeezyBackend.Service
{
    public class MoviesService : IMoviesService
    {
        #region Variables
        private string _movieConnectionKey = "movieApi";
        private string _genreConnectionKey = "genreApi";
        private string _genrePageConnectionKey = "genrePagewiseApi";
        private int _smallScreen = 0;
        private int _bigScreen = 0;
        private int _noOfWeeks = 0;        
        private bool _autoSuggestions;
        #endregion
        public List<IntelligentBillboard> GetMoviesBasedonRooms(int smallScreens, int bigScreens, int noOfWeeks, bool autoSuggestions)
        {
            _smallScreen = smallScreens;
            _bigScreen = bigScreens;
            _noOfWeeks = noOfWeeks;
            _autoSuggestions = autoSuggestions;

             //per day same small  big screens
            return new List<IntelligentBillboard>();
        }

        public void GetMovies(int noOfMovies)
        {
            List<string> lstAllMovies = new List<string>();
            int pageId = 1;

            //var initialLoad = CallApi(_movieConnectionKey);
            //pageCount = initialLoad.total_pages;



            while (lstAllMovies.Count  < noOfMovies)
            {
                //    string urlParams = GetUrlParameters(popularityOrder, page, filteredGenres);
                //    DiscoveredMovies movies = APICallHelper.RunAsync<DiscoveredMovies>(BaseUrl, urlParams.ToString()).GetAwaiter().GetResult();
                //    if (movies.TotalResults < numOfMovies)
                //        throw new Exception("There aren't enough movies in the database.");
                var output = CallApi(_genrePageConnectionKey, pageId);
                //lstAllMovies.AddRange(output.results);

            }

            
        }

        private MovieDBJson CallApi(string connection,int pageId)
        {
            return ExternalAPIService.GetSpecifiedListFromMovieWebAPI<MovieDBJson>(connection, pageId).GetAwaiter().GetResult();
        }
        public void GetAllGenres()
        {
            var genreList = ExternalAPIService.GetSpecifiedListFromMovieWebAPI<GenreDBJson>(_genreConnectionKey,0);
        }



        public void SortBlockbusterGenresForBigRoom()
        {
            throw new NotImplementedException();
        }

        public void SortMinorityGenresForSmallRoom()
        {
            throw new NotImplementedException();
        }
    }
}
