using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transit.Models
{
    public abstract class Code
    {

        [Key]
		public  byte id { get; set; }

        [Required]
        [DisplayName("Label")]
		public  string label { get; set; }

        [DisplayName("Description")]
		public  string description { get; set; }
    }
}