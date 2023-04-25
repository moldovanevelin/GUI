using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NetflixPart
{
    /// <summary>
    /// Interaction logic for MovieDataWindow.xaml
    /// </summary>
    public partial class MovieDataWindow : Window
    {
        public MovieDataWindow(Movie movie)
        {
            InitializeComponent();
            var vm = new MovieDataWindowViewModel();
            vm.Setup(movie);
            this.DataContext = vm;
        }
    }
}
