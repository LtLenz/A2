using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Organizer
{
    class ContactContext : DbContext
    {
        public DbSet<User_Contact> Contacts { get; set; }

        public ContactContext() : base("DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<ContactContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}
