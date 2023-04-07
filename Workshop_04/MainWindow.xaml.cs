using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SZTGUI_GYAK04.Logic;
using SZTGUI_GYAK04.Models;
using SZTGUI_GYAK04.ViewModels;

namespace SZTGUI_GYAK04
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {       
        public MainWindow()
        {
            InitializeComponent();             
        }
        private void button5_Click(object sender, RoutedEventArgs e)
        {
            SaveDataWindow sw = new SaveDataWindow();
            sw.ShowDialog();
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://youtu.be/dQw4w9WgXcQ";
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            };
            Process.Start(psi);
        }
    }
}
