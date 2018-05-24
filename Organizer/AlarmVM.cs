using System.Data.Entity;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using System.Linq;
using System.IO;
using System;
using Microsoft.Win32;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.IO.Ports;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace Organizer
{
    class AlarmVM : BaseViewModel
    {
        public int Id = 1;
        public string Alarm_Name { get; set; }
        public TimeSpan Time { get; set; }
        public bool Alarm_Check { get; set; }

        public string SelHour { get; set; }
        public string SelMin { get; set; }
        public string SelSec = ":00";

        string _pattern;

        private AlarmClock selectedalarm;
        public AlarmClock SelectedAlarm
        {
            get
            {


                return selectedalarm ;
            }

            set
            {
                Set(ref selectedalarm, value);
                OnPropertyChanged("SelectedAlarm");

            }
        }


        public AlarmContext database;


        public List<string> Hours = new List<string>();
        public List<string> Minuts = new List<string>();

        public static ObservableCollection<AlarmClock> Alarmso { get; set; }


        public ICommand AddNewAlarmCommand { get; set; }
        public ICommand RemoveAlarmCommand { get; set; }



        public AlarmVM(UserControl1 cont)
        {
            

            database = new AlarmContext();
            database.AlarmClocks.Load();

            if (Alarmso == null)
            {
                Alarmso = new ObservableCollection<AlarmClock>();
                Alarmso = database.AlarmClocks.Local;
            }




            AddNewAlarmCommand = new RelayCommand(AddNewAlarm);
            RemoveAlarmCommand = new RelayCommand(RemoveAlarm);
       
        }


        public void AddNewAlarm()
        {
            MessageBox.Show(SelHour + ":" + SelMin + SelSec);
            var alarm = new AlarmClock
            {
                Alarm_Name = Alarm_Name,
                Time = TimeSpan.Parse(SelHour + ":" + SelMin + SelSec),
                Alarm_Check = true
            };

            database.AlarmClocks.Add(alarm);
            database.SaveChanges();

            Alarmso.Add(alarm);
        }


        public void RemoveAlarm()
        {
            var alarm = database.AlarmClocks.FirstOrDefault(list => list.Alarm_Name == SelectedAlarm.Alarm_Name);

            database.AlarmClocks.Remove(alarm);
            database.SaveChanges();
        }

        public string Pattern
        {
            get => _pattern;
            set
            {
                Set(ref _pattern, value);
                SelectedAlarm = Alarmso.FirstOrDefault(s => s.Alarm_Name.StartsWith(Pattern));
            }


        }

        protected void Set<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
        public event PropertyChangedEventHandler PropertyChanged;


    }
}
