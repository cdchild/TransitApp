using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transit.Models
{
	public class UserSetRouteLeg
	{
		[Key]
		public int id { get; set; }

		[Required]
		[ForeignKey("userSetSchedule")]
		public int userSetScheduleId { get; set; }
		[InverseProperty("routeLegs")]
		public UserSetSchedule userSetSchedule { get; set; }

		[Required]
		[ForeignKey("route")]
		public int routeId { get; set; }
		[InverseProperty("userSetRouteLegs")]
		public Route route { get; set; }

		public virtual ICollection<UserSetLegStop> legStops { get; set; }


	}
}