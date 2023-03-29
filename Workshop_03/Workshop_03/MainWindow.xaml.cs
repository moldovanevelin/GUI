using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Media;

namespace Workshop_03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Soldier> army;
        public ObservableCollection<Soldier> army_choosen;
       
        public MainWindow()
        {
            InitializeComponent();
            army = new ObservableCollection<Soldier>() { };
            army.Add(new Soldier() { Type = "marine", Power = 6, Vitality = 8, Value = 7 });
            army.Add(new Soldier() { Type = "pilot", Power = 7, Vitality = 6, Value = 9 });
            army.Add(new Soldier() { Type = "sniper", Power = 10, Vitality = 5, Value = 10 });
            army.Add(new Soldier() { Type = "engineer", Power = 8, Vitality = 4, Value = 3 });
            army.Add(new Soldier() { Type = "veteran", Power = 5, Vitality = 5, Value = 2 });
            lbox_left.ItemsSource = army;
            SoundPlayer player = new SoundPlayer(@".\Media .wav");
            player.Play();
        }
        private void b_add_Click(object sender, RoutedEventArgs e)
        {
           if (lbox_left.SelectedItem!=null && lbox_left.SelectedItem is Soldier s)
           {
                lb_right.Items.Add(new string($"{s.Type} {s.Power} {s.Vitality} {s.Value}"));                
                s.TotalCost += s.Cost;
           }
           if (lbox_left.SelectedItem == null)
           {
               MessageBox.Show("Choose a soldier!");
           }
            lb_right.ItemsSource = army_choosen;
        }

        private void b_remove_Click(object sender, RoutedEventArgs e)
        {
            if (lbox_left.SelectedItem != null && lbox_left.SelectedItem is Soldier s && lb_right.Items.Contains(($"{s.Type} {s.Power} {s.Vitality} {s.Value}")))
            { 
                lb_right.Items.Remove(new string($"{s.Type} {s.Power} {s.Vitality} {s.Value}"));               
                s.TotalCost -= s.Cost;
            }
            if (lbox_left.SelectedItem == null)
            {
                MessageBox.Show("Choose a soldier!");
            }
            lb_right.ItemsSource = army_choosen;
        }

        private void b_edit_Click(object sender, RoutedEventArgs e)
        {
            if (lbox_left.SelectedItem != null && lbox_left.SelectedItem is Soldier s)
            {
                Soldier selectedTrooper = (Soldier)lbox_left.SelectedItem;
                EditTrooper et = new EditTrooper(s);
                et.DataContext = selectedTrooper;
                et.ShowDialog();
            }
        }
        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to close the window?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
                return;
            }
            else
            {
                e.Cancel = false;
            }
            
        }
    }
}
