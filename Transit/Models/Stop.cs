using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Device.Location;

namespace Transit.Models
{
    public class Stop
    {

        [Key]
        [ScaffoldColumn(false)]
        public int id { get; set; }

        [DisplayName("Code")]
        public string code { get; set; }

        [Required]
        [DisplayName("Name")]
        public string name { get; set; }

        [DisplayName("Description")]
        public string description { get; set; }

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

        [DisplayName("Service Zone")]
        public int? zoneId { get; set; }

        [DisplayName("URL")]
		[Url]
        public string stopUrl { get; set; }

        [Description("Location Type")]
        [DisplayName("Station?")]
        public bool? isConsideredStation { get; set; }

        [DisplayName("Parent?")]
        public bool? parentStation { get; set; }

        [DisplayName("Time-Zone")]
        public string timezone { get; set; }

        [ForeignKey("accessibleCode")]
        [DisplayName("Accessibity")]
        public byte? accessibleCodeId { get; set; }

        [DisplayName("Accessibity")]
        public AccessibleCode accessibleCode { get; set; }

		[DisplayName("Times")]
		public IEnumerable<StopTime> stopTimes { get; set; }
    }
}