using ARS_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_DAL
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {

        }

        public DbSet<Participant> Participant { get; set; }
        public DbSet<SessionType> SessionType { get; set; }
        public DbSet<SessionDetails> SessionDetails { get; set; }
        public DbSet<SessionParticipantsMapping> SessionParticipantsMapping { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Participant>().HasIndex(x => x.Email).IsUnique();
            modelBuilder.Entity<SessionType>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<SessionParticipantsMapping>().HasIndex(x => new { x.ParticipantId,x.SessionDetailsId }).IsUnique();
        }
    }
}
 