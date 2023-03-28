using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Workshop_03
{
    public class Soldier: INotifyPropertyChanged
    {
        private string type;
        private int power;
        private int vitality;
        private int value;
        private int cost;
        private static int _totalCost;
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName="")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler !=null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public string Type { get { return type; } set { type = value; OnPropertyChanged(); } }
        public int Power { get { return power; } set { power = value; OnPropertyChanged(); } }
        public int Vitality { get { return vitality; } set { vitality = value; OnPropertyChanged(); } }
        public int Value { get { return value; } set { this.value = value; OnPropertyChanged(); } }
        public int Cost { get { return power*vitality*this.value; } set { cost = value; OnPropertyChanged(); } }
        public int TotalCost { get { return _totalCost; } set { _totalCost = value; OnPropertyChanged(); } }
    }
}
