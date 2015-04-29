using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Device.Location;

namespace Transit.Models
{
	public class ShapePoint
	{
		[Key]
		[ScaffoldColumn(false)]
		public int id { get; set; }

		[Required]
		[DisplayName("Shape")]
		public int? shapeId { get; set; }

		[Required]
		[DisplayName("Lat")]
		public double latitude { get; set; }

		[Required]
		[DisplayName("Long")]
		public double longitude { get; set; }

		[DisplayName("Coordinate")]
		[ScaffoldColumn(false)]
		[ReadOnly(true)]
		public GeoCoordinate coordinate { get { return new GeoCoordinate { Longitude = longitude, Latitude = latitude }; } }

		[Required]
		[DisplayName("Order")]
		[Range(0,99999999, ErrorMessage= "Order/sequence must be a non-negative number.")]
		public int sequence { get; set; }

		[DisplayName("Distance")]
		[Required(AllowEmptyStrings= true)]
		[Range(0,999999999, ErrorMessage= "Distance must be a non-negative number.")]
		public double? distanceTraveled { get; set; }
	}
}