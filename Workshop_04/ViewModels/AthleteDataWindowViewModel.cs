using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZTGUI_GYAK04.ViewModels
{
    public class AthleteDataWindowViewModel
    {
        public Athlete Actual { get; set; }

        public void Setup(Athlete athlete)
        {
            this.Actual = athlete;
        }


        public AthleteDataWindowViewModel()
        {

        }
    }
}
