﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Transit.Models
{
	public class TimeZone
	{
		[Key]
		[ScaffoldColumn(false)]
		public int id { get; set; }

		[DisplayName("Country Code")]
		[RegularExpression(
			@"[A-Za-z]{2}?",
			ErrorMessage = "Country must be a two letter code. (ISO 3166-2)")]
		public string countryCode { get; set; }

		[Required]
		[DisplayName("Country")]
		[ForeignKey("country")]
		public int countryId { get; set; }

		[DisplayName("Country")]
		public Country country { get; set; }

		[Required]
		[DisplayName("Raw Coordinate")]
		[RegularExpression(
			@"(?<latitude>[+-]{0,1}[0-9]{2,6}.[0-9]{1,4})[ ]{0,1}(?<longitude>[+-]{0,1}[0-9]{2,6}.[0-9]{1,4})(?<altitude>[+-]{0,1}[0-9]{0,3}[.]{0,1}[0-9]{0,3})",
			ErrorMessage = "Coordinate must be in standard format. (ISO 6709)")]
		public string rawCoordinate { get; set; }

		[Required]
		[DisplayName("Label")]
		[RegularExpression(
			@"(?<CountryContinent>[A-Z]{1,1}[A-Za-z]{1,15}?)([/]{0,1}?)(?<Area>[A-Z]{0,1}?[a-zA-Z]{0,20}[_+-]{0,1}[A-Za-z0-9]{0,20})(?<Extended>[_/+-]{0,1}[A-Za-z0-9]{0,20}[_+-]{0,1}[A-Za-z0-9]{0,20})",
			ErrorMessage = "Timezone must be in standard format. ")]
		public string label { get; set; }

		[DisplayName("Description")]
		public string comments { get; set; }
	}
	public struct TimeZones
	{
		public static IEnumerable<TimeZone> List(ApplicationDbContext db)
		{
			List<TimeZone> timeZonesList = new List<TimeZone>();
			timeZonesList.Add(new Models.TimeZone { countryCode = "AD", rawCoordinate = "+4230+00131", label = "Europe/Andorra", countryId = db.Countries.Local.First(c => c.label == "AD").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "AE", rawCoordinate = "+2518+05518", label = "Asia/Dubai", countryId = db.Countries.Local.First(c => c.label == "AE").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "AF", rawCoordinate = "+3431+06912", label = "Asia/Kabul", countryId = db.Countries.Local.First(c => c.label == "AF").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "AG", rawCoordinate = "+1703-06148", label = "America/Antigua", countryId = db.Countries.Local.First(c => c.label == "AG").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "AI", rawCoordinate = "+1812-06304", label = "America/Anguilla", countryId = db.Countries.Local.First(c => c.label == "AI").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "AL", rawCoordinate = "+4120+01950", label = "Europe/Tirane", countryId = db.Countries.Local.First(c => c.label == "AL").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "AM", rawCoordinate = "+4011+04430", label = "Asia/Yerevan", countryId = db.Countries.Local.First(c => c.label == "AM").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "AO", rawCoordinate = "-0848+01314", label = "Africa/Luanda", countryId = db.Countries.Local.First(c => c.label == "AO").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "AQ", rawCoordinate = "-7750+16636", label = "Antarctica/McMurdo", comments = "McMurdo, South Pole, Scott (New Zealand time)", countryId = db.Countries.Local.First(c => c.label == "AQ").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "AQ", rawCoordinate = "-6734-06808", label = "Antarctica/Rothera", comments = "Rothera Station, Adelaide Island", countryId = db.Countries.Local.First(c => c.label == "AQ").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "AQ", rawCoordinate = "-6448-06406", label = "Antarctica/Palmer", comments = "Palmer Station, Anvers Island", countryId = db.Countries.Local.First(c => c.label == "AQ").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "AQ", rawCoordinate = "-6736+06253", label = "Antarctica/Mawson", comments = "Mawson Station, Holme Bay", countryId = db.Countries.Local.First(c => c.label == "AQ").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "AQ", rawCoordinate = "-6835+07758", label = "Antarctica/Davis", comments = "Davis Station, Vestfold Hills", countryId = db.Countries.Local.First(c => c.label == "AQ").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "AQ", rawCoordinate = "-6617+11031", label = "Antarctica/Casey", comments = "Casey Station, Bailey Peninsula", countryId = db.Countries.Local.First(c => c.label == "AQ").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "AQ", rawCoordinate = "-7824+10654", label = "Antarctica/Vostok", comments = "Vostok Station, Lake Vostok", countryId = db.Countries.Local.First(c => c.label == "AQ").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "AQ", rawCoordinate = "-6640+14001", label = "Antarctica/DumontDUrville", comments = "Dumont-d'Urville Station, Terre Adelie", countryId = db.Countries.Local.First(c => c.label == "AQ").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "AQ", rawCoordinate = "-690022+0393524", label = "Antarctica/Syowa", comments = "Syowa Station, E Ongul I", countryId = db.Countries.Local.First(c => c.label == "AQ").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "AQ", rawCoordinate = "-720041+0023206", label = "Antarctica/Troll", comments = "Troll Station, Queen Maud Land", countryId = db.Countries.Local.First(c => c.label == "AQ").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "AR", rawCoordinate = "-3436-05827", label = "America/Argentina/Buenos_Aires", comments = "Buenos Aires (BA, CF)", countryId = db.Countries.Local.First(c => c.label == "AR").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "AR", rawCoordinate = "-3124-06411", label = "America/Argentina/Cordoba", comments = "most locations (CB, CC, CN, ER, FM, MN, SE, SF)", countryId = db.Countries.Local.First(c => c.label == "AR").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "AR", rawCoordinate = "-2447-06525", label = "America/Argentina/Salta", comments = "(SA, LP, NQ, RN)", countryId = db.Countries.Local.First(c => c.label == "AR").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "AR", rawCoordinate = "-2411-06518", label = "America/Argentina/Jujuy", comments = "Jujuy (JY)", countryId = db.Countries.Local.First(c => c.label == "AR").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "AR", rawCoordinate = "-2649-06513", label = "America/Argentina/Tucuman", comments = "Tucuman (TM)", countryId = db.Countries.Local.First(c => c.label == "AR").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "AR", rawCoordinate = "-2828-06547", label = "America/Argentina/Catamarca", comments = "Catamarca (CT), Chubut (CH)", countryId = db.Countries.Local.First(c => c.label == "AR").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "AR", rawCoordinate = "-2926-06651", label = "America/Argentina/La_Rioja", comments = "La Rioja (LR)", countryId = db.Countries.Local.First(c => c.label == "AR").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "AR", rawCoordinate = "-3132-06831", label = "America/Argentina/San_Juan", comments = "San Juan (SJ)", countryId = db.Countries.Local.First(c => c.label == "AR").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "AR", rawCoordinate = "-3253-06849", label = "America/Argentina/Mendoza", comments = "Mendoza (MZ)", countryId = db.Countries.Local.First(c => c.label == "AR").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "AR", rawCoordinate = "-3319-06621", label = "America/Argentina/San_Luis", comments = "San Luis (SL)", countryId = db.Countries.Local.First(c => c.label == "AR").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "AR", rawCoordinate = "-5138-06913", label = "America/Argentina/Rio_Gallegos", comments = "Santa Cruz (SC)", countryId = db.Countries.Local.First(c => c.label == "AR").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "AR", rawCoordinate = "-5448-06818", label = "America/Argentina/Ushuaia", comments = "Tierra del Fuego (TF)", countryId = db.Countries.Local.First(c => c.label == "AR").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "AS", rawCoordinate = "-1416-17042", label = "Pacific/Pago_Pago", countryId = db.Countries.Local.First(c => c.label == "AS").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "AT", rawCoordinate = "+4813+01620", label = "Europe/Vienna", countryId = db.Countries.Local.First(c => c.label == "AT").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "AU", rawCoordinate = "-3133+15905", label = "Australia/Lord_Howe", comments = "Lord Howe Island", countryId = db.Countries.Local.First(c => c.label == "AU").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "AU", rawCoordinate = "-5430+15857", label = "Antarctica/Macquarie", comments = "Macquarie Island", countryId = db.Countries.Local.First(c => c.label == "AU").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "AU", rawCoordinate = "-4253+14719", label = "Australia/Hobart", comments = "Tasmania - most locations", countryId = db.Countries.Local.First(c => c.label == "AU").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "AU", rawCoordinate = "-3956+14352", label = "Australia/Currie", comments = "Tasmania - King Island", countryId = db.Countries.Local.First(c => c.label == "AU").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "AU", rawCoordinate = "-3749+14458", label = "Australia/Melbourne", comments = "Victoria", countryId = db.Countries.Local.First(c => c.label == "AU").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "AU", rawCoordinate = "-3352+15113", label = "Australia/Sydney", comments = "New South Wales - most locations", countryId = db.Countries.Local.First(c => c.label == "AU").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "AU", rawCoordinate = "-3157+14127", label = "Australia/Broken_Hill", comments = "New South Wales - Yancowinna", countryId = db.Countries.Local.First(c => c.label == "AU").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "AU", rawCoordinate = "-2728+15302", label = "Australia/Brisbane", comments = "Queensland - most locations", countryId = db.Countries.Local.First(c => c.label == "AU").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "AU", rawCoordinate = "-2016+14900", label = "Australia/Lindeman", comments = "Queensland - Holiday Islands", countryId = db.Countries.Local.First(c => c.label == "AU").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "AU", rawCoordinate = "-3455+13835", label = "Australia/Adelaide", comments = "South Australia", countryId = db.Countries.Local.First(c => c.label == "AU").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "AU", rawCoordinate = "-1228+13050", label = "Australia/Darwin", comments = "Northern Territory", countryId = db.Countries.Local.First(c => c.label == "AU").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "AU", rawCoordinate = "-3157+11551", label = "Australia/Perth", comments = "Western Australia - most locations", countryId = db.Countries.Local.First(c => c.label == "AU").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "AU", rawCoordinate = "-3143+12852", label = "Australia/Eucla", comments = "Western Australia - Eucla area", countryId = db.Countries.Local.First(c => c.label == "AU").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "AW", rawCoordinate = "+1230-06958", label = "America/Aruba", countryId = db.Countries.Local.First(c => c.label == "AW").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "AX", rawCoordinate = "+6006+01957", label = "Europe/Mariehamn", countryId = db.Countries.Local.First(c => c.label == "AX").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "AZ", rawCoordinate = "+4023+04951", label = "Asia/Baku", countryId = db.Countries.Local.First(c => c.label == "AZ").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "BA", rawCoordinate = "+4352+01825", label = "Europe/Sarajevo", countryId = db.Countries.Local.First(c => c.label == "BA").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "BB", rawCoordinate = "+1306-05937", label = "America/Barbados", countryId = db.Countries.Local.First(c => c.label == "BB").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "BD", rawCoordinate = "+2343+09025", label = "Asia/Dhaka", countryId = db.Countries.Local.First(c => c.label == "BD").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "BE", rawCoordinate = "+5050+00420", label = "Europe/Brussels", countryId = db.Countries.Local.First(c => c.label == "BE").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "BF", rawCoordinate = "+1222-00131", label = "Africa/Ouagadougou", countryId = db.Countries.Local.First(c => c.label == "BF").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "BG", rawCoordinate = "+4241+02319", label = "Europe/Sofia", countryId = db.Countries.Local.First(c => c.label == "BG").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "BH", rawCoordinate = "+2623+05035", label = "Asia/Bahrain", countryId = db.Countries.Local.First(c => c.label == "BH").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "BI", rawCoordinate = "-0323+02922", label = "Africa/Bujumbura", countryId = db.Countries.Local.First(c => c.label == "BI").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "BJ", rawCoordinate = "+0629+00237", label = "Africa/Porto-Novo", countryId = db.Countries.Local.First(c => c.label == "BJ").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "BL", rawCoordinate = "+1753-06251", label = "America/St_Barthelemy", countryId = db.Countries.Local.First(c => c.label == "BL").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "BM", rawCoordinate = "+3217-06446", label = "Atlantic/Bermuda", countryId = db.Countries.Local.First(c => c.label == "BM").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "BN", rawCoordinate = "+0456+11455", label = "Asia/Brunei", countryId = db.Countries.Local.First(c => c.label == "BN").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "BO", rawCoordinate = "-1630-06809", label = "America/La_Paz", countryId = db.Countries.Local.First(c => c.label == "BO").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "BQ", rawCoordinate = "+120903-0681636", label = "America/Kralendijk", countryId = db.Countries.Local.First(c => c.label == "BQ").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "BR", rawCoordinate = "-0351-03225", label = "America/Noronha", comments = "Atlantic islands", countryId = db.Countries.Local.First(c => c.label == "BR").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "BR", rawCoordinate = "-0127-04829", label = "America/Belem", comments = "Amapa, E Para", countryId = db.Countries.Local.First(c => c.label == "BR").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "BR", rawCoordinate = "-0343-03830", label = "America/Fortaleza", comments = "NE Brazil (MA, PI, CE, RN, PB)", countryId = db.Countries.Local.First(c => c.label == "BR").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "BR", rawCoordinate = "-0803-03454", label = "America/Recife", comments = "Pernambuco", countryId = db.Countries.Local.First(c => c.label == "BR").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "BR", rawCoordinate = "-0712-04812", label = "America/Araguaina", comments = "Tocantins", countryId = db.Countries.Local.First(c => c.label == "BR").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "BR", rawCoordinate = "-0940-03543", label = "America/Maceio", comments = "Alagoas, Sergipe", countryId = db.Countries.Local.First(c => c.label == "BR").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "BR", rawCoordinate = "-1259-03831", label = "America/Bahia", comments = "Bahia", countryId = db.Countries.Local.First(c => c.label == "BR").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "BR", rawCoordinate = "-2332-04637", label = "America/Sao_Paulo", comments = "S & SE Brazil (GO, DF, MG, ES, RJ, SP, PR, SC, RS)", countryId = db.Countries.Local.First(c => c.label == "BR").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "BR", rawCoordinate = "-2027-05437", label = "America/Campo_Grande", comments = "Mato Grosso do Sul", countryId = db.Countries.Local.First(c => c.label == "BR").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "BR", rawCoordinate = "-1535-05605", label = "America/Cuiaba", comments = "Mato Grosso", countryId = db.Countries.Local.First(c => c.label == "BR").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "BR", rawCoordinate = "-0226-05452", label = "America/Santarem", comments = "W Para", countryId = db.Countries.Local.First(c => c.label == "BR").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "BR", rawCoordinate = "-0846-06354", label = "America/Porto_Velho", comments = "Rondonia", countryId = db.Countries.Local.First(c => c.label == "BR").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "BR", rawCoordinate = "+0249-06040", label = "America/Boa_Vista", comments = "Roraima", countryId = db.Countries.Local.First(c => c.label == "BR").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "BR", rawCoordinate = "-0308-06001", label = "America/Manaus", comments = "E Amazonas", countryId = db.Countries.Local.First(c => c.label == "BR").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "BR", rawCoordinate = "-0640-06952", label = "America/Eirunepe", comments = "W Amazonas", countryId = db.Countries.Local.First(c => c.label == "BR").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "BR", rawCoordinate = "-0958-06748", label = "America/Rio_Branco", comments = "Acre", countryId = db.Countries.Local.First(c => c.label == "BR").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "BS", rawCoordinate = "+2505-07721", label = "America/Nassau", countryId = db.Countries.Local.First(c => c.label == "BS").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "BT", rawCoordinate = "+2728+08939", label = "Asia/Thimphu", countryId = db.Countries.Local.First(c => c.label == "BT").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "BW", rawCoordinate = "-2439+02555", label = "Africa/Gaborone", countryId = db.Countries.Local.First(c => c.label == "BW").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "BY", rawCoordinate = "+5354+02734", label = "Europe/Minsk", countryId = db.Countries.Local.First(c => c.label == "BY").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "BZ", rawCoordinate = "+1730-08812", label = "America/Belize", countryId = db.Countries.Local.First(c => c.label == "BZ").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CA", rawCoordinate = "+4734-05243", label = "America/St_Johns", comments = "Newfoundland Time, including SE Labrador", countryId = db.Countries.Local.First(c => c.label == "CA").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CA", rawCoordinate = "+4439-06336", label = "America/Halifax", comments = "Atlantic Time - Nova Scotia (most places), PEI", countryId = db.Countries.Local.First(c => c.label == "CA").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CA", rawCoordinate = "+4612-05957", label = "America/Glace_Bay", comments = "Atlantic Time - Nova Scotia - places that did not observe DST 1966-1971", countryId = db.Countries.Local.First(c => c.label == "CA").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CA", rawCoordinate = "+4606-06447", label = "America/Moncton", comments = "Atlantic Time - New Brunswick", countryId = db.Countries.Local.First(c => c.label == "CA").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CA", rawCoordinate = "+5320-06025", label = "America/Goose_Bay", comments = "Atlantic Time - Labrador - most locations", countryId = db.Countries.Local.First(c => c.label == "CA").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CA", rawCoordinate = "+5125-05707", label = "America/Blanc-Sablon", comments = "Atlantic Standard Time - Quebec - Lower North Shore", countryId = db.Countries.Local.First(c => c.label == "CA").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CA", rawCoordinate = "+4339-07923", label = "America/Toronto", comments = "Eastern Time - Ontario & Quebec - most locations", countryId = db.Countries.Local.First(c => c.label == "CA").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CA", rawCoordinate = "+4901-08816", label = "America/Nipigon", comments = "Eastern Time - Ontario & Quebec - places that did not observe DST 1967-1973", countryId = db.Countries.Local.First(c => c.label == "CA").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CA", rawCoordinate = "+4823-08915", label = "America/Thunder_Bay", comments = "Eastern Time - Thunder Bay, Ontario", countryId = db.Countries.Local.First(c => c.label == "CA").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CA", rawCoordinate = "+6344-06828", label = "America/Iqaluit", comments = "Eastern Time - east Nunavut - most locations", countryId = db.Countries.Local.First(c => c.label == "CA").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CA", rawCoordinate = "+6608-06544", label = "America/Pangnirtung", comments = "Eastern Time - Pangnirtung, Nunavut", countryId = db.Countries.Local.First(c => c.label == "CA").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CA", rawCoordinate = "+744144-0944945", label = "America/Resolute", comments = "Central Standard Time - Resolute, Nunavut", countryId = db.Countries.Local.First(c => c.label == "CA").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CA", rawCoordinate = "+484531-0913718", label = "America/Atikokan", comments = "Eastern Standard Time - Atikokan, Ontario and Southampton I, Nunavut", countryId = db.Countries.Local.First(c => c.label == "CA").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CA", rawCoordinate = "+624900-0920459", label = "America/Rankin_Inlet", comments = "Central Time - central Nunavut", countryId = db.Countries.Local.First(c => c.label == "CA").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CA", rawCoordinate = "+4953-09709", label = "America/Winnipeg", comments = "Central Time - Manitoba & west Ontario", countryId = db.Countries.Local.First(c => c.label == "CA").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CA", rawCoordinate = "+4843-09434", label = "America/Rainy_River", comments = "Central Time - Rainy River & Fort Frances, Ontario", countryId = db.Countries.Local.First(c => c.label == "CA").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CA", rawCoordinate = "+5024-10439", label = "America/Regina", comments = "Central Standard Time - Saskatchewan - most locations", countryId = db.Countries.Local.First(c => c.label == "CA").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CA", rawCoordinate = "+5017-10750", label = "America/Swift_Current", comments = "Central Standard Time - Saskatchewan - midwest", countryId = db.Countries.Local.First(c => c.label == "CA").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CA", rawCoordinate = "+5333-11328", label = "America/Edmonton", comments = "Mountain Time - Alberta, east British Columbia & west Saskatchewan", countryId = db.Countries.Local.First(c => c.label == "CA").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CA", rawCoordinate = "+690650-1050310", label = "America/Cambridge_Bay", comments = "Mountain Time - west Nunavut", countryId = db.Countries.Local.First(c => c.label == "CA").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CA", rawCoordinate = "+6227-11421", label = "America/Yellowknife", comments = "Mountain Time - central Northwest Territories", countryId = db.Countries.Local.First(c => c.label == "CA").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CA", rawCoordinate = "+682059-1334300", label = "America/Inuvik", comments = "Mountain Time - west Northwest Territories", countryId = db.Countries.Local.First(c => c.label == "CA").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CA", rawCoordinate = "+4906-11631", label = "America/Creston", comments = "Mountain Standard Time - Creston, British Columbia", countryId = db.Countries.Local.First(c => c.label == "CA").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CA", rawCoordinate = "+5946-12014", label = "America/Dawson_Creek", comments = "Mountain Standard Time - Dawson Creek & Fort Saint John, British Columbia", countryId = db.Countries.Local.First(c => c.label == "CA").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CA", rawCoordinate = "+4916-12307", label = "America/Vancouver", comments = "Pacific Time - west British Columbia", countryId = db.Countries.Local.First(c => c.label == "CA").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CA", rawCoordinate = "+6043-13503", label = "America/Whitehorse", comments = "Pacific Time - south Yukon", countryId = db.Countries.Local.First(c => c.label == "CA").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CA", rawCoordinate = "+6404-13925", label = "America/Dawson", comments = "Pacific Time - north Yukon", countryId = db.Countries.Local.First(c => c.label == "CA").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CC", rawCoordinate = "-1210+09655", label = "Indian/Cocos", countryId = db.Countries.Local.First(c => c.label == "CC").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CD", rawCoordinate = "-0418+01518", label = "Africa/Kinshasa", comments = "west Dem. Rep. of Congo", countryId = db.Countries.Local.First(c => c.label == "CD").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CD", rawCoordinate = "-1140+02728", label = "Africa/Lubumbashi", comments = "east Dem. Rep. of Congo", countryId = db.Countries.Local.First(c => c.label == "CD").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CF", rawCoordinate = "+0422+01835", label = "Africa/Bangui", countryId = db.Countries.Local.First(c => c.label == "CF").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CG", rawCoordinate = "-0416+01517", label = "Africa/Brazzaville", countryId = db.Countries.Local.First(c => c.label == "CG").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CH", rawCoordinate = "+4723+00832", label = "Europe/Zurich", countryId = db.Countries.Local.First(c => c.label == "CH").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CI", rawCoordinate = "+0519-00402", label = "Africa/Abidjan", countryId = db.Countries.Local.First(c => c.label == "CI").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CK", rawCoordinate = "-2114-15946", label = "Pacific/Rarotonga", countryId = db.Countries.Local.First(c => c.label == "CK").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CL", rawCoordinate = "-3327-07040", label = "America/Santiago", comments = "most locations", countryId = db.Countries.Local.First(c => c.label == "CL").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CL", rawCoordinate = "-2709-10926", label = "Pacific/Easter", comments = "Easter Island & Sala y Gomez", countryId = db.Countries.Local.First(c => c.label == "CL").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CM", rawCoordinate = "+0403+00942", label = "Africa/Douala", countryId = db.Countries.Local.First(c => c.label == "CM").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CN", rawCoordinate = "+3114+12128", label = "Asia/Shanghai", comments = "east China - Beijing, Guangdong, Shanghai, etc.", countryId = db.Countries.Local.First(c => c.label == "CN").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CN", rawCoordinate = "+4545+12641", label = "Asia/Harbin", comments = "Heilongjiang (except Mohe), Jilin", countryId = db.Countries.Local.First(c => c.label == "CN").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CN", rawCoordinate = "+2934+10635", label = "Asia/Chongqing", comments = "central China - Sichuan, Yunnan, Guangxi, Shaanxi, Guizhou, etc.", countryId = db.Countries.Local.First(c => c.label == "CN").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CN", rawCoordinate = "+4348+08735", label = "Asia/Urumqi", comments = "most of Tibet & Xinjiang", countryId = db.Countries.Local.First(c => c.label == "CN").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CN", rawCoordinate = "+3929+07559", label = "Asia/Kashgar", comments = "west Tibet & Xinjiang", countryId = db.Countries.Local.First(c => c.label == "CN").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CO", rawCoordinate = "+0436-07405", label = "America/Bogota", countryId = db.Countries.Local.First(c => c.label == "CO").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CR", rawCoordinate = "+0956-08405", label = "America/Costa_Rica", countryId = db.Countries.Local.First(c => c.label == "CR").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CU", rawCoordinate = "+2308-08222", label = "America/Havana", countryId = db.Countries.Local.First(c => c.label == "CU").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CV", rawCoordinate = "+1455-02331", label = "Atlantic/Cape_Verde", countryId = db.Countries.Local.First(c => c.label == "CV").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CW", rawCoordinate = "+1211-06900", label = "America/Curacao", countryId = db.Countries.Local.First(c => c.label == "CW").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CX", rawCoordinate = "-1025+10543", label = "Indian/Christmas", countryId = db.Countries.Local.First(c => c.label == "CX").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CY", rawCoordinate = "+3510+03322", label = "Asia/Nicosia", countryId = db.Countries.Local.First(c => c.label == "CY").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "CZ", rawCoordinate = "+5005+01426", label = "Europe/Prague", countryId = db.Countries.Local.First(c => c.label == "CZ").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "DE", rawCoordinate = "+5230+01322", label = "Europe/Berlin", comments = "most locations", countryId = db.Countries.Local.First(c => c.label == "DE").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "DE", rawCoordinate = "+4742+00841", label = "Europe/Busingen", comments = "Busingen", countryId = db.Countries.Local.First(c => c.label == "DE").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "DJ", rawCoordinate = "+1136+04309", label = "Africa/Djibouti", countryId = db.Countries.Local.First(c => c.label == "DJ").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "DK", rawCoordinate = "+5540+01235", label = "Europe/Copenhagen", countryId = db.Countries.Local.First(c => c.label == "DK").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "DM", rawCoordinate = "+1518-06124", label = "America/Dominica", countryId = db.Countries.Local.First(c => c.label == "DM").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "DO", rawCoordinate = "+1828-06954", label = "America/Santo_Domingo", countryId = db.Countries.Local.First(c => c.label == "DO").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "DZ", rawCoordinate = "+3647+00303", label = "Africa/Algiers", countryId = db.Countries.Local.First(c => c.label == "DZ").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "EC", rawCoordinate = "-0210-07950", label = "America/Guayaquil", comments = "mainland", countryId = db.Countries.Local.First(c => c.label == "EC").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "EC", rawCoordinate = "-0054-08936", label = "Pacific/Galapagos", comments = "Galapagos Islands", countryId = db.Countries.Local.First(c => c.label == "EC").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "EE", rawCoordinate = "+5925+02445", label = "Europe/Tallinn", countryId = db.Countries.Local.First(c => c.label == "EE").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "EG", rawCoordinate = "+3003+03115", label = "Africa/Cairo", countryId = db.Countries.Local.First(c => c.label == "EG").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "EH", rawCoordinate = "+2709-01312", label = "Africa/El_Aaiun", countryId = db.Countries.Local.First(c => c.label == "EH").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "ER", rawCoordinate = "+1520+03853", label = "Africa/Asmara", countryId = db.Countries.Local.First(c => c.label == "ER").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "ES", rawCoordinate = "+4024-00341", label = "Europe/Madrid", comments = "mainland", countryId = db.Countries.Local.First(c => c.label == "ES").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "ES", rawCoordinate = "+3553-00519", label = "Africa/Ceuta", comments = "Ceuta & Melilla", countryId = db.Countries.Local.First(c => c.label == "ES").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "ES", rawCoordinate = "+2806-01524", label = "Atlantic/Canary", comments = "Canary Islands", countryId = db.Countries.Local.First(c => c.label == "ES").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "ET", rawCoordinate = "+0902+03842", label = "Africa/Addis_Ababa", countryId = db.Countries.Local.First(c => c.label == "ET").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "FI", rawCoordinate = "+6010+02458", label = "Europe/Helsinki", countryId = db.Countries.Local.First(c => c.label == "FI").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "FJ", rawCoordinate = "-1808+17825", label = "Pacific/Fiji", countryId = db.Countries.Local.First(c => c.label == "FJ").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "FK", rawCoordinate = "-5142-05751", label = "Atlantic/Stanley", countryId = db.Countries.Local.First(c => c.label == "FK").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "FM", rawCoordinate = "+0725+15147", label = "Pacific/Chuuk", comments = "Chuuk (Truk) and Yap", countryId = db.Countries.Local.First(c => c.label == "FM").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "FM", rawCoordinate = "+0658+15813", label = "Pacific/Pohnpei", comments = "Pohnpei (Ponape)", countryId = db.Countries.Local.First(c => c.label == "FM").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "FM", rawCoordinate = "+0519+16259", label = "Pacific/Kosrae", comments = "Kosrae", countryId = db.Countries.Local.First(c => c.label == "FM").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "FO", rawCoordinate = "+6201-00646", label = "Atlantic/Faroe", countryId = db.Countries.Local.First(c => c.label == "FO").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "FR", rawCoordinate = "+4852+00220", label = "Europe/Paris", countryId = db.Countries.Local.First(c => c.label == "FR").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "GA", rawCoordinate = "+0023+00927", label = "Africa/Libreville", countryId = db.Countries.Local.First(c => c.label == "GA").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "GB", rawCoordinate = "+513030-0000731", label = "Europe/London", countryId = db.Countries.Local.First(c => c.label == "GB").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "GD", rawCoordinate = "+1203-06145", label = "America/Grenada", countryId = db.Countries.Local.First(c => c.label == "GD").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "GE", rawCoordinate = "+4143+04449", label = "Asia/Tbilisi", countryId = db.Countries.Local.First(c => c.label == "GE").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "GF", rawCoordinate = "+0456-05220", label = "America/Cayenne", countryId = db.Countries.Local.First(c => c.label == "GF").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "GG", rawCoordinate = "+4927-00232", label = "Europe/Guernsey", countryId = db.Countries.Local.First(c => c.label == "GG").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "GH", rawCoordinate = "+0533-00013", label = "Africa/Accra", countryId = db.Countries.Local.First(c => c.label == "GH").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "GI", rawCoordinate = "+3608-00521", label = "Europe/Gibraltar", countryId = db.Countries.Local.First(c => c.label == "GI").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "GL", rawCoordinate = "+6411-05144", label = "America/Godthab", comments = "most locations", countryId = db.Countries.Local.First(c => c.label == "GL").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "GL", rawCoordinate = "+7646-01840", label = "America/Danmarkshavn", comments = "east coast, north of Scoresbysund", countryId = db.Countries.Local.First(c => c.label == "GL").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "GL", rawCoordinate = "+7029-02158", label = "America/Scoresbysund", comments = "Scoresbysund / Ittoqqortoormiit", countryId = db.Countries.Local.First(c => c.label == "GL").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "GL", rawCoordinate = "+7634-06847", label = "America/Thule", comments = "Thule / Pituffik", countryId = db.Countries.Local.First(c => c.label == "GL").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "GM", rawCoordinate = "+1328-01639", label = "Africa/Banjul", countryId = db.Countries.Local.First(c => c.label == "GM").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "GN", rawCoordinate = "+0931-01343", label = "Africa/Conakry", countryId = db.Countries.Local.First(c => c.label == "GN").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "GP", rawCoordinate = "+1614-06132", label = "America/Guadeloupe", countryId = db.Countries.Local.First(c => c.label == "GP").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "GQ", rawCoordinate = "+0345+00847", label = "Africa/Malabo", countryId = db.Countries.Local.First(c => c.label == "GQ").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "GR", rawCoordinate = "+3758+02343", label = "Europe/Athens", countryId = db.Countries.Local.First(c => c.label == "GR").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "GS", rawCoordinate = "-5416-03632", label = "Atlantic/South_Georgia", countryId = db.Countries.Local.First(c => c.label == "GS").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "GT", rawCoordinate = "+1438-09031", label = "America/Guatemala", countryId = db.Countries.Local.First(c => c.label == "GT").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "GU", rawCoordinate = "+1328+14445", label = "Pacific/Guam", countryId = db.Countries.Local.First(c => c.label == "GU").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "GW", rawCoordinate = "+1151-01535", label = "Africa/Bissau", countryId = db.Countries.Local.First(c => c.label == "GW").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "GY", rawCoordinate = "+0648-05810", label = "America/Guyana", countryId = db.Countries.Local.First(c => c.label == "GY").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "HK", rawCoordinate = "+2217+11409", label = "Asia/Hong_Kong", countryId = db.Countries.Local.First(c => c.label == "HK").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "HN", rawCoordinate = "+1406-08713", label = "America/Tegucigalpa", countryId = db.Countries.Local.First(c => c.label == "HN").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "HR", rawCoordinate = "+4548+01558", label = "Europe/Zagreb", countryId = db.Countries.Local.First(c => c.label == "HR").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "HT", rawCoordinate = "+1832-07220", label = "America/Port-au-Prince", countryId = db.Countries.Local.First(c => c.label == "HT").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "HU", rawCoordinate = "+4730+01905", label = "Europe/Budapest", countryId = db.Countries.Local.First(c => c.label == "HU").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "ID", rawCoordinate = "-0610+10648", label = "Asia/Jakarta", comments = "Java & Sumatra", countryId = db.Countries.Local.First(c => c.label == "ID").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "ID", rawCoordinate = "-0002+10920", label = "Asia/Pontianak", comments = "west & central Borneo", countryId = db.Countries.Local.First(c => c.label == "ID").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "ID", rawCoordinate = "-0507+11924", label = "Asia/Makassar", comments = "east & south Borneo, Sulawesi (Celebes), Bali, Nusa Tengarra, west Timor", countryId = db.Countries.Local.First(c => c.label == "ID").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "ID", rawCoordinate = "-0232+14042", label = "Asia/Jayapura", comments = "west New Guinea (Irian Jaya) & Malukus (Moluccas)", countryId = db.Countries.Local.First(c => c.label == "ID").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "IE", rawCoordinate = "+5320-00615", label = "Europe/Dublin", countryId = db.Countries.Local.First(c => c.label == "IE").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "IL", rawCoordinate = "+314650+0351326", label = "Asia/Jerusalem", countryId = db.Countries.Local.First(c => c.label == "IL").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "IM", rawCoordinate = "+5409-00428", label = "Europe/Isle_of_Man", countryId = db.Countries.Local.First(c => c.label == "IM").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "IN", rawCoordinate = "+2232+08822", label = "Asia/Kolkata", countryId = db.Countries.Local.First(c => c.label == "IN").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "IO", rawCoordinate = "-0720+07225", label = "Indian/Chagos", countryId = db.Countries.Local.First(c => c.label == "IO").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "IQ", rawCoordinate = "+3321+04425", label = "Asia/Baghdad", countryId = db.Countries.Local.First(c => c.label == "IQ").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "IR", rawCoordinate = "+3540+05126", label = "Asia/Tehran", countryId = db.Countries.Local.First(c => c.label == "IR").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "IS", rawCoordinate = "+6409-02151", label = "Atlantic/Reykjavik", countryId = db.Countries.Local.First(c => c.label == "IS").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "IT", rawCoordinate = "+4154+01229", label = "Europe/Rome", countryId = db.Countries.Local.First(c => c.label == "IT").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "JE", rawCoordinate = "+4912-00207", label = "Europe/Jersey", countryId = db.Countries.Local.First(c => c.label == "JE").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "JM", rawCoordinate = "+175805-0764736", label = "America/Jamaica", countryId = db.Countries.Local.First(c => c.label == "JM").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "JO", rawCoordinate = "+3157+03556", label = "Asia/Amman", countryId = db.Countries.Local.First(c => c.label == "JO").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "JP", rawCoordinate = "+353916+1394441", label = "Asia/Tokyo", countryId = db.Countries.Local.First(c => c.label == "JP").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "KE", rawCoordinate = "-0117+03649", label = "Africa/Nairobi", countryId = db.Countries.Local.First(c => c.label == "KE").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "KG", rawCoordinate = "+4254+07436", label = "Asia/Bishkek", countryId = db.Countries.Local.First(c => c.label == "KG").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "KH", rawCoordinate = "+1133+10455", label = "Asia/Phnom_Penh", countryId = db.Countries.Local.First(c => c.label == "KH").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "KI", rawCoordinate = "+0125+17300", label = "Pacific/Tarawa", comments = "Gilbert Islands", countryId = db.Countries.Local.First(c => c.label == "KI").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "KI", rawCoordinate = "-0308-17105", label = "Pacific/Enderbury", comments = "Phoenix Islands", countryId = db.Countries.Local.First(c => c.label == "KI").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "KI", rawCoordinate = "+0152-15720", label = "Pacific/Kiritimati", comments = "Line Islands", countryId = db.Countries.Local.First(c => c.label == "KI").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "KM", rawCoordinate = "-1141+04316", label = "Indian/Comoro", countryId = db.Countries.Local.First(c => c.label == "KM").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "KN", rawCoordinate = "+1718-06243", label = "America/St_Kitts", countryId = db.Countries.Local.First(c => c.label == "KN").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "KP", rawCoordinate = "+3901+12545", label = "Asia/Pyongyang", countryId = db.Countries.Local.First(c => c.label == "KP").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "KR", rawCoordinate = "+3733+12658", label = "Asia/Seoul", countryId = db.Countries.Local.First(c => c.label == "KR").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "KW", rawCoordinate = "+2920+04759", label = "Asia/Kuwait", countryId = db.Countries.Local.First(c => c.label == "KW").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "KY", rawCoordinate = "+1918-08123", label = "America/Cayman", countryId = db.Countries.Local.First(c => c.label == "KY").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "KZ", rawCoordinate = "+4315+07657", label = "Asia/Almaty", comments = "most locations", countryId = db.Countries.Local.First(c => c.label == "KZ").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "KZ", rawCoordinate = "+4448+06528", label = "Asia/Qyzylorda", comments = "Qyzylorda (Kyzylorda, Kzyl-Orda)", countryId = db.Countries.Local.First(c => c.label == "KZ").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "KZ", rawCoordinate = "+5017+05710", label = "Asia/Aqtobe", comments = "Aqtobe (Aktobe)", countryId = db.Countries.Local.First(c => c.label == "KZ").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "KZ", rawCoordinate = "+4431+05016", label = "Asia/Aqtau", comments = "Atyrau (Atirau, Gur'yev), Mangghystau (Mankistau)", countryId = db.Countries.Local.First(c => c.label == "KZ").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "KZ", rawCoordinate = "+5113+05121", label = "Asia/Oral", comments = "West Kazakhstan", countryId = db.Countries.Local.First(c => c.label == "KZ").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "LA", rawCoordinate = "+1758+10236", label = "Asia/Vientiane", countryId = db.Countries.Local.First(c => c.label == "LA").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "LB", rawCoordinate = "+3353+03530", label = "Asia/Beirut", countryId = db.Countries.Local.First(c => c.label == "LB").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "LC", rawCoordinate = "+1401-06100", label = "America/St_Lucia", countryId = db.Countries.Local.First(c => c.label == "LC").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "LI", rawCoordinate = "+4709+00931", label = "Europe/Vaduz", countryId = db.Countries.Local.First(c => c.label == "LI").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "LK", rawCoordinate = "+0656+07951", label = "Asia/Colombo", countryId = db.Countries.Local.First(c => c.label == "LK").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "LR", rawCoordinate = "+0618-01047", label = "Africa/Monrovia", countryId = db.Countries.Local.First(c => c.label == "LR").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "LS", rawCoordinate = "-2928+02730", label = "Africa/Maseru", countryId = db.Countries.Local.First(c => c.label == "LS").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "LT", rawCoordinate = "+5441+02519", label = "Europe/Vilnius", countryId = db.Countries.Local.First(c => c.label == "LT").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "LU", rawCoordinate = "+4936+00609", label = "Europe/Luxembourg", countryId = db.Countries.Local.First(c => c.label == "LU").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "LV", rawCoordinate = "+5657+02406", label = "Europe/Riga", countryId = db.Countries.Local.First(c => c.label == "LV").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "LY", rawCoordinate = "+3254+01311", label = "Africa/Tripoli", countryId = db.Countries.Local.First(c => c.label == "LY").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "MA", rawCoordinate = "+3339-00735", label = "Africa/Casablanca", countryId = db.Countries.Local.First(c => c.label == "MA").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "MC", rawCoordinate = "+4342+00723", label = "Europe/Monaco", countryId = db.Countries.Local.First(c => c.label == "MC").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "MD", rawCoordinate = "+4700+02850", label = "Europe/Chisinau", countryId = db.Countries.Local.First(c => c.label == "MD").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "ME", rawCoordinate = "+4226+01916", label = "Europe/Podgorica", countryId = db.Countries.Local.First(c => c.label == "ME").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "MF", rawCoordinate = "+1804-06305", label = "America/Marigot", countryId = db.Countries.Local.First(c => c.label == "MF").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "MG", rawCoordinate = "-1855+04731", label = "Indian/Antananarivo", countryId = db.Countries.Local.First(c => c.label == "MG").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "MH", rawCoordinate = "+0709+17112", label = "Pacific/Majuro", comments = "most locations", countryId = db.Countries.Local.First(c => c.label == "MH").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "MH", rawCoordinate = "+0905+16720", label = "Pacific/Kwajalein", comments = "Kwajalein", countryId = db.Countries.Local.First(c => c.label == "MH").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "MK", rawCoordinate = "+4159+02126", label = "Europe/Skopje", countryId = db.Countries.Local.First(c => c.label == "MK").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "ML", rawCoordinate = "+1239-00800", label = "Africa/Bamako", countryId = db.Countries.Local.First(c => c.label == "ML").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "MM", rawCoordinate = "+1647+09610", label = "Asia/Rangoon", countryId = db.Countries.Local.First(c => c.label == "MM").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "MN", rawCoordinate = "+4755+10653", label = "Asia/Ulaanbaatar", comments = "most locations", countryId = db.Countries.Local.First(c => c.label == "MN").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "MN", rawCoordinate = "+4801+09139", label = "Asia/Hovd", comments = "Bayan-Olgiy, Govi-Altai, Hovd, Uvs, Zavkhan", countryId = db.Countries.Local.First(c => c.label == "MN").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "MN", rawCoordinate = "+4804+11430", label = "Asia/Choibalsan", comments = "Dornod, Sukhbaatar", countryId = db.Countries.Local.First(c => c.label == "MN").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "MO", rawCoordinate = "+2214+11335", label = "Asia/Macau", countryId = db.Countries.Local.First(c => c.label == "MO").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "MP", rawCoordinate = "+1512+14545", label = "Pacific/Saipan", countryId = db.Countries.Local.First(c => c.label == "MP").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "MQ", rawCoordinate = "+1436-06105", label = "America/Martinique", countryId = db.Countries.Local.First(c => c.label == "MQ").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "MR", rawCoordinate = "+1806-01557", label = "Africa/Nouakchott", countryId = db.Countries.Local.First(c => c.label == "MR").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "MS", rawCoordinate = "+1643-06213", label = "America/Montserrat", countryId = db.Countries.Local.First(c => c.label == "MS").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "MT", rawCoordinate = "+3554+01431", label = "Europe/Malta", countryId = db.Countries.Local.First(c => c.label == "MT").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "MU", rawCoordinate = "-2010+05730", label = "Indian/Mauritius", countryId = db.Countries.Local.First(c => c.label == "MU").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "MV", rawCoordinate = "+0410+07330", label = "Indian/Maldives", countryId = db.Countries.Local.First(c => c.label == "MV").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "MW", rawCoordinate = "-1547+03500", label = "Africa/Blantyre", countryId = db.Countries.Local.First(c => c.label == "MW").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "MX", rawCoordinate = "+1924-09909", label = "America/Mexico_City", comments = "Central Time - most locations", countryId = db.Countries.Local.First(c => c.label == "MX").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "MX", rawCoordinate = "+2105-08646", label = "America/Cancun", comments = "Central Time - Quintana Roo", countryId = db.Countries.Local.First(c => c.label == "MX").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "MX", rawCoordinate = "+2058-08937", label = "America/Merida", comments = "Central Time - Campeche, Yucatan", countryId = db.Countries.Local.First(c => c.label == "MX").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "MX", rawCoordinate = "+2540-10019", label = "America/Monterrey", comments = "Mexican Central Time - Coahuila, Durango, Nuevo Leon, Tamaulipas away from US border", countryId = db.Countries.Local.First(c => c.label == "MX").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "MX", rawCoordinate = "+2550-09730", label = "America/Matamoros", comments = "US Central Time - Coahuila, Durango, Nuevo Leon, Tamaulipas near US border", countryId = db.Countries.Local.First(c => c.label == "MX").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "MX", rawCoordinate = "+2313-10625", label = "America/Mazatlan", comments = "Mountain Time - S Baja, Nayarit, Sinaloa", countryId = db.Countries.Local.First(c => c.label == "MX").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "MX", rawCoordinate = "+2838-10605", label = "America/Chihuahua", comments = "Mexican Mountain Time - Chihuahua away from US border", countryId = db.Countries.Local.First(c => c.label == "MX").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "MX", rawCoordinate = "+2934-10425", label = "America/Ojinaga", comments = "US Mountain Time - Chihuahua near US border", countryId = db.Countries.Local.First(c => c.label == "MX").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "MX", rawCoordinate = "+2904-11058", label = "America/Hermosillo", comments = "Mountain Standard Time - Sonora", countryId = db.Countries.Local.First(c => c.label == "MX").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "MX", rawCoordinate = "+3232-11701", label = "America/Tijuana", comments = "US Pacific Time - Baja California near US border", countryId = db.Countries.Local.First(c => c.label == "MX").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "MX", rawCoordinate = "+3018-11452", label = "America/Santa_Isabel", comments = "Mexican Pacific Time - Baja California away from US border", countryId = db.Countries.Local.First(c => c.label == "MX").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "MX", rawCoordinate = "+2048-10515", label = "America/Bahia_Banderas", comments = "Mexican Central Time - Bahia de Banderas", countryId = db.Countries.Local.First(c => c.label == "MX").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "MY", rawCoordinate = "+0310+10142", label = "Asia/Kuala_Lumpur", comments = "peninsular Malaysia", countryId = db.Countries.Local.First(c => c.label == "MY").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "MY", rawCoordinate = "+0133+11020", label = "Asia/Kuching", comments = "Sabah & Sarawak", countryId = db.Countries.Local.First(c => c.label == "MY").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "MZ", rawCoordinate = "-2558+03235", label = "Africa/Maputo", countryId = db.Countries.Local.First(c => c.label == "MZ").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "NA", rawCoordinate = "-2234+01706", label = "Africa/Windhoek", countryId = db.Countries.Local.First(c => c.label == "NA").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "NC", rawCoordinate = "-2216+16627", label = "Pacific/Noumea", countryId = db.Countries.Local.First(c => c.label == "NC").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "NE", rawCoordinate = "+1331+00207", label = "Africa/Niamey", countryId = db.Countries.Local.First(c => c.label == "NE").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "NF", rawCoordinate = "-2903+16758", label = "Pacific/Norfolk", countryId = db.Countries.Local.First(c => c.label == "NF").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "NG", rawCoordinate = "+0627+00324", label = "Africa/Lagos", countryId = db.Countries.Local.First(c => c.label == "NG").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "NI", rawCoordinate = "+1209-08617", label = "America/Managua", countryId = db.Countries.Local.First(c => c.label == "NI").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "NL", rawCoordinate = "+5222+00454", label = "Europe/Amsterdam", countryId = db.Countries.Local.First(c => c.label == "NL").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "NO", rawCoordinate = "+5955+01045", label = "Europe/Oslo", countryId = db.Countries.Local.First(c => c.label == "NO").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "NP", rawCoordinate = "+2743+08519", label = "Asia/Kathmandu", countryId = db.Countries.Local.First(c => c.label == "NP").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "NR", rawCoordinate = "-0031+16655", label = "Pacific/Nauru", countryId = db.Countries.Local.First(c => c.label == "NR").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "NU", rawCoordinate = "-1901-16955", label = "Pacific/Niue", countryId = db.Countries.Local.First(c => c.label == "NU").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "NZ", rawCoordinate = "-3652+17446", label = "Pacific/Auckland", comments = "most locations", countryId = db.Countries.Local.First(c => c.label == "NZ").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "NZ", rawCoordinate = "-4357-17633", label = "Pacific/Chatham", comments = "Chatham Islands", countryId = db.Countries.Local.First(c => c.label == "NZ").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "OM", rawCoordinate = "+2336+05835", label = "Asia/Muscat", countryId = db.Countries.Local.First(c => c.label == "OM").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "PA", rawCoordinate = "+0858-07932", label = "America/Panama", countryId = db.Countries.Local.First(c => c.label == "PA").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "PE", rawCoordinate = "-1203-07703", label = "America/Lima", countryId = db.Countries.Local.First(c => c.label == "PE").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "PF", rawCoordinate = "-1732-14934", label = "Pacific/Tahiti", comments = "Society Islands", countryId = db.Countries.Local.First(c => c.label == "PF").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "PF", rawCoordinate = "-0900-13930", label = "Pacific/Marquesas", comments = "Marquesas Islands", countryId = db.Countries.Local.First(c => c.label == "PF").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "PF", rawCoordinate = "-2308-13457", label = "Pacific/Gambier", comments = "Gambier Islands", countryId = db.Countries.Local.First(c => c.label == "PF").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "PG", rawCoordinate = "-0930+14710", label = "Pacific/Port_Moresby", countryId = db.Countries.Local.First(c => c.label == "PG").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "PH", rawCoordinate = "+1435+12100", label = "Asia/Manila", countryId = db.Countries.Local.First(c => c.label == "PH").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "PK", rawCoordinate = "+2452+06703", label = "Asia/Karachi", countryId = db.Countries.Local.First(c => c.label == "PK").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "PL", rawCoordinate = "+5215+02100", label = "Europe/Warsaw", countryId = db.Countries.Local.First(c => c.label == "PL").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "PM", rawCoordinate = "+4703-05620", label = "America/Miquelon", countryId = db.Countries.Local.First(c => c.label == "PM").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "PN", rawCoordinate = "-2504-13005", label = "Pacific/Pitcairn", countryId = db.Countries.Local.First(c => c.label == "PN").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "PR", rawCoordinate = "+182806-0660622", label = "America/Puerto_Rico", countryId = db.Countries.Local.First(c => c.label == "PR").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "PS", rawCoordinate = "+3130+03428", label = "Asia/Gaza", comments = "Gaza Strip", countryId = db.Countries.Local.First(c => c.label == "PS").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "PS", rawCoordinate = "+313200+0350542", label = "Asia/Hebron", comments = "West Bank", countryId = db.Countries.Local.First(c => c.label == "PS").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "PT", rawCoordinate = "+3843-00908", label = "Europe/Lisbon", comments = "mainland", countryId = db.Countries.Local.First(c => c.label == "PT").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "PT", rawCoordinate = "+3238-01654", label = "Atlantic/Madeira", comments = "Madeira Islands", countryId = db.Countries.Local.First(c => c.label == "PT").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "PT", rawCoordinate = "+3744-02540", label = "Atlantic/Azores", comments = "Azores", countryId = db.Countries.Local.First(c => c.label == "PT").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "PW", rawCoordinate = "+0720+13429", label = "Pacific/Palau", countryId = db.Countries.Local.First(c => c.label == "PW").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "PY", rawCoordinate = "-2516-05740", label = "America/Asuncion", countryId = db.Countries.Local.First(c => c.label == "PY").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "QA", rawCoordinate = "+2517+05132", label = "Asia/Qatar", countryId = db.Countries.Local.First(c => c.label == "QA").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "RE", rawCoordinate = "-2052+05528", label = "Indian/Reunion", countryId = db.Countries.Local.First(c => c.label == "RE").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "RO", rawCoordinate = "+4426+02606", label = "Europe/Bucharest", countryId = db.Countries.Local.First(c => c.label == "RO").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "RS", rawCoordinate = "+4450+02030", label = "Europe/Belgrade", countryId = db.Countries.Local.First(c => c.label == "RS").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "RU", rawCoordinate = "+5443+02030", label = "Europe/Kaliningrad", comments = "Moscow-01 - Kaliningrad", countryId = db.Countries.Local.First(c => c.label == "RU").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "RU", rawCoordinate = "+5545+03735", label = "Europe/Moscow", comments = "Moscow+00 - west Russia", countryId = db.Countries.Local.First(c => c.label == "RU").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "RU", rawCoordinate = "+4844+04425", label = "Europe/Volgograd", comments = "Moscow+00 - Caspian Sea", countryId = db.Countries.Local.First(c => c.label == "RU").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "RU", rawCoordinate = "+5312+05009", label = "Europe/Samara", comments = "Moscow+00 - Samara, Udmurtia", countryId = db.Countries.Local.First(c => c.label == "RU").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "RU", rawCoordinate = "+4457+03406", label = "Europe/Simferopol", comments = "Moscow+00 - Crimea", countryId = db.Countries.Local.First(c => c.label == "RU").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "RU", rawCoordinate = "+5651+06036", label = "Asia/Yekaterinburg", comments = "Moscow+02 - Urals", countryId = db.Countries.Local.First(c => c.label == "RU").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "RU", rawCoordinate = "+5500+07324", label = "Asia/Omsk", comments = "Moscow+03 - west Siberia", countryId = db.Countries.Local.First(c => c.label == "RU").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "RU", rawCoordinate = "+5502+08255", label = "Asia/Novosibirsk", comments = "Moscow+03 - Novosibirsk", countryId = db.Countries.Local.First(c => c.label == "RU").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "RU", rawCoordinate = "+5345+08707", label = "Asia/Novokuznetsk", comments = "Moscow+03 - Novokuznetsk", countryId = db.Countries.Local.First(c => c.label == "RU").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "RU", rawCoordinate = "+5601+09250", label = "Asia/Krasnoyarsk", comments = "Moscow+04 - Yenisei River", countryId = db.Countries.Local.First(c => c.label == "RU").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "RU", rawCoordinate = "+5216+10420", label = "Asia/Irkutsk", comments = "Moscow+05 - Lake Baikal", countryId = db.Countries.Local.First(c => c.label == "RU").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "RU", rawCoordinate = "+6200+12940", label = "Asia/Yakutsk", comments = "Moscow+06 - Lena River", countryId = db.Countries.Local.First(c => c.label == "RU").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "RU", rawCoordinate = "+623923+1353314", label = "Asia/Khandyga", comments = "Moscow+06 - Tomponsky, Ust-Maysky", countryId = db.Countries.Local.First(c => c.label == "RU").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "RU", rawCoordinate = "+4310+13156", label = "Asia/Vladivostok", comments = "Moscow+07 - Amur River", countryId = db.Countries.Local.First(c => c.label == "RU").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "RU", rawCoordinate = "+4658+14242", label = "Asia/Sakhalin", comments = "Moscow+07 - Sakhalin Island", countryId = db.Countries.Local.First(c => c.label == "RU").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "RU", rawCoordinate = "+643337+1431336", label = "Asia/Ust-Nera", comments = "Moscow+07 - Oymyakonsky", countryId = db.Countries.Local.First(c => c.label == "RU").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "RU", rawCoordinate = "+5934+15048", label = "Asia/Magadan", comments = "Moscow+08 - Magadan", countryId = db.Countries.Local.First(c => c.label == "RU").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "RU", rawCoordinate = "+5301+15839", label = "Asia/Kamchatka", comments = "Moscow+08 - Kamchatka", countryId = db.Countries.Local.First(c => c.label == "RU").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "RU", rawCoordinate = "+6445+17729", label = "Asia/Anadyr", comments = "Moscow+08 - Bering Sea", countryId = db.Countries.Local.First(c => c.label == "RU").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "RW", rawCoordinate = "-0157+03004", label = "Africa/Kigali", countryId = db.Countries.Local.First(c => c.label == "RW").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "SA", rawCoordinate = "+2438+04643", label = "Asia/Riyadh", countryId = db.Countries.Local.First(c => c.label == "SA").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "SB", rawCoordinate = "-0932+16012", label = "Pacific/Guadalcanal", countryId = db.Countries.Local.First(c => c.label == "SB").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "SC", rawCoordinate = "-0440+05528", label = "Indian/Mahe", countryId = db.Countries.Local.First(c => c.label == "SC").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "SD", rawCoordinate = "+1536+03232", label = "Africa/Khartoum", countryId = db.Countries.Local.First(c => c.label == "SD").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "SE", rawCoordinate = "+5920+01803", label = "Europe/Stockholm", countryId = db.Countries.Local.First(c => c.label == "SE").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "SG", rawCoordinate = "+0117+10351", label = "Asia/Singapore", countryId = db.Countries.Local.First(c => c.label == "SG").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "SH", rawCoordinate = "-1555-00542", label = "Atlantic/St_Helena", countryId = db.Countries.Local.First(c => c.label == "SH").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "SI", rawCoordinate = "+4603+01431", label = "Europe/Ljubljana", countryId = db.Countries.Local.First(c => c.label == "SI").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "SJ", rawCoordinate = "+7800+01600", label = "Arctic/Longyearbyen", countryId = db.Countries.Local.First(c => c.label == "SJ").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "SK", rawCoordinate = "+4809+01707", label = "Europe/Bratislava", countryId = db.Countries.Local.First(c => c.label == "SK").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "SL", rawCoordinate = "+0830-01315", label = "Africa/Freetown", countryId = db.Countries.Local.First(c => c.label == "SL").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "SM", rawCoordinate = "+4355+01228", label = "Europe/San_Marino", countryId = db.Countries.Local.First(c => c.label == "SM").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "SN", rawCoordinate = "+1440-01726", label = "Africa/Dakar", countryId = db.Countries.Local.First(c => c.label == "SN").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "SO", rawCoordinate = "+0204+04522", label = "Africa/Mogadishu", countryId = db.Countries.Local.First(c => c.label == "SO").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "SR", rawCoordinate = "+0550-05510", label = "America/Paramaribo", countryId = db.Countries.Local.First(c => c.label == "SR").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "SS", rawCoordinate = "+0451+03136", label = "Africa/Juba", countryId = db.Countries.Local.First(c => c.label == "SS").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "ST", rawCoordinate = "+0020+00644", label = "Africa/Sao_Tome", countryId = db.Countries.Local.First(c => c.label == "ST").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "SV", rawCoordinate = "+1342-08912", label = "America/El_Salvador", countryId = db.Countries.Local.First(c => c.label == "SV").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "SX", rawCoordinate = "+180305-0630250", label = "America/Lower_Princes", countryId = db.Countries.Local.First(c => c.label == "SX").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "SY", rawCoordinate = "+3330+03618", label = "Asia/Damascus", countryId = db.Countries.Local.First(c => c.label == "SY").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "SZ", rawCoordinate = "-2618+03106", label = "Africa/Mbabane", countryId = db.Countries.Local.First(c => c.label == "SZ").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "TC", rawCoordinate = "+2128-07108", label = "America/Grand_Turk", countryId = db.Countries.Local.First(c => c.label == "TC").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "TD", rawCoordinate = "+1207+01503", label = "Africa/Ndjamena", countryId = db.Countries.Local.First(c => c.label == "TD").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "TF", rawCoordinate = "-492110+0701303", label = "Indian/Kerguelen", countryId = db.Countries.Local.First(c => c.label == "TF").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "TG", rawCoordinate = "+0608+00113", label = "Africa/Lome", countryId = db.Countries.Local.First(c => c.label == "TG").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "TH", rawCoordinate = "+1345+10031", label = "Asia/Bangkok", countryId = db.Countries.Local.First(c => c.label == "TH").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "TJ", rawCoordinate = "+3835+06848", label = "Asia/Dushanbe", countryId = db.Countries.Local.First(c => c.label == "TJ").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "TK", rawCoordinate = "-0922-17114", label = "Pacific/Fakaofo", countryId = db.Countries.Local.First(c => c.label == "TK").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "TL", rawCoordinate = "-0833+12535", label = "Asia/Dili", countryId = db.Countries.Local.First(c => c.label == "TL").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "TM", rawCoordinate = "+3757+05823", label = "Asia/Ashgabat", countryId = db.Countries.Local.First(c => c.label == "TM").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "TN", rawCoordinate = "+3648+01011", label = "Africa/Tunis", countryId = db.Countries.Local.First(c => c.label == "TN").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "TO", rawCoordinate = "-2110-17510", label = "Pacific/Tongatapu", countryId = db.Countries.Local.First(c => c.label == "TO").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "TR", rawCoordinate = "+4101+02858", label = "Europe/Istanbul", countryId = db.Countries.Local.First(c => c.label == "TR").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "TT", rawCoordinate = "+1039-06131", label = "America/Port_of_Spain", countryId = db.Countries.Local.First(c => c.label == "TT").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "TV", rawCoordinate = "-0831+17913", label = "Pacific/Funafuti", countryId = db.Countries.Local.First(c => c.label == "TV").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "TW", rawCoordinate = "+2503+12130", label = "Asia/Taipei", countryId = db.Countries.Local.First(c => c.label == "TW").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "TZ", rawCoordinate = "-0648+03917", label = "Africa/Dar_es_Salaam", countryId = db.Countries.Local.First(c => c.label == "TZ").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "UA", rawCoordinate = "+5026+03031", label = "Europe/Kiev", comments = "most locations", countryId = db.Countries.Local.First(c => c.label == "UA").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "UA", rawCoordinate = "+4837+02218", label = "Europe/Uzhgorod", comments = "Ruthenia", countryId = db.Countries.Local.First(c => c.label == "UA").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "UA", rawCoordinate = "+4750+03510", label = "Europe/Zaporozhye", comments = "Zaporozh'ye, E Lugansk / Zaporizhia, E Luhansk", countryId = db.Countries.Local.First(c => c.label == "UA").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "UG", rawCoordinate = "+0019+03225", label = "Africa/Kampala", countryId = db.Countries.Local.First(c => c.label == "UG").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "UM", rawCoordinate = "+1645-16931", label = "Pacific/Johnston", comments = "Johnston Atoll", countryId = db.Countries.Local.First(c => c.label == "UM").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "UM", rawCoordinate = "+2813-17722", label = "Pacific/Midway", comments = "Midway Islands", countryId = db.Countries.Local.First(c => c.label == "UM").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "UM", rawCoordinate = "+1917+16637", label = "Pacific/Wake", comments = "Wake Island", countryId = db.Countries.Local.First(c => c.label == "UM").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "US", rawCoordinate = "+404251-0740023", label = "America/New_York", comments = "Eastern Time", countryId = db.Countries.Local.First(c => c.label == "US").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "US", rawCoordinate = "+421953-0830245", label = "America/Detroit", comments = "Eastern Time - Michigan - most locations", countryId = db.Countries.Local.First(c => c.label == "US").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "US", rawCoordinate = "+381515-0854534", label = "America/Kentucky/Louisville", comments = "Eastern Time - Kentucky - Louisville area", countryId = db.Countries.Local.First(c => c.label == "US").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "US", rawCoordinate = "+364947-0845057", label = "America/Kentucky/Monticello", comments = "Eastern Time - Kentucky - Wayne County", countryId = db.Countries.Local.First(c => c.label == "US").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "US", rawCoordinate = "+394606-0860929", label = "America/Indiana/Indianapolis", comments = "Eastern Time - Indiana - most locations", countryId = db.Countries.Local.First(c => c.label == "US").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "US", rawCoordinate = "+384038-0873143", label = "America/Indiana/Vincennes", comments = "Eastern Time - Indiana - Daviess, Dubois, Knox & Martin Counties", countryId = db.Countries.Local.First(c => c.label == "US").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "US", rawCoordinate = "+410305-0863611", label = "America/Indiana/Winamac", comments = "Eastern Time - Indiana - Pulaski County", countryId = db.Countries.Local.First(c => c.label == "US").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "US", rawCoordinate = "+382232-0862041", label = "America/Indiana/Marengo", comments = "Eastern Time - Indiana - Crawford County", countryId = db.Countries.Local.First(c => c.label == "US").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "US", rawCoordinate = "+382931-0871643", label = "America/Indiana/Petersburg", comments = "Eastern Time - Indiana - Pike County", countryId = db.Countries.Local.First(c => c.label == "US").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "US", rawCoordinate = "+384452-0850402", label = "America/Indiana/Vevay", comments = "Eastern Time - Indiana - Switzerland County", countryId = db.Countries.Local.First(c => c.label == "US").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "US", rawCoordinate = "+415100-0873900", label = "America/Chicago", comments = "Central Time", countryId = db.Countries.Local.First(c => c.label == "US").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "US", rawCoordinate = "+375711-0864541", label = "America/Indiana/Tell_City", comments = "Central Time - Indiana - Perry County", countryId = db.Countries.Local.First(c => c.label == "US").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "US", rawCoordinate = "+411745-0863730", label = "America/Indiana/Knox", comments = "Central Time - Indiana - Starke County", countryId = db.Countries.Local.First(c => c.label == "US").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "US", rawCoordinate = "+450628-0873651", label = "America/Menominee", comments = "Central Time - Michigan - Dickinson, Gogebic, Iron & Menominee Counties", countryId = db.Countries.Local.First(c => c.label == "US").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "US", rawCoordinate = "+470659-1011757", label = "America/North_Dakota/Center", comments = "Central Time - North Dakota - Oliver County", countryId = db.Countries.Local.First(c => c.label == "US").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "US", rawCoordinate = "+465042-1012439", label = "America/North_Dakota/New_Salem", comments = "Central Time - North Dakota - Morton County (except Mandan area)", countryId = db.Countries.Local.First(c => c.label == "US").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "US", rawCoordinate = "+471551-1014640", label = "America/North_Dakota/Beulah", comments = "Central Time - North Dakota - Mercer County", countryId = db.Countries.Local.First(c => c.label == "US").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "US", rawCoordinate = "+394421-1045903", label = "America/Denver", comments = "Mountain Time", countryId = db.Countries.Local.First(c => c.label == "US").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "US", rawCoordinate = "+433649-1161209", label = "America/Boise", comments = "Mountain Time - south Idaho & east Oregon", countryId = db.Countries.Local.First(c => c.label == "US").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "US", rawCoordinate = "+332654-1120424", label = "America/Phoenix", comments = "Mountain Standard Time - Arizona (except Navajo)", countryId = db.Countries.Local.First(c => c.label == "US").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "US", rawCoordinate = "+340308-1181434", label = "America/Los_Angeles", comments = "Pacific Time", countryId = db.Countries.Local.First(c => c.label == "US").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "US", rawCoordinate = "+611305-1495401", label = "America/Anchorage", comments = "Alaska Time", countryId = db.Countries.Local.First(c => c.label == "US").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "US", rawCoordinate = "+581807-1342511", label = "America/Juneau", comments = "Alaska Time - Alaska panhandle", countryId = db.Countries.Local.First(c => c.label == "US").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "US", rawCoordinate = "+571035-1351807", label = "America/Sitka", comments = "Alaska Time - southeast Alaska panhandle", countryId = db.Countries.Local.First(c => c.label == "US").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "US", rawCoordinate = "+593249-1394338", label = "America/Yakutat", comments = "Alaska Time - Alaska panhandle neck", countryId = db.Countries.Local.First(c => c.label == "US").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "US", rawCoordinate = "+643004-1652423", label = "America/Nome", comments = "Alaska Time - west Alaska", countryId = db.Countries.Local.First(c => c.label == "US").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "US", rawCoordinate = "+515248-1763929", label = "America/Adak", comments = "Aleutian Islands", countryId = db.Countries.Local.First(c => c.label == "US").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "US", rawCoordinate = "+550737-1313435", label = "America/Metlakatla", comments = "Metlakatla Time - Annette Island", countryId = db.Countries.Local.First(c => c.label == "US").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "US", rawCoordinate = "+211825-1575130", label = "Pacific/Honolulu", comments = "Hawaii", countryId = db.Countries.Local.First(c => c.label == "US").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "UY", rawCoordinate = "-3453-05611", label = "America/Montevideo", countryId = db.Countries.Local.First(c => c.label == "UY").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "UZ", rawCoordinate = "+3940+06648", label = "Asia/Samarkand", comments = "west Uzbekistan", countryId = db.Countries.Local.First(c => c.label == "UZ").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "UZ", rawCoordinate = "+4120+06918", label = "Asia/Tashkent", comments = "east Uzbekistan", countryId = db.Countries.Local.First(c => c.label == "UZ").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "VA", rawCoordinate = "+415408+0122711", label = "Europe/Vatican", countryId = db.Countries.Local.First(c => c.label == "VA").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "VC", rawCoordinate = "+1309-06114", label = "America/St_Vincent", countryId = db.Countries.Local.First(c => c.label == "VC").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "VE", rawCoordinate = "+1030-06656", label = "America/Caracas", countryId = db.Countries.Local.First(c => c.label == "VE").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "VG", rawCoordinate = "+1827-06437", label = "America/Tortola", countryId = db.Countries.Local.First(c => c.label == "VG").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "VI", rawCoordinate = "+1821-06456", label = "America/St_Thomas", countryId = db.Countries.Local.First(c => c.label == "VI").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "VN", rawCoordinate = "+1045+10640", label = "Asia/Ho_Chi_Minh", countryId = db.Countries.Local.First(c => c.label == "VN").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "VU", rawCoordinate = "-1740+16825", label = "Pacific/Efate", countryId = db.Countries.Local.First(c => c.label == "VU").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "WF", rawCoordinate = "-1318-17610", label = "Pacific/Wallis", countryId = db.Countries.Local.First(c => c.label == "WF").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "WS", rawCoordinate = "-1350-17144", label = "Pacific/Apia", countryId = db.Countries.Local.First(c => c.label == "WS").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "YE", rawCoordinate = "+1245+04512", label = "Asia/Aden", countryId = db.Countries.Local.First(c => c.label == "YE").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "YT", rawCoordinate = "-1247+04514", label = "Indian/Mayotte", countryId = db.Countries.Local.First(c => c.label == "YT").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "ZA", rawCoordinate = "-2615+02800", label = "Africa/Johannesburg", countryId = db.Countries.Local.First(c => c.label == "ZA").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "ZM", rawCoordinate = "-1525+02817", label = "Africa/Lusaka", countryId = db.Countries.Local.First(c => c.label == "ZM").id });
			timeZonesList.Add(new Models.TimeZone { countryCode = "ZW", rawCoordinate = "-1750+03103", label = "Africa/Harare", countryId = db.Countries.Local.First(c => c.label == "ZW").id });

			return timeZonesList;
		}
	}
}