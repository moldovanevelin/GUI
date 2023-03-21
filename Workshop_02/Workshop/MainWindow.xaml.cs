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
using Workshop02;

namespace Workshop02
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
            List<Quiz> quiz = File.ReadAllLines("quiz.txt")
                .Select(t => new Quiz(t.Split(':')[0], t.Split(':')[2], t.Split(':')[1].Split(",").ToList())).ToList();

            quiz.ForEach(t => {
                Label l = new Label();
                l.Tag = t;
                l.Background = Brushes.LightBlue;
                l.FontSize = 32;
                l.Content = "?";
                l.VerticalContentAlignment = VerticalAlignment.Center;
                l.HorizontalContentAlignment = HorizontalAlignment.Center;
                l.Margin = new Thickness(20);
                l.Width = this.ActualWidth / 6;
                l.Height = this.ActualHeight / 6;     
                wrap.Children.Add(l);
            });
            
        }

        private void L_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source is Label)
            {
                Label l = e.Source as Label;
                Quiz q = (Quiz)(l.Tag);

                AnswerCheckWindow acw = new AnswerCheckWindow(q);
                if (acw.ShowDialog() == true)
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
    }

    public class Quiz
    {
        private string question;
        private string rightAnswer;
        private List<string> answers;

        public Quiz(string question, string rightAnswer, List<string> answers)
        {
            this.question = question;
            this.rightAnswer = rightAnswer;
            this.answers = answers;
        }
        public string Question { get => question; set => question = value; }
        public List<string> Answers { get => answers; set => answers = value; }
        public string RightAnswer { get => rightAnswer; set => rightAnswer=value; }
    }
}
