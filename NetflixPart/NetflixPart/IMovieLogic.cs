using System.Collections.Generic;

namespace NetflixPart
{
    public interface IMovieLogic
    {
        void SetupCollection(IList<Movie> movies);
        void GenerateMovies();
    }
}