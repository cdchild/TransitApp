using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transit.Models
{
    public class StopTime
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
        [ForeignKey("stop")]
        [DisplayName("Stop")]
        public int stopId { get; set; }

        [DisplayName("Stop")]
        public Stop stop { get; set; }

        [Required]
        [DisplayName("Arrive")]
        public string arrival { get; set; }

        [Required]
        [DisplayName("Depart")]
        public string departure { get; set; }

        [Required]
        [DisplayName("Order")]
        public ushort sequence { get; set; }

        [DisplayName("Label")]
        public string label { get; set; }

        [ForeignKey("pickupType")]
        [DisplayName("Pickup")]
        public byte? pickupTypeId { get; set; }

        [DisplayName("Pickup")]
        public StopCode pickupType { get; set; }

        [ForeignKey("dropoffType")]
        [DisplayName("Drop-Off")]
        public byte? dropoffTypeId { get; set; }

        [DisplayName("Drop-Off")]
        public StopCode dropoffType { get; set; }

        [DisplayName("Distance")]
        public double? shapeDistanceTraveled { get; set; }
    }
}