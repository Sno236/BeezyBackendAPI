using BeezyBackend.Repository.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeezyBackend.Service.Interfaces
{
    [Flags]
    public enum MinorityGenre
    {        
        Music = 10402,
        Fantasy = 14,
        History = 36,
        War = 10752,
        Documentary = 99,
        ScienceFiction = 878
    }
    public interface IMoviesService
    {
        List<SmartBillboard> GetMoviesBasedonRooms(int smallScreens, int bigScreens, int noOfWeeks, bool autoSuggestions);

        List<MovieDetails> GetAllMovies(int noOfMovies);

        List<MovieDetails> GetAllGenresAndFilterByMinority(List<MovieDetails> lstAllMovies,int noOfMovies);

        List<SmartBillboard> GetSuccessfulMoviesInCity();
    }
}
