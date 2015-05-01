using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transit.Models
{
	public class UserSetSchedule
	{
		[Key]
		public int id { get; set; }

		[Required]
		[DisplayName("Label")]
		public string label { get; set; }

		[DisplayName("Description")]
		public string description { get; set; }

		[Required]
		[ForeignKey("user")]
		public string userId { get; set; }
		[InverseProperty("schedules")]
		public ApplicationUser user { get; set; }

		public virtual ICollection<UserSetRouteLeg> routeLegs { get; set; }

		public string fromTime { get; set; }

		public string toTime { get; set; }
	}
}