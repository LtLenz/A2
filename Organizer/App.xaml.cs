using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Data.Entity;

namespace Organizer
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        //private void OnStartup(object sender, StartupEventArgs e)
        //{
        //    ContactContext context = new ContactContext();

        //    IEnumerable<User_contact> flay = from u in context.User_contacts
        //                             select u;
        //    List<User_contact> list = new List<User_contact>();

        //    foreach (User_contact f in flay)
        //    {
        //        list.Add(f);
        //    }
        //    MainWindow main = new MainWindow();

        //    Start_page_view_model mainView = new Start_page_view_model(list);

        //    main.DataContext = mainView;

        //    main.Show();
        //}
    }
}
