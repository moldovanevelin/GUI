using System.Collections.Generic;

namespace NetflixPart
{
    public interface IMovieLogic
    {
        void SetupCollection(IList<Movie> movies, IList<Movie> selectedMovies, int movieCount, int lengthSum);
        void GenerateMovies();
        void Add(Movie item);
        void ShowMovieData(Movie movie);
    }
}