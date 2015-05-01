using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Transit.Models
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext()
			: base("DefaultConnection", throwIfV1Schema: false)
		{
		}

		public static ApplicationDbContext Create()
		{
			return new ApplicationDbContext();
		}

		public DbSet<Transit.Models.AccessibleCode> AccessibleCodes { get; set; }

		public DbSet<Transit.Models.Agency> Agencies { get; set; }

		public DbSet<Transit.Models.BikeCode> BikeCodes { get; set; }

		public DbSet<Transit.Models.Country> Countries { get; set; }

		public DbSet<Transit.Models.Feed> Feeds { get; set; }

		public DbSet<Transit.Models.Language> Languages { get; set; }

		public DbSet<Transit.Models.Route> Routes { get; set; }

		public DbSet<Transit.Models.RouteType> RouteTypes { get; set; }

		public DbSet<Transit.Models.Service> Services { get; set; }

		public DbSet<Transit.Models.ServiceDate> ServiceDates { get; set; }

		public DbSet<Transit.Models.ShapePoint> ShapePoints { get; set; }

		public DbSet<Transit.Models.Stop> Stops { get; set; }

		public DbSet<Transit.Models.StopCode> StopCodes { get; set; }

		public DbSet<Transit.Models.StopTime> StopTimes { get; set; }

		public DbSet<Transit.Models.TimeZone> TimeZones { get; set; }

		public DbSet<Transit.Models.Transfer> Transfers { get; set; }

		public DbSet<Transit.Models.TransferType> TransferTypes { get; set; }

		public DbSet<Transit.Models.TripFrequency> TripFrequencies { get; set; }

		public DbSet<Transit.Models.Trip> Trips { get; set; }

		public DbSet<Transit.Models.UserSetLegStop> UserSetLegStops { get; set; }

		public DbSet<Transit.Models.UserSetRouteLeg> UserSetRouteLegs { get; set; }

		public DbSet<Transit.Models.UserSetSchedule> UserSetSchedules { get; set; }


		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<AccessibleCode>().Property(r => r.id)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
			modelBuilder.Entity<BikeCode>().Property(r => r.id)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
			modelBuilder.Entity<StopCode>().Property(r => r.id)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
			modelBuilder.Entity<TransferType>().Property(r => r.id)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
			modelBuilder.Entity<Route>().Property(r => r.id)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
			modelBuilder.Entity<RouteType>().Property(r => r.id)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

			modelBuilder.Entity<Transfer>()
					.HasRequired(r => r.toStop)
					.WithMany()
					.WillCascadeOnDelete(false);
		}
	}
}