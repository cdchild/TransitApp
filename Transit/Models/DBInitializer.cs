using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Transit.Models
{
    public class DBInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        //define default admin user and password
        private const short defAdminUserId = 0;
        private const string defAdminUserName = "admin";
        private const string defAdminPassword = "testing123TESTING";

		protected override void Seed(ApplicationDbContext db)
		{
			/*-------------------------------------------*
			 *                                           *
			 *            Seed User & Roles              *
			 *                                           *
			 *-------------------------------------------*
			 */
			//create a usermanager identity object/context with the users in the database
			var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
			//create a rolemanager identity object for the roles in the db
			var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

			foreach (RolesEnum role in (RolesEnum[])Enum.GetValues(typeof(RolesEnum)))
			{
				if (!RoleManager.RoleExists(role.ToString()))
					RoleManager.Create(new IdentityRole(role.ToString()));
			}

			//Create default user

			var user = new ApplicationUser();
			user.UserName = defAdminUserName;
			//this still isn't being created....
			user.Id = defAdminUserId.ToString();
			user.Email = "admin@localhost.local";
			user.EmailConfirmed = true;
			user.PhoneNumber = "801-123-4567";
			user.PhoneNumberConfirmed = true;
			try
			{
				var addResult = UserManager.Create(user, defAdminPassword);
				//Add default user to admin roles
				if (addResult.Succeeded)
				{
					var result = UserManager.AddToRole(user.Id, RolesEnum.AccountAdministrator.ToString());
					result = UserManager.AddToRole(user.Id, RolesEnum.TransitAdministrator.ToString());
				}
			}
			catch (DbEntityValidationException)
			{
				return;
			}


			//check if it already exists by seeing if id lookup returns different type of object as the user
			if (UserManager.FindById<ApplicationUser, string>(defAdminUserId.ToString()).GetType().ToString() != user.GetType().ToString())
			{
				return;
			}


			/*-------------------------------------------*
			 *                                           *
			 *             Seed TEST USERS               *
			 *                                           *
			 *-------------------------------------------*
			 */
			ApplicationUser testUser = new ApplicationUser() { UserName = "12345655", Email = "userj@yahoo.com", EmailConfirmed = true, PhoneNumber = "1-234-5655", PhoneNumberConfirmed = true };
			ApplicationUser testAgencyAdmin = new ApplicationUser() { UserName = "12345655", Email = "userj@yahoo.com", EmailConfirmed = true, PhoneNumber = "1-234-5655", PhoneNumberConfirmed = true };

			UserManager.Create(testUser, "11223344mnop");
			UserManager.Create(testAgencyAdmin, "11223344mnop");

			string raa = RolesEnum.TransitAdministrator.ToString();
			string rru = RolesEnum.User.ToString();
			IdentityRole r1 = db.Roles.First(r => r.Name == raa);
			ApplicationUser u1 = db.Users.First(u => u.UserName == testAgencyAdmin.UserName);
			IdentityRole r2 = db.Roles.First(r => r.Name == rru);
			ApplicationUser u2 = db.Users.First(u => u.UserName == testUser.UserName);
			UserManager.AddToRole(u1.Id, r1.Name);
			UserManager.AddToRole(u2.Id, r2.Name);

			//Countries
			db.Countries.AddRange(Countries.List());

			//TimeZones
			db.TimeZones.AddRange(TimeZones.List(db));


			//Languages
			Language lang1 = new Language
			{
				label = "EN",
				description = "English"
			};
			db.Languages.Add(lang1);

			//Agencies
			var agency1Lang = db.Languages.Local.First(l => l.label == "EN");
			var agency1TimeZone = db.TimeZones.Local.First(t => t.label.Contains("Denver"));
			Agency agency1 = new Agency
			{
				phone = "888-RIDE-UTA",
				url = "http://www.rideuta.com",
				name = "Utah Transit Authority",
				timeZone = "America/Denver",
				language = "EN",
				languageId = agency1Lang.id,
				timeZoneObjId = agency1TimeZone.id

			};
			db.Agencies.Add(agency1);

			//shapes


			//services
			db.Services.AddRange(Services.List());



			base.Seed(db);
		}
	}
}