using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZTGUI_GYAK04
{
    public class Athlete: ObservableObject
    {
        private string name;
        private int record;
        private int recordThisYear;
        private bool permission;
        private string association;
        private string comp_num;
        private int actual_Value;
       
        public string Name { get => name; set => SetProperty(ref name, value); }
        public int Record { get => record; set => SetProperty(ref record, value); }
        public int RecordThisYear { get => recordThisYear; set => SetProperty(ref recordThisYear, value); }
        public bool Permission { get => permission; set => SetProperty(ref permission, value); }
        public string Association { get => association; set => SetProperty(ref association, value); }
        public string Comp_num { get => comp_num; set => SetProperty(ref comp_num, value); }
        public int Actual_Value { get => record*recordThisYear; set => SetProperty(ref actual_Value, value); }

        public Athlete GetCopy()
        {
            return new Athlete()
            {
                Name = this.Name,
                Record = this.Record,
                RecordThisYear = this.RecordThisYear,
                Permission = this.Permission,
                Association = this.Association,
                Comp_num = this.Comp_num,
                Actual_Value = this.Actual_Value
            };
        }
    }
}
