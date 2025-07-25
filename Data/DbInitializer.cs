﻿using IncidentsTrackingSystem.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Data;

namespace IncidentsTrackingSystem.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ProjHubContext context)
        {
            // Check if the database exists
            if (context.AppUsers.Any())
            {
                return;   // DB has been seeded
            }

            var users = new AppUser[]
            {
                new AppUser { UserName = "admin@its.com", Email = "admin@its.com", Password = "Admin123!" },
                new AppUser { UserName = "developer@its.com", Email = "developer@its.com", Password = "Admin123!" },
                new AppUser { UserName = "pm@its.com", Email = "pm@its.com", Password = "Admin123!" },
                new AppUser { UserName = "submitter@its.com", Email = "submitter@its.com", Password = "Admin123!" },
                new AppUser { UserName = "user1@its.com", Email = "user1@its.com", Password = "Admin123!" },
                new AppUser { UserName = "user2@its.com", Email = "user2@its.com", Password = "Admin123!" }

            };

            context.AppUsers.AddRange(users);
            context.SaveChanges();

            var roles = new Role[]
            {
                new Role { RoleName = "Admin" },
                new Role { RoleName = "Developer" },
                new Role { RoleName = "Project Manager" },
                new Role { RoleName = "Submitter" },
                new Role { RoleName = "Tester" }
            };

            context.Roles.AddRange(roles);
            context.SaveChanges();

            var projects = new Project[]
            {
                new Project { ProjectId = 1, Title = "Project 1", Created = DateTime.Parse("2019-09-01"), UserAssignedId = 4 },
                new Project { ProjectId = 2, Title = "Project 2", Created = DateTime.Parse("2017-07-15"), UserAssignedId = 3 },
                new Project { ProjectId = 3, Title = "Project 3", Created = DateTime.Parse("2013-04-17"), UserAssignedId = 1 },
                new Project { ProjectId = 4, Title = "Project 4", Created = DateTime.Parse("2020-12-21"), UserAssignedId = 5 },
                new Project { ProjectId = 5, Title = "Project 5", Created = DateTime.Parse("2024-02-11"), UserAssignedId = 6 },
                new Project { ProjectId = 6, Title = "Project 6", Created = DateTime.Parse("2013-12-02"), UserAssignedId = 1 },
            };
            
            context.Projects.AddRange(projects);
            context.SaveChanges();
            
            var tickets = new Ticket[]
            {
                new Ticket { Title = "Sample Ticket 1", Description = "This is a sample ticket description for Project 2.", ProjectId = 2, SubmitterId = 1 },
                new Ticket { Title = "Sample Ticket 2", Description = "This is a sample ticket description for Project 6.", ProjectId = 6, SubmitterId = 2 },
                new Ticket { Title = "Sample Ticket 3", Description = "This is a sample ticket description for Project 2.", ProjectId = 2, SubmitterId = 1 },
                new Ticket { Title = "Sample Ticket 4", Description = "This is a sample ticket description for Project 6.", ProjectId = 6, SubmitterId = 1 },
                new Ticket { Title = "Sample Ticket 5", Description = "This is a sample ticket description for Project 6.", ProjectId = 6, SubmitterId = 5 },
                new Ticket { Title = "Sample Ticket 6", Description = "This is a sample ticket description for Project 6.", ProjectId = 6, SubmitterId = 5 },
                new Ticket { Title = "Sample Ticket 7", Description = "This is a sample ticket description for Project 3.", ProjectId = 3, SubmitterId = 1 }
            };

            context.IncidentTickets.AddRange(tickets);
            context.SaveChanges();
    
            // to add a role to a user, you would typically do this after the users are created
            // Example: Assigning roles to users
            // This is a placeholder for role assignment logic
            // You would typically have a many-to-many relationship between AppUser and Role
            // For example, if you have a UserRoles navigation property in AppUser, you could do something like this:
            //var adminUser = context.AppUsers.FirstOrDefault(u => u.UserName == "admin@its.com");
            //var adminRole = context.Roles.FirstOrDefault(r => r.RoleName == "Admin");


            //if (adminRole != null)
            //{
            //    context.Roles.Add(adminRole);
            //    adminUser.AppUserRoles = new List<Role> { adminRole };
            //    context.SaveChanges();
            //}




        }

    }
}
