using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Speech.Recognition;
using System.Speech.Recognition.SrgsGrammar;
using System.Net;
using System.Text.RegularExpressions;
using System.Timers;
using System.Data;
using System.Windows.Threading;
using System.Media;
using Organizer.Classes;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data.Entity;

namespace Organizer
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    /// 

    public partial class UserControl1 : UserControl

    {
        DispatcherTimer timer_alarm = new DispatcherTimer();

        public UserControl1() 
        {
            InitializeComponent();
            DataContext = new AlarmVM(this);
            FillBoxes();
            DispatcherTimer timer_counter = new DispatcherTimer();
            timer_counter.Interval = new TimeSpan(0, 0, 1);
            timer_counter.Tick += new EventHandler(counter_tick);
            timer_counter.Start();
            timer_alarm.Interval = new TimeSpan(0, 0, 1);
            timer_alarm.Tick += new EventHandler(alarm_tick);

            timer_alarm.Start();



        }
        private void counter_tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;

            TimeNow.Text = now.ToString("HH:mm:ss");
        }

        private void alarm_tick(object sender, EventArgs e)
        {

            if (AlarmVM.Alarmso != null)
            {
                foreach (AlarmClock al in AlarmVM.Alarmso)
                {

                    bool check = false;
                    DateTime now = DateTime.Now;
                    if ((al.Time.ToString() == now.ToString("HH:mm:ss")) && al.Alarm_Check)
                    {
                        al.Alarm_Check = false;
                        AlarmSignal a = new AlarmSignal();
                        a.Show();
                        check = true;
                    }

                    if (check)
                        timer_alarm.Stop();
                }
            }
        }
        
        private void FillBoxes()
        {
            Hours.Items.Add("00");
            for (int i = 1; i <= 23; i++)
            {
                if (i <= 9)
                    Hours.Items.Add("0" + i);
                else
                    Hours.Items.Add(i);
            }

            Minuts.Items.Add("00");

            for (int i = 1; i <= 59; i++)
            {
                if (i <= 9)
                    Minuts.Items.Add("0" + i);
                else
                    Minuts.Items.Add(i);
            }

        }
        
    }
}
