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

namespace Workshop_05.WPFClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public RestCollection<Message> Messages { get; set; }       
        public List<Message> WindowMessages { get; set; }
        
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
                Messages = new RestCollection<Message>("http://localhost:15880/", "message", "hub");     
                WindowMessages = new List<Message>();
                WindowMessages.AddRange(Messages);
                NewMessage = new Message();
                SendCommand = new RelayCommand(() =>
                {
                    Messages.Add(new Message() { Text= NewMessage.Text });                    
                    WindowMessages.Add(new Message() { Text = NewMessage.Text });  
                    OnPropertyChanged(nameof(WindowMessages));
                    NewMessage = new Message() { Text = string.Empty };
                });                
            }
            
        }

    }
}
