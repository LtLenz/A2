using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Organizer.Classes
{
    public class Alarm_clock 
    {
        public string hour { get; set; }

        public string minute { get; set; }

        public Alarm_clock(string hour, string minute)
                {
                    this.hour = hour;
                    this.minute = minute;
                }

        //public event PropertyChangedEventHandler PropertyChanged;

        //public void OnPropertyChanged([CallerMemberName]string prop = "")
        //{
        //    if (PropertyChanged != null)
        //        PropertyChanged(this, new PropertyChangedEventArgs(prop));
        //}
    }
}
