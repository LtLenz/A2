using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Organizer
{
    [Table("Alarms")]
    class AlarmClock
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Column("Alarm_Id")]
        public int Id { get; set; }
        [Column("Alarm_Name")]
        public string Alarm_Name { get; set; }
        [Column("Time")]
        public TimeSpan Time { get; set; }
        [Column("Alarm_Check")]
        public bool Alarm_Check { get; set; }

      

    }
}
