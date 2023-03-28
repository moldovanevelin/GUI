using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop_03
{
    public class Soldier
    {
        private string type;
        private int power;
        private int vitality;
        private int value;
        public Soldier(string type, int power, int vitality, int value)
        {
            this.type = type;
            this.power = power;
            this.vitality = vitality;
            this.value = value;
        }
        public string Type { get { return type; } set { type = value; } }
        public int Power { get { return power; } set { power = value; } }
        public int Vitality { get { return vitality; } set { vitality = value; } }
        public int Value { get { return value; } set { this.value = value; } }

    }
}
