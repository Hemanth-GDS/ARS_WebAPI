using ARS_Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.IO;
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

        public DbSet<ParticipantIntrests> ParticipantIntrests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Participant>().HasIndex(x => x.Email).IsUnique();
            modelBuilder.Entity<SessionType>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<SessionParticipantsMapping>().HasIndex(x => new { x.ParticipantId,x.SessionDetailsId }).IsUnique();
            modelBuilder.Entity<ParticipantIntrests>().HasIndex(x => new { x.ParticipantID, x.SessionTypeId }).IsUnique();
        }

        
    }


    //public partial class ReadData : Migration
    //{
    //    //protected override void Up(MigrationBuilder migrationBuilder)
    //    //{
    //    //    //C:\ARS\ARS_WebAPI\ARS_WebAPI\ARS_DAL\Scripts\Scripts_1.sql
    //    //    var sqlFile = Path.Combine("Scripts/Scripts_1.sql");
    //    //    migrationBuilder.Sql(File.ReadAllText(sqlFile));
    //    //}
    //}
}
 