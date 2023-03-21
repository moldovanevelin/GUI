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

namespace Workshop02
{
    /// <summary>
    /// Interaction logic for WordCheckWindow.xaml
    /// </summary>
    public partial class AnswerCheckWindow : Window
    {
        private Quiz q;
        private DispatcherTimer timer;
        private int timeLeft = 60;        
        public AnswerCheckWindow(Quiz q)
        {
            InitializeComponent();
            this.q = q;
            lb_question.Content = q.Question;
            cb_answers.ItemsSource = q.Answers;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timerLabel.Content=timeLeft.ToString();
            timer.Start();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            button.Background = Brushes.Blue;
            if (cb_answers.SelectedItem == null)
            {
                MessageBox.Show("Choose an answer!");
            }
            else if (cb_answers.SelectedItem.ToString() == q.RightAnswer.ToString())
            {
                this.DialogResult = true;               
            }            
            else
            {
                this.DialogResult = false;                
                timer.Stop();
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {            
            timeLeft--;
            timerLabel.Content=timeLeft.ToString();
            if(timeLeft<4)
            {
                timerLabel.Foreground = Brushes.Red;
            }
            if (timeLeft==0)
            {
                timerLabel.Foreground = Brushes.DarkRed;
                timerLabel.FontStyle = FontStyles.Oblique;
                timerLabel.Content = "Time's up!";
                timer.Stop();
            }
        }
        private void Window_Closing(object sender, CancelEventArgs e)
        {            
            if (cb_answers.SelectedItem != null && button.Background==Brushes.Blue)
            {
                Window w = new Window();
                w.Close();
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
