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
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SZTGUI_GYAK04.Logic;
using SZTGUI_GYAK04.Models;

namespace SZTGUI_GYAK04.ViewModels
{
    /// <summary>
    /// Interaction logic for MainWindowViewModel.xaml
    /// </summary>
    public class MainWindowViewModel : ObservableRecipient
    {
        IAthleteLogic logic;
        public ObservableCollection<Athlete> Athletes { get; set; }
        public ObservableCollection<Athlete> Competition { get; set; }
        private Athlete selectedFromAthletes;

        public Athlete SelectedFromAthletes
        {
            get { return selectedFromAthletes; }
            set
            {
                SetProperty(ref selectedFromAthletes, value);
                (AddToAthletesCommand as RelayCommand).NotifyCanExecuteChanged();
                (ShowCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

       
        private Athlete selectedFromCompetition;


        public Athlete SelectedFromCompetition
        {
            get { return selectedFromCompetition; }
            set
            {
                SetProperty(ref selectedFromCompetition, value);
                (RemoveFromAthletesCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }
        public ICommand AddToAthletesCommand { get; set; }
        public ICommand RemoveFromAthletesCommand { get; set; }
        public ICommand LoadCommand { get; set; }
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
        : this(IsInDesignMode ? null : Ioc.Default.GetService<IAthleteLogic>())
        {

        }
        public MainWindowViewModel(IAthleteLogic logic)
        {
            this.logic=logic;
            Athletes = new ObservableCollection<Athlete>();
            Competition = new ObservableCollection<Athlete>();            
            logic.SetupCollections(Athletes, Competition);
            AddToAthletesCommand = new RelayCommand(
               () => logic.AddToAthletes(SelectedFromAthletes),
               () => SelectedFromAthletes != null
               );

            RemoveFromAthletesCommand = new RelayCommand(
                () => logic.RemoveFromAthletes(SelectedFromCompetition),
                () => SelectedFromCompetition != null
                );
            LoadCommand = new RelayCommand(
               () => logic.Load(Athletes),
               ()=> SelectedFromAthletes == null
               );
            ShowCommand = new RelayCommand(
              () => logic.ShowAthleteData(SelectedFromAthletes),
              () => SelectedFromAthletes != null
              );
        }
    }
}
