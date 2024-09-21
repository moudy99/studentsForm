using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using studentsForm.Core.Models;

namespace studentsForm.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<Student>
    {
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StudentSubject>()
                        .HasKey(ss => new { ss.StudentId, ss.SubjectId });

            modelBuilder.Entity<StudentSubject>()
                .HasOne(ss => ss.Student)
                .WithMany(s => s.StudentSubjects)
                .HasForeignKey(ss => ss.StudentId);

            modelBuilder.Entity<StudentSubject>()
                .HasOne(ss => ss.Subject)
                .WithMany(s => s.StudentSubjects)
                .HasForeignKey(ss => ss.SubjectId);

            modelBuilder.Entity<Subject>()
                  .HasData(
                      new Subject { Id = 1, Name = "Math" },
                      new Subject { Id = 2, Name = "Science" },
                      new Subject { Id = 3, Name = "History" },
                      new Subject { Id = 4, Name = "English" }
                  );
        }
    }
}
