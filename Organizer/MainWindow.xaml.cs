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

namespace Organizer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ObservableCollection<Alarm_clock> clocks = new ObservableCollection<Alarm_clock>();
        public MainWindow()
        {
            InitializeComponent();

            FillBoxes();

            DispatcherTimer timer_counter = new DispatcherTimer();
            timer_counter.Interval = new TimeSpan(0, 0, 1);
            //timer_counter.Tick += new EventHandler(counter_tick);
            timer_counter.Start();

            clocks.CollectionChanged += Clock_CollectionChanged;

      

            
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;

            switch (index)
            {
                case 0:
                    GridBack.Children.Clear();
                    GridBack.Children.Add(new Start_page_clock());
                    break;
                case 1:
                    GridBack.Children.Clear();
                    GridBack.Children.Add(new UserControl1());
                    break;
                case 2:
                    GridBack.Children.Clear();
                    GridBack.Children.Add(new ContactsControl());
                    break;
                case 3:
                    GridBack.Children.Clear();
                    GridBack.Children.Add(new TextControl());
                    break;
                case 4:
                    MessageBox.Show(DateTime.Now.Day.ToString() + "." + DateTime.Now.Month.ToString());
                    break;
                default:
                    break;
            }
        }

    

        private void Alarm_button(object sender, RoutedEventArgs e)
        {
            
        }

        private void Note_button(object sender, RoutedEventArgs e)
        {
            Note note = new Note();
            note.Show();
        }

        
        private void Contacts_Click(object sender, RoutedEventArgs e)
        {
            //Contact a = new Contact();
            //a.Show();
        }

     

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

       
        


        private void Alarm_start_Click(object sender, RoutedEventArgs e)
        {
            DispatcherTimer timer_alarm = new DispatcherTimer();
            timer_alarm.Interval = new TimeSpan(0, 0, 1);
            timer_alarm.Tick += new EventHandler(alarm_tick);
            timer_alarm.Start();
            //Alarm_clock alarm = new Alarm_clock(Hours.SelectedItem.ToString(), Minutes.SelectedItem.ToString());
            //clocks.Add(alarm);
        }


        private void alarm_tick(object sender, EventArgs u)
        {

            //var player = new MediaPlayer();

            //if (clocks[0].hour + ":" + clocks[0].minute + ":00" == Count.Text.ToString())
            //{
            //    player.MediaFailed += (s, e) => MessageBox.Show("Ошибка воспроизведения");
            //    player.Open(new Uri(@"C:\Windows\media\Alarm03.wav", UriKind.RelativeOrAbsolute));
            //    player.Play();
            //    Alarm_start al = new Alarm_start();
            //    al.Show();


            //}
        }

        private void FillBoxes()
        {
            //for (int i = 1; i <= 23; i++)
            //{
            //    if (i <= 9)
            //        Hours.Items.Add("0" + i);
            //    else
            //        Hours.Items.Add(i);
            //}
            //Hours.Items.Add("00");
            //Minutes.Items.Add("00");

            //for (int i = 1; i <= 59; i++)
            //{
            //    if (i <= 9)
            //        Minutes.Items.Add("0" + i);
            //    else
            //        Minutes.Items.Add(i);
            //}

        }

        private void Clock_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {

            //switch (e.Action)
            //{
            //    case NotifyCollectionChangedAction.Add:
            //        Alarm_clock newclock = e.NewItems[0] as Alarm_clock;
            //        Clock.Text = newclock.hour + ":" + newclock.minute;
            //        Alarm_check.IsChecked = true;
            //        break;
            //    case NotifyCollectionChangedAction.Remove:
            //        Alarm_clock oldClock = e.NewItems[0] as Alarm_clock;
            //        Clock.Text = "";
            //        Alarm_check.IsChecked = false;
            //        break;
            //}
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Hours_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void listViewItem3_Selected(object sender, RoutedEventArgs e)
        {
            //Contact a = new Contact();
            //a.Show();
        }
    }
}

