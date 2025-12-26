using DrivingSchoolApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DrivingSchoolApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

		public DbSet<Student> Students { get; set; }
		public DbSet<Teacher> Teachers { get; set; }
		public DbSet<Instructor> Instructors { get; set; }
		public DbSet<StudyGroup> StudyGroups { get; set; }
		public DbSet<StudyProgram> StudyPrograms { get; set; }
		public DbSet<Lesson> Lessons { get; set; }
		public DbSet<Attendance> Attendances { get; set; }
		public DbSet<DrivingLesson> DrivingLessons { get; set; }
		public DbSet<TheoryExam> TheoryExams { get; set; }
		public DbSet<PracticeExam> PracticeExams { get; set; }
		public DbSet<Application> Applications { get; set; }
		public DbSet<Vehicle> Vehicles { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			foreach (var relationship in modelBuilder.Model.GetEntityTypes()
				.SelectMany(e => e.GetForeignKeys())
				.Where(fk => fk.PrincipalEntityType.ClrType == typeof(Student)))
			{
				relationship.DeleteBehavior = DeleteBehavior.Restrict;
			}

			modelBuilder.Entity<Application>()
				.HasOne(a => a.Student)
				.WithMany()
				.HasForeignKey(a => a.StudentId)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<StudyProgram>()
				.Property(s => s.Cost)
				.HasPrecision(18, 2);
		}
	}
}
