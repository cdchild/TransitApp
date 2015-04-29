using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transit.Models
{
    public class Trip
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
        [ForeignKey("route")]
        [DisplayName("Route")]
        public int routeId { get; set; }

        [DisplayName("Route")]
        public Route route { get; set; }

        [DisplayName("Label")]
        public string label { get; set; }

        [DisplayName("Direction")]
        public bool direction { get; set; }

        [DisplayName("Block")]
        public int? blockId { get; set; }

        [DisplayName("Shape")]
        public int? shapeId { get; set; }

		[DisplayName("Route Points")]
		[ScaffoldColumn(false)]
		public IEnumerable<ShapePoint> shapePoints { get; set; }

        [ForeignKey("accessibleCode")]
        [DisplayName("Accessibity")]
        public byte? accessibleCodeId { get; set; }

        [DisplayName("Accessibity")]
        public AccessibleCode accessibleCode { get; set; }

        [ForeignKey("bikeCode")]
        [DisplayName("Bikes")]
        public byte? bikeCodeId { get; set; }

        [DisplayName("Bikes")]
        public BikeCode bikeCode { get; set; }

		[DisplayName("Stops")]
		public IEnumerable<StopTime> stopTimes { get; set; }

		[DisplayName("Frequencies")]
		public IEnumerable<TripFrequency> frequencies { get; set; }
    }
}