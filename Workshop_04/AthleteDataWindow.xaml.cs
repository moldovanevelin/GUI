﻿using System;
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
using SZTGUI_GYAK04.Models;
using SZTGUI_GYAK04.ViewModels;
using static SZTGUI_GYAK04.AthleteDataWindow;

namespace SZTGUI_GYAK04
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AthleteDataWindow : Window
    {
        public AthleteDataWindow(Athlete athlete)
        {
            InitializeComponent();
            var vm = new AthleteDataWindowViewModel();
            vm.Setup(athlete);
            this.DataContext = vm;
        }  
    }
}
