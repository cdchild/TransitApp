using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

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

		public System.Data.Entity.DbSet<Transit.Models.AccessibleCode> AccessibleCodes { get; set; }

		public System.Data.Entity.DbSet<Transit.Models.BikeCode> BikeCodes { get; set; }

		public System.Data.Entity.DbSet<Transit.Models.Country> Countries { get; set; }

		public System.Data.Entity.DbSet<Transit.Models.Feed> Feeds { get; set; }

		public System.Data.Entity.DbSet<Transit.Models.Language> Languages { get; set; }

		public System.Data.Entity.DbSet<Transit.Models.RouteType> RouteTypes { get; set; }

		public System.Data.Entity.DbSet<Transit.Models.ShapePoint> ShapePoints { get; set; }

		public System.Data.Entity.DbSet<Transit.Models.StopCode> StopCodes { get; set; }

		public System.Data.Entity.DbSet<Transit.Models.TimeZone> TimeZones { get; set; }

		public System.Data.Entity.DbSet<Transit.Models.TransferType> TransferTypes { get; set; }

		public System.Data.Entity.DbSet<Transit.Models.TripFrequency> TripFrequencies { get; set; }

		public System.Data.Entity.DbSet<Transit.Models.Route> Routes { get; set; }

		public System.Data.Entity.DbSet<Transit.Models.ServiceDate> ServiceDates { get; set; }

		public System.Data.Entity.DbSet<Transit.Models.Service> Services { get; set; }

		public System.Data.Entity.DbSet<Transit.Models.Stop> Stops { get; set; }

		public System.Data.Entity.DbSet<Transit.Models.Transfer> Transfers { get; set; }

		public System.Data.Entity.DbSet<Transit.Models.Trip> Trips { get; set; }

		public System.Data.Entity.DbSet<Transit.Models.StopTime> StopTimes { get; set; }

		public System.Data.Entity.DbSet<Transit.Models.Agency> Agencies { get; set; }


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
			/*
			modelBuilder.Entity<Submission>()
					.HasRequired(s => s.registration)
					.WithMany()
					.WillCascadeOnDelete(false);
			modelBuilder.Entity<Submission>()
					.HasRequired(s => s.sectionAssignment)
					.WithMany()
					.WillCascadeOnDelete(false);
			 */
		}
	}
}