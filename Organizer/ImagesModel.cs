using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Organizer
{
    [Table("Images")]
    public class Images_model
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Column("Image")]
        public string Image_Addr { get; set; }
        [Column("ImageData")]
        public string Image_Byte { get; set; }
       
    }
}
