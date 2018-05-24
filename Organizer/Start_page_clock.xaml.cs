using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Organizer
{
    /// <summary>
    /// Логика взаимодействия для Start_page_clock.xaml
    /// </summary>
    public partial class Start_page_clock : UserControl
    {
        DispatcherTimer timer;

        public Start_page_clock()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0.1);
            timer.Start();
            timer.Tick += new EventHandler(delegate (object s, EventArgs a)
            {

                Hours.Text = DateTime.Now.ToString("HH");
                Minutes.Text = DateTime.Now.ToString("mm");
                Day.Text = DateTime.Now.DayOfWeek.ToString() + ' ' + DateTime.Now.Date.ToString("dd:mm");




            });
        }
    }
    
}
