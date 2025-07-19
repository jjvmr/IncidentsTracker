using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IncidentsTrackingSystem.Models;

namespace IncidentsTrackingSystem.Data
{
    public class ProjHubContext : DbContext
    {
        public ProjHubContext (DbContextOptions<ProjHubContext> options)
            : base(options)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Ticket> IncidentTickets { get; set; }


        // OPTIONAL:  Method used to configure the model and relationships
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<Project>().ToTable("Project");
            modelBuilder.Entity<Ticket>().ToTable("IncidentTicket");

            modelBuilder.Entity<Project>()
                .HasOne(p => p.UserAssigned)
                .WithMany(u => u.AssignedProjects)
                .HasForeignKey(p => p.UserAssignedId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade path

            // Project → IncidentTickets
            modelBuilder.Entity<Ticket>()
                .HasOne(it => it.Project)
                .WithMany(p => p.ProjectIncidents)
                .HasForeignKey(it => it.ProjectId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cycle

            // IncidentTicket → AppUser (Submitter)
            modelBuilder.Entity<Ticket>()
                .HasOne(it => it.Submitter)
                .WithMany(u => u.SubmittedTickets)
                .HasForeignKey(it => it.SubmitterId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cycle
        }
    }
}
