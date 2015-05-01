using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transit.Models
{
    public class Agency
    {

        [Key]
        [ScaffoldColumn(false)]
        public int? id { get; set; }

        [Required]
        [DisplayName("Name")]
        public string name { get; set; }

        [Required]
        [DisplayName("URL")]
		[Url]
        public string url { get; set; }

		[ScaffoldColumn(false)]
		[DisplayName("Time-Zone")]
		[RegularExpression(
			@"(?<CountryContinent>[A-Z]{1,1}[A-Za-z]{1,15}?)([/]{0,1}?)(?<Area>[A-Z]{0,1}?[a-zA-Z]{0,20}[_+-]{0,1}[A-Za-z0-9]{0,20})(?<Extended>[_/+-]{0,1}[A-Za-z0-9]{0,20}[_+-]{0,1}[A-Za-z0-9]{0,20})",
			ErrorMessage = "Timezone must be in standard format. ")]
        public string timeZone { get; set; }

		[Required]
		[ForeignKey("timeZoneObj")]
		public int timeZoneObjId { get; set; }

		[DisplayName("Time-Zone")]
		public TimeZone timeZoneObj { get; set; }

		[DisplayName("Language")]
		[RegularExpression(
			@"[A-Za-z]{2}?",
			ErrorMessage = "Language must be a two letter code. (ISO=639-1)")]
		public string language { get; set; }

		[DisplayName("Language")]
		[ForeignKey("languageObj")]
		public int? languageId { get; set; }

		[DisplayName("Language")]
		public Language languageObj { get; set; }

        [DisplayName("Phone")]
		[Phone]
        public string phone { get; set; }

        [DisplayName("Fare URL")]
		[Url]
        public string fareUrl { get; set; }

		[DisplayName("Routes")]
		public virtual ICollection<Route> routes { get; set; }
    }
}