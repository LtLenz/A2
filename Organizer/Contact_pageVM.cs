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
   
    class Contact_pageVM : BaseViewModel
    {
        public int Id = 1;
        public string Name { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }

        public string Birthday { get; set; }

        public string Image_Addr { get; set; }
        public string Image_Byte { get; set; }

        string _pattern;
       
        private User_Contact selectedcontact;
        public User_Contact SelectedContact
        {
            get
            {


                return selectedcontact;
            }

            set
            {
                Set(ref selectedcontact, value);
                OnPropertyChanged("SelectedContact");

            }
        }


        public ContactContext database;
        private ContactsControl contactsControl;

        

        public ObservableCollection<User_Contact> Contactso { get; set; }
       

        public ICommand AddUserContactCommand { get; set; }
        public ICommand SyncUserContactCommand { get; set; }
        public ICommand RemoveUserContactCommand { get; set; }
        public ICommand EditUserContactCommand { get; set; }


        public Contact_pageVM(ContactsControl cont)
        {
            

            database = new ContactContext();
            database.Contacts.Load();

            if (Contactso == null)
            {
                Contactso = new ObservableCollection<User_Contact>();
                Contactso = database.Contacts.Local;
            }

          


            AddUserContactCommand = new RelayCommand(AddUserContact);
            SyncUserContactCommand = new RelayCommand(SyncUserContact);
            RemoveUserContactCommand = new RelayCommand(RemoveUserContact);
            EditUserContactCommand = new RelayCommand(EditUserContact);
        }


        public void AddUserContact()
        {
            var contacter = new User_Contact
            {
               Name = Name,
               MobilePhone = MobilePhone,
               Email = Email,
               Birthday = Birthday
              

            };

            database.Contacts.Add(contacter);
            database.SaveChanges();
            
            Contactso.Add(contacter);
        }

        public void EditUserContact()
        {
            var contacter = new User_Contact
            {
                Name = SelectedContact.Name,
                MobilePhone = SelectedContact.MobilePhone,
                Email = SelectedContact.Email,
                Birthday = SelectedContact.Birthday


            };

            database.Contacts.Add(contacter);
 
            database.SaveChanges();

            Contactso.Add(contacter);
        }

        public void SyncUserContact()
        {
            Nora nora = new Nora();
            nora.Authorize();
            List<User_Contact> Friends = nora.CatchFriends();
            foreach (User_Contact con in Friends)
            {
                var contacter = new User_Contact
                {
                    Name = con.Name,
                    MobilePhone = con.MobilePhone,
                    Email = con.Email,
                    Birthday = con.Birthday

                };

                database.Contacts.Add(contacter);
                database.SaveChanges();

                Contactso.Add(contacter);
            }

           
        }

        public void RemoveUserContact()
        {
            var contacter = database.Contacts.FirstOrDefault(list => list.Name == SelectedContact.Name);
            
            database.Contacts.Remove(contacter);
            database.SaveChanges();
        }
        
        public string Pattern
        {
            get => _pattern;
            set
            {
                Set(ref _pattern, value);
                SelectedContact = Contactso.FirstOrDefault(s => s.Name.StartsWith(Pattern));
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


