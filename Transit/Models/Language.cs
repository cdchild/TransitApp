using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transit.Models
{
	public class Language
	{
		[Key]
		[ScaffoldColumn(false)]
		public int id { get; set; }

        [Required]
		[DisplayName("Label")]
		[RegularExpression(
			@"[A-Za-z]{2}?",
			ErrorMessage = "Language label must be a two letter code. (ISO=639-1)")]
		public string label { get; set; }

		[DisplayName("Description")]
		public string description { get; set; }
	}
}