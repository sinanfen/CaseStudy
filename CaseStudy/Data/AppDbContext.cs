using CaseStudy.Models;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>()
                .HasMany(n => n.NoteDetails)
                .WithOne(n => n.Notes)
                .HasForeignKey(n => n.NoteId);

            modelBuilder.Entity<NoteDetail>()
                .HasOne(n => n.Notes)
                .WithMany(n => n.NoteDetails)
                .HasForeignKey(n => n.NoteId);

            modelBuilder.Entity<NoteDetail>()
                .HasOne(n => n.User)
                .WithMany(n => n.NoteDetails)
                .HasForeignKey(n => n.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Notes)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<Note>().ToTable("Note");
            modelBuilder.Entity<NoteDetail>().ToTable("NoteDetail");
            modelBuilder.Entity<User>().ToTable("User");

            modelBuilder.Entity<Note>().HasData(
                new Note { Id = 1, UserId = 1, Content = "Deneme not 1" },
                new Note { Id = 2, UserId = 2, Content = "Deneme not 2" },
                new Note { Id = 3, UserId = 3, Content = "Deneme not 3" }
                );

            modelBuilder.Entity<NoteDetail>().HasData(
                new NoteDetail { Id = 1, NoteId = 1, UserId = 1, Content = "Deneme not detay 1" },
                new NoteDetail { Id = 2, NoteId = 2, UserId = 2, Content = "Deneme not detay 1" },
                new NoteDetail { Id = 3, NoteId = 3, UserId = 3, Content = "Deneme not detay 1" }
                );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FullName = "Ali" },
                new User { Id = 2, FullName = "Veli" },
                new User { Id = 3, FullName = "Cem" }
                );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<NoteDetail> NoteDetails { get; set; }
    }
}
