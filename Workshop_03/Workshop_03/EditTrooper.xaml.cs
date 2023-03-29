using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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
            BindingExpression binding = tb_name.GetBindingExpression(TextBox.TextProperty);
            BindingExpression binding1 = tb_power.GetBindingExpression(TextBox.TextProperty);
            BindingExpression binding2 = tb_vitality.GetBindingExpression(TextBox.TextProperty);
            BindingExpression binding3 = tb_value.GetBindingExpression(TextBox.TextProperty);
            binding.UpdateSource();
            binding1.UpdateSource();
            binding2.UpdateSource();
            binding3.UpdateSource();
            this.Close();
        }
        private void Window_Closing(object sender, CancelEventArgs e)
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
