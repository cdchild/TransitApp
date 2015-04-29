using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transit.Models
{
	public class Transfer
	{
		[Key]
		[ScaffoldColumn(false)]
		public int id { get; set; }

		[Required]
		[ForeignKey("fromStop")]
		[DisplayName("From")]
		public int fromStopId { get; set; }

		[DisplayName("From")]
		public Stop fromStop { get; set; }

		[Required]
		[ForeignKey("toStop")]
		[DisplayName("To")]
		public int toStopId { get; set; }

		[DisplayName("To")]
		public Stop toStop { get; set; }

		[Required]
		[ForeignKey("type")]
		[DisplayName("Type")]
		public byte? typeId { get; set; }

		[DisplayName("Type")]
		public TransferType type { get; set; }

		[Range(0, 99999)]
		[DisplayName("Time")]
		public ushort transferTime { get; set; }
	}
}