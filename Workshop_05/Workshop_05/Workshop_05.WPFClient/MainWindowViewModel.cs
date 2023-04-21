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
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Numerics;
using System.Windows.Data;
using Microsoft.AspNetCore.SignalR;
using System.Windows.Controls;
using System.Reflection;

namespace Workshop_05.WPFClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public RestCollection<Message> Messages { get { return new RestCollection<Message>("http://localhost:15880/", "message", "hub"); } set { OnPropertyChanged(); } }       
       
        private Message newMessage;
        public Message NewMessage
        {
            get { return newMessage; }
            set
            {
                if (value != null)
                {
                    newMessage = new Message()
                    {
                        Text = value.Text
                    };
                    OnPropertyChanged();                   
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
                Messages = new RestCollection<Message>("http://localhost:15880/", "message", "hub")
                        {
                            new Message() { Text = "Welcome to the chat Window! It was a pain in the 4ss to make it, so appreciate it!😨" },
                        };
                NewMessage = new Message();
                SendCommand = new RelayCommand(() =>
                {
                    if (newMessage!=null && NewMessage.Text!=string.Empty)
                    {                        
                        Messages = new RestCollection<Message>("http://localhost:15880/", "message", "hub")
                        {
                            new Message() { Sender="Me:", Text = NewMessage.Text },                         
                        };
                        OnPropertyChanged(nameof(Messages));
                    }
                    NewMessage = new Message() { Text = string.Empty };
                });               
            }
            
        }

    }
}
