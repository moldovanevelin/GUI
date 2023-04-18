using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Workshop_05.Logic;
using Workshop_05.Models;
using Microsoft.Toolkit.Mvvm;
using Microsoft.Toolkit.Mvvm.Input;
using System.Configuration;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System.ComponentModel;
using System.Windows;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace Workshop_05.WPFClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        IChatLogic logic;
        public RestCollection<Message> Messages { get; set; }
        private string userInput;
        public string UserInput
        {
            get { return userInput; }
            set
            {
                SetProperty(ref userInput, value);
                (SendCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }
        public Message newMessage = new Message();        
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
        : this(IsInDesignMode ? null : Ioc.Default.GetService<IChatLogic>())
        {
            
        }
        public MainWindowViewModel(IChatLogic logic)
        {
            if (IsInDesignMode)
            {
            
                this.logic = logic;
                Messages = new RestCollection<Message>("http://localhost:15880/", "chat", "hub");
                newMessage.Text = UserInput;
                SendCommand = new RelayCommand(
                    () => logic.SendMessage(newMessage)                    
                    );
            
            }
        }
        
    }
}
