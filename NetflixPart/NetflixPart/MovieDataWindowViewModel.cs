using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixPart
{
    public class MovieDataWindowViewModel
    {
        public Movie Actual { get; set; }

        public void Setup(Movie movie)
        {
            this.Actual = movie;
        }
        public MovieDataWindowViewModel()
        {

        }
    }
}
