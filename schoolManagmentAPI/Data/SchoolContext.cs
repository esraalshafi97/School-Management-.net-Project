using Microsoft.EntityFrameworkCore;
using schoolManagmentAPI.Data.Entities;

namespace schoolManagmentAPI.Data
{
    public class SchoolContext : DbContext
    {
        public DbSet<Classroom> Classrooms { get; set; } = null!;
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Subject> Subjects { get; set; } = null!;
        public DbSet<Teacher> Teachers { get; set; } = null!;
        public DbSet<Token> Tokens { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Create mock data for teachers
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher {Id=1, Name = "John Smith", NationalNumber = "123456789012", SubjectId = 1, ImageUrl = "" },
                new Teacher { Id = 2, Name = "Jane Doe", NationalNumber = "987654321098", SubjectId = 2, ImageUrl = "" }
            );

            // Create mock data for subjects
            modelBuilder.Entity<Subject>().HasData(
                new Subject { SubjectId = 1, Name = "Mathematics" },
                new Subject { SubjectId = 2, Name = "Science" }
            );

            // Create mock data for classrooms
            modelBuilder.Entity<Classroom>().HasData(
                new Classroom { ClassroomId = 1, Name = "Class A" },
                new Classroom { ClassroomId = 2, Name = "Class B" }
            );

            // Create mock data for students
            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 1, Name = "Alice", ClassroomId = 1 },
                new Student { StudentId = 2, Name = "Bob", ClassroomId = 1 },
                new Student { StudentId = 3, Name = "Charlie", ClassroomId = 2 }
            );
            User user = new User { UserId = 2, UserName = "Alice", Password = "esra" };
            user.HashPassword();
            // Create mock data for users
            modelBuilder.Entity<User>().HasData(
               user
                  );

            // Establish relationships between entities
            modelBuilder.Entity<Appointment>()
    .HasOne(a => a.Teacher)
    .WithOne(t => t.Appointment)
    .HasForeignKey<Appointment>(a => a.TeacherId);

            modelBuilder.Entity<Appointment>()
               .HasOne(a => a.Classroom)
               .WithOne(c => c.Appointment)
               .HasForeignKey<Appointment>(a => a.ClassroomId);
        
        modelBuilder.Entity<Student>().HasOne(s => s.Classroom).WithMany(c => c.Students);
            modelBuilder.Entity<Teacher>().HasOne(t => t.Subject).WithMany(s => s.Teachers);
          
            base.OnModelCreating(modelBuilder);
        }
    }
}
