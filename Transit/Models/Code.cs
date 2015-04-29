using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transit.Models
{
    public abstract class Code
    {

        [Key]
		public virtual byte id { get; set; }

        [Required]
        [DisplayName("Label")]
		public virtual string label { get; set; }

        [DisplayName("Description")]
		public virtual string description { get; set; }
    }
}