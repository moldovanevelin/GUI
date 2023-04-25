using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NetflixPart
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public ObservableCollection<Movie> Movies { get; set; }
        private Movie selectedFromMovies;
        public Movie SelectedFromMovies
        {
            get { return selectedFromMovies; }
            set
            {
                SetProperty(ref selectedFromMovies, value);
            }
        }
        public ICommand LoadCommand { get; set; }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public MainWindowViewModel()
       : this(IsInDesignMode ? null : Ioc.Default.GetService<IMovieLogic>())
        {

        }
        public MainWindowViewModel(IMovieLogic logic)
        {
            Movies = new ObservableCollection<Movie>();
            logic.SetupCollection(Movies);
            LoadCommand = new RelayCommand(
                ()=> logic.GenerateMovies(),
                ()=> SelectedFromMovies == null
                );
        }
        
    }
}
