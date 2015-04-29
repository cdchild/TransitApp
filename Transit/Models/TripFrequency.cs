using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transit.Models
{
    public class TripFrequency
    {

        [Key]
        [ScaffoldColumn(false)]
        public int id { get; set; }

        [Required]
        [ForeignKey("trip")]
        [DisplayName("Trip")]
        public int tripId { get; set; }

        [DisplayName("Trip")]
        public Trip trip { get; set; }

        [Required]
        [DisplayName("Start")]
        public string start { get; set; }

        [Required]
        [DisplayName("End")]
        public string end { get; set; }

        [Required]
        [DisplayName("Headway (s)")]
        public uint headwaySeconds { get; set; }

        [DisplayName("Exact")]
        public bool? exactTime { get; set; }
    }
}