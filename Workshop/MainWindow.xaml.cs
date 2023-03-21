using System;
using System.Collections.Generic;
using System.IO;
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

namespace GUI02EnglishWords
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<Word> words = File.ReadAllLines("words.txt")
                .Select(t => new Word(t.Split(':')[1], t.Split(':')[0])).ToList();

            words.ForEach(t =>
            {
                Label l = new Label();
                l.Tag = t;
                l.Background = Brushes.LightBlue;
                l.Margin = new Thickness(20);
                l.Width = this.ActualWidth / 6;
                l.Height = this.ActualHeight / 6;
                wrap.Children.Add(l);

                l.MouseLeftButtonDown += L_MouseLeftButtonDown;
            });
        }

        private void L_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Label l = (sender as Label);
            Word w = (Word)(l.Tag);

            WordCheckWindow wcw = new WordCheckWindow(w);
            if (wcw.ShowDialog() == true)
            {
                l.Background = Brushes.LightGreen;
                l.IsEnabled = false;
            }
            else
            {
                l.Background = Brushes.LightPink;
                l.IsEnabled = false;
            }
        }
    }

    public class Word
    {
        private string english;
        private string hungarian;

        public Word(string english, string hungarian)
        {
            this.English = english;
            this.Hungarian = hungarian;
        }

        public string English { get => english; set => english = value; }
        public string Hungarian { get => hungarian; set => hungarian = value; }
    }
}
