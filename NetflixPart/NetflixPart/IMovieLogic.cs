using System.Collections.Generic;

namespace NetflixPart
{
    public interface IMovieLogic
    {
        void SetupCollection(IList<Movie> movies, IList<Movie> selectedMovies);
        void GenerateMovies();
        void Add(Movie item);
    }
}