using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NetflixPart
{
    public class MovieLogic : IMovieLogic
    {
        IList<Movie> movies;
        IList<Movie> selectedMovies;
        IMovieDataService movieData;
        int movieCount;
        int lengthSum;
        public MovieLogic(IMovieDataService movieData)
        {
            this.movieData = movieData;
        }
        public void SetupCollection(IList<Movie> movies, IList<Movie> selectedMovies, int movieCount, int lengthSum)
        {
            this.movieCount = movieCount;
            this.lengthSum = lengthSum;
            this.movies = movies;
            this.selectedMovies = selectedMovies;
        }
        public void GenerateMovies()
        {
            movies.Add(new Movie() { Title = "Harry Potter and the Philosopher's Stone", Director = "Chris Columbus", Length = 152, NumberOfPlay = 12340, Rate = 4.1 });
            movies.Add(new Movie() { Title = "Memento", Director = "Christopher Nolan", Length = 113, NumberOfPlay = 21450, Rate = 4.8 });
            movies.Add(new Movie() { Title = "Old", Director = "M. Night Shyamalan", Length = 108, NumberOfPlay = 9880, Rate = 2.8 });
            movies.Add(new Movie() { Title = "The Godfather", Director = "Francis Ford Coppola", Length = 175, NumberOfPlay = 114560, Rate = 5 });
            movies.Add(new Movie() { Title = "The Truman Show", Director = "Chris Columbus", Length = 103, NumberOfPlay = 17840, Rate = 4.6 });            
        }
        public void Add(Movie item)
        {
            if (!selectedMovies.Contains(item))
            {
                movieCount += 1;
                lengthSum += item.Length;
                selectedMovies.Add(item);                              
            }
        }
        public void ShowMovieData(Movie movie)
        {
            movieData.ShowData(movie);
        }
    }
}
