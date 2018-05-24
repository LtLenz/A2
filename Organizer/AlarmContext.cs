using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace Organizer
{
    class AlarmContext : DbContext
    {
        public DbSet<AlarmClock> AlarmClocks { get; set; }

        public AlarmContext() : base("DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<AlarmContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}
