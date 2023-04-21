using System;
using System.Collections.Generic;
using System.Collections.Immutable;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Workshop_05.Model;

namespace Workshop_05.WPFClient
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
        private void ShowEmojiTabButton_Click(object sender, RoutedEventArgs e)
        {          
            ScrollViewer.Visibility= Visibility.Visible;
            tabControl.Visibility = Visibility.Visible;
            
        }
        private void EmojiButton_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;            
            tb_message.Text += clickedButton.Content.ToString();
            BindingExpression binding = tb_message.GetBindingExpression(TextBox.TextProperty);
            binding.UpdateSource();
            tabControl.Visibility = Visibility.Collapsed;
            ScrollViewer.Visibility = Visibility.Collapsed;
        }

        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedTab = tabControl.SelectedItem as TabItem;            
            var selectedButton = selectedTab.Content as Button;
            tb_message.Foreground = selectedButton.Foreground;            
        }
    }
}
