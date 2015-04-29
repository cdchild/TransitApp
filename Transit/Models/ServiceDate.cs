using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transit.Models
{
    /// <summary>
    /// Known as a calendar_date in the GTFS format.
    /// </summary>
    public class ServiceDate
    {

        [Key]
        [ScaffoldColumn(false)]
        public int id { get; set; }

        [Required]
        [ForeignKey("service")]
        [DisplayName("Service")]
        public int serviceId { get; set; }

        [DisplayName("Service")]
        public Service service { get; set; }

        [Required]
        [DisplayName("Date")]
        public int date { get; set; }

        [Required]
        [DisplayName("Exception #")]
        [Range(1,2)]
        public byte exceptionNum { get; set; }
        
        [ReadOnly(true)]
        [DisplayName("Add to Service")]
        public bool added { get { return exceptionNum == 1; } }
    }
}