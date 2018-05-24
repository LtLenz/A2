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
using System.Media;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Organizer
{
    /// <summary>
    /// Логика взаимодействия для AlarmSignal.xaml
    /// </summary>
    public partial class AlarmSignal : Window
    {
        SoundPlayer sp;
        public AlarmSignal()
        {
            InitializeComponent();
            sp = new SoundPlayer(@"C:\Windows\media\Alarm01.wav");
            sp.Play();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AlarmSignal alarm = new AlarmSignal();
            alarm.Close();
        }
        
    }
}
