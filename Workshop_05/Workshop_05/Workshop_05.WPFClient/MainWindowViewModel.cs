using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm;
using Microsoft.Toolkit.Mvvm.Input;
using System.Configuration;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System.ComponentModel;
using System.Windows;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Workshop_05.Model;

namespace Workshop_05.WPFClient
{
    public class MainWindowViewModel : ObservableRecipient
    {        
        public RestCollection<Message> Messages { get; set; }
        
        private string userInput;
        public string UserInput
        {
            get { return userInput; }
            set
            {
                if (userInput != value)
                {
                    userInput = value;
                    OnPropertyChanged(nameof(UserInput));
                }
            }
        }
        public ICommand SendCommand { get; set; }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public MainWindowViewModel()
        {            
            if (!IsInDesignMode)
            {                
                Messages = new RestCollection<Message>("http://localhost:15880/", "message", "hub");                
                SendCommand = new RelayCommand(SendMessage);                
            }
            
        }
        private void SendMessage()
        {
            Messages.Add(new Message { Sender = "Me", Text = UserInput, Date = DateTime.Now });            
            UserInput = string.Empty;
        }

    }
}
