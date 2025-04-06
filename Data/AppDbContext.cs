using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Corporate_Training_Management.Models;

namespace Corporate_Training_Management.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<TrainingParticipant> TrainingParticipants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=TrainingDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrainingParticipant>()
                .HasKey(tp => new { tp.TrainingId, tp.ParticipantId });

            modelBuilder.Entity<TrainingParticipant>()
                .HasOne(tp => tp.Training)
                .WithMany(t => t.TrainingParticipants)
                .HasForeignKey(tp => tp.TrainingId);

            modelBuilder.Entity<TrainingParticipant>()
                .HasOne(tp => tp.Participant)
                .WithMany(p => p.TrainingParticipants)
                .HasForeignKey(tp => tp.ParticipantId);
        }
    }
}
