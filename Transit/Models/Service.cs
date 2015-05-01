using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transit.Models
{
    /// <summary>
    /// Known as a calendar in the GTFS format.
    /// </summary>
    public class Service
    {

        [Key]
        [ScaffoldColumn(false)]
		public int id { get; set; }

		[Required]
		[DisplayName("Code")]
		public string code { get; set; }

        [DisplayName("M")]
        public bool mondays { get; set; }

        [DisplayName("Tu")]
        public bool tuesdays { get; set; }

        [DisplayName("W")]
        public bool wednesdays { get; set; }

        [DisplayName("Th")]
        public bool thursdays { get; set; }

        [DisplayName("F")]
        public bool fridays { get; set; }

        [DisplayName("Sa")]
        public bool saturdays { get; set; }

        [DisplayName("Su")]
        public bool sundays { get; set; }

        [Required]
        [DisplayName("Start")]
        public int start { get; set; }

        [Required]
        [DisplayName("End")]
        public int end { get; set; }

		[DisplayName("Dates")]
		public virtual ICollection<ServiceDate> serviceDates { get; set; }
    }

	public struct Services
	{
		public static List<Service> List()
		{
			List<Service> servicesList = new List<Service>();

			{
				servicesList.Add(new Service { code = "8_merged_2013844", start = 20140413, end = 20140816, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "21_merged_2013864", start = 20140817, end = 20141206, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "4_merged_2013874", start = 20140817, end = 20141206, mondays = 1 == 1, tuesdays = 1 == 1, wednesdays = 1 == 1, thursdays = 1 == 1, fridays = 1 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "123704_merged_2013860", start = 20140817, end = 20141206, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "71304_merged_2013886", start = 20140817, end = 20141206, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "128004_merged_2013859", start = 20140817, end = 20141206, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "123704_merged_2013827", start = 20140413, end = 20140816, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "18_merged_2013857", start = 20140413, end = 20140816, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "24904_merged_2013875", start = 20140817, end = 20141206, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "11_merged_2013848", start = 20140413, end = 20140816, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "1004_merged_2013858", start = 20140413, end = 20140816, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "25_merged_2013862", start = 20140817, end = 20141206, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "16_merged_2013888", start = 20140817, end = 20141206, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "12704_merged_2013847", start = 20140413, end = 20140816, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "116303", start = 20140413, end = 20140816, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "9_merged_2013843", start = 20140413, end = 20140816, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "32404_merged_2013845", start = 20140413, end = 20140816, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "150804_merged_2013869", start = 20140817, end = 20141206, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "82404_merged_2013868", start = 20140817, end = 20141206, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "10_merged_2013849", start = 20140413, end = 20140816, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "2_merged_2013840", start = 20140413, end = 20140816, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 1 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "168202_merged_2013846", start = 20140413, end = 20140816, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "20_merged_2013863", start = 20140817, end = 20141206, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "16_merged_2013855", start = 20140413, end = 20140816, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "19_merged_2013856", start = 20140413, end = 20140816, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "46304", start = 20140817, end = 20141206, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "11_merged_2013881", start = 20140817, end = 20141206, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "84204", start = 20140413, end = 20140816, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "12_merged_2013851", start = 20140413, end = 20140816, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "15_merged_2013852", start = 20140413, end = 20140816, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "13304_merged_2013867", start = 20140817, end = 20141206, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "3_merged_2013839", start = 20140413, end = 20140816, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 1 == 1, });
				servicesList.Add(new Service { code = "22_merged_2013832", start = 20140413, end = 20140816, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "24_merged_2013828", start = 20140413, end = 20140816, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "19_merged_2013889", start = 20140817, end = 20141206, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "8_merged_2013877", start = 20140817, end = 20141206, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "32404_merged_2013878", start = 20140817, end = 20141206, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "1_merged_2013871", start = 20140817, end = 20141206, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "1_merged_2013838", start = 20140413, end = 20140816, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "24_merged_2013861", start = 20140817, end = 20141206, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "10_merged_2013882", start = 20140817, end = 20141206, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "71304_merged_2013853", start = 20140413, end = 20140816, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "17_merged_2013887", start = 20140817, end = 20141206, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "1004_merged_2013891", start = 20140817, end = 20141206, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "23_merged_2013866", start = 20140817, end = 20141206, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "15_merged_2013885", start = 20140817, end = 20141206, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "57902_merged_2013837", start = 20140413, end = 20140816, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "150804_merged_2013836", start = 20140413, end = 20140816, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "3_merged_2013872", start = 20140817, end = 20141206, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 1 == 1, });
				servicesList.Add(new Service { code = "18_merged_2013890", start = 20140817, end = 20141206, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "2_merged_2013873", start = 20140817, end = 20141206, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 1 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "168202_merged_2013879", start = 20140817, end = 20141206, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "13_merged_2013883", start = 20140817, end = 20141206, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "128004_merged_2013826", start = 20140413, end = 20140816, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "23_merged_2013833", start = 20140413, end = 20140816, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "9_merged_2013876", start = 20140817, end = 20141206, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "17_merged_2013854", start = 20140413, end = 20140816, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "25_merged_2013829", start = 20140413, end = 20140816, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "13304_merged_2013834", start = 20140413, end = 20140816, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "12_merged_2013884", start = 20140817, end = 20141206, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "13_merged_2013850", start = 20140413, end = 20140816, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "82404_merged_2013835", start = 20140413, end = 20140816, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "24904_merged_2013842", start = 20140413, end = 20140816, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "21_merged_2013831", start = 20140413, end = 20140816, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "4_merged_2013841", start = 20140413, end = 20140816, mondays = 1 == 1, tuesdays = 1 == 1, wednesdays = 1 == 1, thursdays = 1 == 1, fridays = 1 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "57902_merged_2013870", start = 20140817, end = 20141206, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "12704_merged_2013880", start = 20140817, end = 20141206, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "22_merged_2013865", start = 20140817, end = 20141206, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
				servicesList.Add(new Service { code = "20_merged_2013830", start = 20140413, end = 20140816, mondays = 0 == 1, tuesdays = 0 == 1, wednesdays = 0 == 1, thursdays = 0 == 1, fridays = 0 == 1, saturdays = 0 == 1, sundays = 0 == 1, });
			}

			return servicesList;
		}
	}
}