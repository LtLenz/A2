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
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NLog;
using NLog.Config;
using NLog.Targets;
using VkNet;
using VkNet.Categories;
using VkNet.Enums.Filters;
using VkNet.Model.RequestParams;

namespace Organizer
{
    /// <summary>
    /// Логика взаимодействия для TextControl.xaml
    /// </summary>
    public partial class TextControl : UserControl
    {
        public TextControl()
        {
            InitializeComponent();
        }
        List<User_Contact> list = new List<User_Contact>();
        VkApi api = new VkApi();
        Nora girl = new Nora();
        public void one()
        {
            girl.Authorize();


                api.Messages.Send(new MessagesSendParams
                { UserId = 223333211,
                  Message = "Привет! Я твоя курсовая работа!"
                }); // посылаем сообщение пользователю
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            one();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ulong appId = 6483795; // указываем id приложения
            string email = "+375299616832"; // email для авторизации
            string password = "Annsurokmono13"; // пароль
            Settings settings = Settings.All; // уровень доступа к данным
            Nora nora = new Nora();
            api.Authorize(new ApiAuthParams
            {
                ApplicationId = appId,
                Login = email,
                Password = password,
                Settings = settings
            });

            var users = api.Friends.Get(new FriendsGetParams
            {
                UserId = 223333211,
                
               
                

            });

            list = nora.CatchFriends();
            string name;
            foreach (User_Contact c in list)
            {
                
                if (c.Birthday == DateTime.Now.Day.ToString() + "." + DateTime.Now.Month.ToString())
                    MessageBox.Show(c.Name);
                
            }








            //api.Messages.Send(new MessagesSendParams
            //{
            //    UserId = 223333211,
            //    Message = users[1].
            //}); // посылаем сообщение пользователю

        }
    }
}

