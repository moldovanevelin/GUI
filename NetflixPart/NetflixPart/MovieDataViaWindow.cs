using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixPart
{
    public class MovieDataViaWindow : IMovieDataService
    {
        public void ShowData(Movie movie)
        {
            new MovieDataWindow(movie).ShowDialog();
        }
    }
}
