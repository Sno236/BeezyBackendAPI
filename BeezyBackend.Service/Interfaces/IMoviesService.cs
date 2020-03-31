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
        List<IntelligentBillboard> GetMoviesBasedonRooms(int smallScreens, int bigScreens, int noOfWeeks, bool autoSuggestions);
        void SortBlockbusterGenresForBigRoom();
        void SortMinorityGenresForSmallRoom();

        void GetAllMovies();
        void GetAllGenres();


    }
}
