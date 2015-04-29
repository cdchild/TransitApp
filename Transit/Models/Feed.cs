using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transit.Models
{
    public class Feed
    {
        [Key]
        [ScaffoldColumn(false)]
        public int id { get; set; }

        [DisplayName("Publisher")]
        public string publisher { get; set; }

        [DisplayName("URL")]
		[Url]
        public string url { get; set; }

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

        [DisplayName("Start")]
        public int start { get; set; }

        [DisplayName("End")]
        public int end { get; set; }

        [DisplayName("Version")]
        public string version { get; set; }
    }
}