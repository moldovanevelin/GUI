using System;
using System.Collections.Generic;
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
using System.Windows.Threading;


namespace Workshop_03
{
    /// <summary>
    /// Interaction logic for WordCheckWindow.xaml
    /// </summary>
    public partial class EditTrooper : Window
    {
        private Soldier s;
        public EditTrooper(Soldier s)
        {
            InitializeComponent();
            this.s = s;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            b_save.Background = Brushes.Blue;
            if (tb_name.Text != null && tb_power.Text != null && tb_vitality.Text != null && tb_value.Text != null)
            {
                s.Type = tb_name.Text;
                s.Power = int.Parse(tb_power.Text);
                s.Vitality = int.Parse(tb_vitality.Text);
                s.Value = int.Parse(tb_value.Text);
                this.Close();
            }
        }
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (tb_name.Text != null && tb_power.Text != null && tb_vitality.Text != null && tb_value.Text != null && b_save.Background == Brushes.Blue)
            {
                MessageBoxResult result = MessageBox.Show("Do you want to save changes?", "Exit", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Do you want to close the window?", "Exit", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
