using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Organizer
{
    [Table("Contacto")]
    public class User_Contact
    {
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            
            [Column("Contact_Id")]
            public int Id { get; set; }
            [Column("Name")]
            public string Name { get; set; }
            [Column("MobPhone")]
            public string MobilePhone { get; set; }
            [Column("Email")]
            public string Email { get; set; }

        [Column("Image")]
        public string Image_Ad { get; set; }

        [Column("Birthday")]
        public string Birthday { get; set; }
    }
}
