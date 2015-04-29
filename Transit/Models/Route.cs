using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transit.Models
{
    public class Route
    {

        [Key]
        [ScaffoldColumn(false)]
        public int id { get; set; }

        [Required]
        [ForeignKey("agency")]
        [DisplayName("Agency")]
        public int? agencyId { get; set; }

        [DisplayName("Agency")]
        public Agency agency { get; set; }

        [Required]
        [DisplayName("Label")]
        public string label { get; set; }

        [Required]
        [DisplayName("Name")]
        public string fullName { get; set; }

        [DisplayName("Description")]
        public string description { get; set; }

        [Required]
        [ForeignKey("type")]
        [DisplayName("Type")]
        public byte typeId { get; set; }

        [DisplayName("Type")]
        public RouteType type { get; set; }

        [DisplayName("URL")]
		[Url]
        public string url { get; set; }

        [DisplayName("Color")]
        public string color { get; set; }

        [ReadOnly(true)]
        [ScaffoldColumn(false)]
        public Color colorObj
		{ get { return new Color(color); } }

        [DisplayName("Text Color")]
        public string textColor { get; set; }

        [ReadOnly(true)]
        [ScaffoldColumn(false)]
        public Color textColorObj
		{ get { return new Color(textColor); } }
    }
}