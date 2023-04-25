using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixPart
{
    public class Movie
    {
        public string Title { get; set; }
        public int Length { get; set; }
        public string Director { get; set; }
        public int NumberOfPlay { get; set; }

        private double rate;
        public double Rate
        {
            get { return rate; }
            set
            {
                if (value >= 1 && value <= 5)
                {
                    rate = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Rate can only be a number between 1 and 5!");
                }
            }
        }
    }
}
