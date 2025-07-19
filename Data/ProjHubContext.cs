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
        public DbSet<IncidentTicket> IncidentTickets { get; set; }


        // OPTIONAL:  Method used to configure the model and relationships
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<Project>().ToTable("Project");
            modelBuilder.Entity<IncidentTicket>().ToTable("IncidentTicket");
        }
    }
}
