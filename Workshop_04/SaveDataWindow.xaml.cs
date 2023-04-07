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
using SZTGUI_GYAK04.Logic;

namespace SZTGUI_GYAK04
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class SaveDataWindow : Window
    {       
        public SaveDataWindow()
        {
            InitializeComponent();            
        }

        private void Button_save_Click(object sender, RoutedEventArgs e)
        {
            JsonFileName.Name = tb_userInput.Text;
            this.Close();
        }
    }
}
