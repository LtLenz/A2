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
using System.Data.Entity;
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
    /// Логика взаимодействия для ContactsControl.xaml
    /// </summary>
    public partial class ContactsControl : UserControl
    {


        public ContactsControl()
        {
            InitializeComponent();
            DataContext = new Contact_pageVM(this);
        

        //DispatcherTimer timer_counter = new DispatcherTimer();
        //timer_counter.Interval = new TimeSpan(0, 0, 1);
        //timer_counter.Tick += new EventHandler(counter_tick);
        //timer_counter.Start();

        }
    private void counter_tick(object sender, EventArgs e)
    {
        Nora nora = new Nora();
        nora.Authorize();
        if (nora.BirthCheck())
            nora.BDemail();
    }
    private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = sender as ListBox;
            listBox.ScrollIntoView(listBox.SelectedItem);
        }
    }
}
