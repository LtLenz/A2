using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    class Nora
    {
        VkApi api = new VkApi();
        public Nora()
        {

        }
        public void Authorize()
        {
            ulong appId = 6483795;
            string email = "+375299616832"; 
            string password = "Annsurokmono13";
            Settings settings = Settings.All;
            

            api.Authorize(new ApiAuthParams
            {
                AccessToken = "1889004318890043188900435018ebef101188918890043438bcfe8a8a8d410c6b9dce4",
                ApplicationId = 6483795,
                Login = "+375299616832",
                Password = "Annsurokmono13",
                Settings = Settings.All,
                
            });

        }

        public bool BirthCheck()
        {
            bool check = false;
            List<User_Contact> Friends = CatchFriends();
            foreach (User_Contact c in Friends)
                if (c.Birthday == DateTime.Now.Day.ToString() + "." + DateTime.Now.Month.ToString())
                    check = true;


            if (check == true) return true;
            else return false;
        }

        public void BDemail()
        {
            
            var users = api.Friends.Get(new FriendsGetParams
            {
                UserId = 223333211,
                Fields =
                ProfileFields.FirstName | ProfileFields.LastName | ProfileFields.Contacts | ProfileFields.Site | ProfileFields.BirthDate,
                Order = VkNet.Enums.SafetyEnums.FriendsOrder.Name
            });
            List <User_Contact> list = CatchFriends();
            
            foreach (var c in users)
            {
                

                if (c.BirthDate == DateTime.Now.Day.ToString() + "." + DateTime.Now.Month.ToString())
                { 
                    api.Messages.Send(new MessagesSendParams
                    {
                        UserId = 223333211,
                        Message = "У " + c.FirstName + ", поздравляю с днём рождения! Удачи с курсачем!"
                    });


                }

            }
            

         
        }

        public List<User_Contact> CatchFriends()
        {
            List<User_Contact> Friends = new List<User_Contact>();
            Authorize();
            var users = api.Friends.Get(new FriendsGetParams
            {
                UserId = 223333211,
                Fields = 
                ProfileFields.FirstName | ProfileFields.LastName | ProfileFields.Contacts | ProfileFields.Site | ProfileFields.BirthDate,
                Order = VkNet.Enums.SafetyEnums.FriendsOrder.Name
            });

            for (int i = 1; i <= Convert.ToInt32(users.TotalCount) - 1; i++)
            {
                Friends.Add(new User_Contact
                {
                    Name = users[i].FirstName + " " + users[i].LastName,
                    MobilePhone = users[i].MobilePhone,
                    Email = users[i].Site,
                    Birthday = users[i].BirthDate
                    
                });
                    
                   

            }

            return Friends;
        }
    }
}
