// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataContext.cs" company="J.N Systems">
//   .
// </copyright>
// <summary>
//   Defines the DataContext type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PAC.Data
{
    using System.Data.Entity;

    using PAC.Data.Model;

    /// <summary>
    /// The data context.
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataContext"/> class that will use a default named connection string of 'Default' from the application's configuration file.
        /// </summary>
        public DataContext()
            : base("Default")
        {
        }

        /// <summary>
        /// Gets or sets the students.
        /// </summary>
        public DbSet<Student> Students { get; set; }

        /// <summary>
        /// Gets or sets the teachers.
        /// </summary>
        public DbSet<Teacher> Teachers { get; set; }

        /// <summary>
        /// Gets or sets the courses.
        /// </summary>
        public DbSet<Course> Courses { get; set; }

        /// <summary>
        /// Gets or sets the teacher courses.
        /// </summary>
        public DbSet<TeacherCourse> TeacherCourses { get; set; }

        /// <summary>
        /// Gets or sets the teams.
        /// </summary>
        public DbSet<Team> Teams { get; set; }

        /// <summary>
        /// Gets or sets the team instances.
        /// </summary>
        public DbSet<TeamInstance> TeamInstances { get; set; }

        /// <summary>
        /// Gets or sets the team instances courses.
        /// </summary>
        public DbSet<TeamInstanceCourse> TeamInstancesCourses { get; set; }

        /// <summary>
        /// The on model creating to make composite keys inside our junction tables TeacherCourse
        /// and TeamInstanceCourse
        /// </summary>
        /// <param name="modelBuilder">
        /// The model builder.
        /// </param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeacherCourse>()
                .HasKey(t => new { t.CourseId, t.TeacherId });

            modelBuilder.Entity<TeamInstanceCourse>()
                .HasKey(ti => new { ti.CourseId, ti.TeamInstanceId });
        }
    }
}
