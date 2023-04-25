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

        public void Setup(Movie athlete)
        {
            this.Actual = athlete;
        }
        public MovieDataWindowViewModel()
        {

        }
    }
}
