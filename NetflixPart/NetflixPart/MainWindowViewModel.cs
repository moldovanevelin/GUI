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
        IMovieLogic logic;
        public ObservableCollection<Movie> Movies { get; set; }
        public ObservableCollection<Movie> SelectedMovies { get; set; }

        private Movie selectedFromMovies;
        public Movie SelectedFromMovies
        {
            get { return selectedFromMovies; }
            set
            {
                SetProperty(ref selectedFromMovies, value);
                (AddCommand as RelayCommand).NotifyCanExecuteChanged();
                (ShowCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }
        public ICommand LoadCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand ShowCommand { get; set; }
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
            this.logic = logic;
            Movies = new ObservableCollection<Movie>();
            SelectedMovies = new ObservableCollection<Movie>();
            logic.SetupCollection(Movies, SelectedMovies);
            AddCommand = new RelayCommand(
                () => logic.Add(SelectedFromMovies),
                () => SelectedFromMovies != null
                );
            LoadCommand = new RelayCommand(
                ()=> logic.GenerateMovies(),
                ()=> SelectedFromMovies == null
                );
            ShowCommand = new RelayCommand(
                () => new MovieDataWindow(SelectedFromMovies).ShowDialog(),
                () => SelectedFromMovies != null
                );
            
        }
        
    }
}
