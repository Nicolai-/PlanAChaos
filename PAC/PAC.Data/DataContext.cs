using System.Data.Entity;
using PAC.Data.Model;

namespace PAC.Data
{
    public class DataContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataContext"/> class that will use a default named connection string of 'Default' from the application's configuration file.
        /// </summary>
        public DataContext()
            : base("Default")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeacherCourse>()
                .HasKey(t => new {t.CourseId, t.TeacherId});

            modelBuilder.Entity<TeamInstanceCourse>()
                .HasKey(ti => new {ti.CourseId, ti.TeamInstanceId});
        }

        /// <summary>
        /// Gets a collection of customer entities.
        /// </summary>
        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<TeacherCourse> TeacherCourses { get; set; }

        public DbSet<Team> Teams  { get; set; }
        
        public DbSet<TeamInstance> TeamInstances { get; set; }

        public DbSet<TeamInstanceCourse> TeamInstancesCourses { get; set; }
    
    }
}
