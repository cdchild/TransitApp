using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transit.Models
{
	public class UserSetLegStop
	{
		[Key]
		public int id { get; set; }
		
		[Required]
		[ForeignKey("routeLeg")]
		public int routeLegId { get; set; }
		[InverseProperty("legStops")]
		public UserSetRouteLeg routeLeg { get; set; }

		[Required]
		[ForeignKey("stop")]
		public int stopId { get; set; }
		[InverseProperty("userSetLegStops")]
		public Stop stop { get; set; }

	}
}