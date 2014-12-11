// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BusinessContext.cs" company="J.N Systems">
//   .
// </copyright>
// <summary>
//   The business context.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PAC.Data
{
    using System;
    using System.Data.Entity;
    using System.Globalization;
    using System.Linq;

    using PAC.Data.Model;

    /// <summary>
    /// The business context.
    /// </summary>
    public sealed class BusinessContext : IDisposable
    {
        /// <summary>
        /// The context.
        /// </summary>
        private readonly DataContext context;

        /// <summary>
        /// The disposed.
        /// </summary>
        private bool disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessContext"/> class.
        /// </summary>
        public BusinessContext()
        {
            this.context = new DataContext();
        }

        /// <summary>
        /// Gets the underlying <see cref="DataContext"/>.
        /// </summary>
        public DataContext DataContext
        {
            get { return this.context; }
        }

        #region StudentLogic

        /// <summary>
        /// The get all students.
        /// </summary>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public IQueryable<Student> GetAllStudents()
        {
            return this.context.Students;
        }

        /// <summary>
        /// The get student by id.
        /// </summary>
        /// <param name="id">
        /// The id to find
        /// </param>
        /// <returns>
        /// The <see cref="Student"/>.
        /// </returns>
        public Student GetStudentById(int? id)
        {
            return this.context.Students.Find(id);
        }

        /// <summary>
        /// The add new student.
        /// </summary>
        /// <param name="student">
        /// The student.
        /// </param>
        public void AddNewStudent(Student student)
        {
            Check.Require(student.FirstName);
            Check.Require(student.LastName);

            this.context.Students.Add(student);
            this.context.SaveChanges();
        }

        /// <summary>
        /// The edit student.
        /// </summary>
        /// <param name="student">
        /// The student.
        /// </param>
        public void EditStudent(Student student)
        {
            Check.Require(student.FirstName);
            Check.Require(student.LastName);

            this.context.Entry(student).State = EntityState.Modified;
            this.context.SaveChanges();
        }

        /// <summary>
        /// The delete student.
        /// </summary>
        /// <param name="student">
        /// The student.
        /// </param>
        public void DeleteStudent(Student student)
        {
            this.context.Students.Remove(student);
            this.context.SaveChanges();
        }

        #endregion

        #region TeacherLogic

        /// <summary>
        /// The get all teachers.
        /// </summary>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public IQueryable<Teacher> GetAllTeachers()
        {
            return this.context.Teachers;
        }

        /// <summary>
        /// The get teacher by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Teacher"/>.
        /// </returns>
        public Teacher GetTeacherById(int? id)
        {
            return this.context.Teachers.Find(id);
        }

        /// <summary>
        /// The add new teacher.
        /// </summary>
        /// <param name="teacher">
        /// The teacher.
        /// </param>
        public void AddNewTeacher(Teacher teacher)
        {
            Check.Require(teacher.FirstName);
            Check.Require(teacher.LastName);

            this.context.Teachers.Add(teacher);
            this.context.SaveChanges();
        }

        /// <summary>
        /// The edit teacher.
        /// </summary>
        /// <param name="teacher">
        /// The teacher.
        /// </param>
        public void EditTeacher(Teacher teacher)
        {
            Check.Require(teacher.FirstName);
            Check.Require(teacher.LastName);
            this.context.Entry(teacher).State = EntityState.Modified;
            this.context.SaveChanges();
        }

        /// <summary>
        /// The delete teacher.
        /// </summary>
        /// <param name="teacher">
        /// The teacher.
        /// </param>
        public void DeleteTeacher(Teacher teacher)
        {
            this.context.Teachers.Remove(teacher);
            this.context.SaveChanges();
        }

        #endregion

        #region TeamLogic

        /// <summary>
        /// The get team by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Team"/>.
        /// </returns>
        public Team GetTeamById(int? id)
        {
            return this.context.Teams.Find(id);
        }

        /// <summary>
        /// The add new team.
        /// </summary>
        /// <param name="team">
        /// The team.
        /// </param>
        public void AddNewTeam(Team team)
        {
            Check.Require(team.TeamName);

            this.context.Teams.Add(team);
            this.context.SaveChanges();
        }

        /// <summary>
        /// The edit team.
        /// </summary>
        /// <param name="team">
        /// The team.
        /// </param>
        public void EditTeam(Team team)
        {
            Check.Require(team.TeamName);

           this.context.Entry(team).State = EntityState.Modified;
           this.context.SaveChanges();
        }

        /// <summary>
        /// The delete team.
        /// </summary>
        /// <param name="team">
        /// The team.
        /// </param>
        public void DeleteTeam(Team team)
        {
            this.context.Teams.Remove(team);
            this.context.SaveChanges();
        }
        #endregion

        #region CourseLogic

        /// <summary>
        /// The get course by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Course"/>.
        /// </returns>
        public Course GetCourseById(int? id)
        {
            return this.context.Courses.Find(id);
        }

        /// <summary>
        /// The add new course.
        /// </summary>
        /// <param name="course">
        /// The course.
        /// </param>
        public void AddNewCourse(Course course)
        {
            Check.Require(course.CourseName);
            Check.Require(course.CourseLength.ToString(CultureInfo.InvariantCulture));
            Check.Require(course.CourseDescription);

            this.context.Courses.Add(course);
            this.context.SaveChanges();
        }

        /// <summary>
        /// The edit course.
        /// </summary>
        /// <param name="course">
        /// The course.
        /// </param>
        public void EditCourse(Course course)
        {
            Check.Require(course.CourseName);
            Check.Require(course.CourseLength.ToString(CultureInfo.InvariantCulture));
            Check.Require(course.CourseDescription);

            this.context.Entry(course).State = EntityState.Modified;
            this.context.SaveChanges();
        }

        /// <summary>
        /// The delete course.
        /// </summary>
        /// <param name="course">
        /// The course.
        /// </param>
        public void DeleteCourse(Course course)
        {
            this.context.Courses.Remove(course);
            this.context.SaveChanges();
        }

        #endregion

        #region TeamInstanceLogic

        /// <summary>
        /// The add new team instance.
        /// </summary>
        /// <param name="ti">
        /// The ti.
        /// </param>
        public void AddNewTeamInstance(TeamInstance ti)
        {
            Check.Require(ti.TeamInstanceName);
            this.context.TeamInstances.Add(ti);
            this.context.SaveChanges();
        }

        /// <summary>
        /// The get team instance by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="TeamInstance"/>.
        /// </returns>
        public TeamInstance GetTeamInstanceById(int? id)
        {
            return this.context.TeamInstances.Find(id);
        }

        /// <summary>
        /// The edit team instance.
        /// </summary>
        /// <param name="ti">
        /// The ti.
        /// </param>
        public void EditTeamInstance(TeamInstance ti)
        {
            Check.Require(ti.TeamInstanceName);
            this.context.Entry(ti).State = EntityState.Modified;
            this.context.SaveChanges();
        }

        /// <summary>
        /// The delete team instance.
        /// </summary>
        /// <param name="ti">
        /// The ti.
        /// </param>
        public void DeleteTeamInstance(TeamInstance ti)
        {
            this.context.TeamInstances.Remove(ti);
            this.context.SaveChanges();
        }

        #endregion

        #region TeamInstanceCourseLogic

        /// <summary>
        /// The add new team instance course.
        /// </summary>
        /// <param name="teamInstanceCourse">
        /// The team instance course.
        /// </param>
        public void AddNewTeamInstanceCourse(TeamInstanceCourse teamInstanceCourse)
        {
            this.context.TeamInstancesCourses.Add(teamInstanceCourse);
            this.context.SaveChanges();
        }

        /// <summary>
        /// The get team instance course by id.
        /// </summary>
        /// <param name="courseId">
        /// The course id.
        /// </param>
        /// <param name="teamInstanceId">
        /// The team instance id.
        /// </param>
        /// <returns>
        /// The <see cref="TeamInstanceCourse"/>.
        /// </returns>
        public TeamInstanceCourse GetTeamInstanceCourseById(int courseId, int teamInstanceId)
        {
            return this.context.TeamInstancesCourses.Find(courseId, teamInstanceId);
        }

        /// <summary>
        /// The edit team instance course.
        /// </summary>
        /// <param name="teamInstanceCourse">
        /// The team instance course.
        /// </param>
        public void EditTeamInstanceCourse(TeamInstanceCourse teamInstanceCourse)
        {
            this.context.Entry(teamInstanceCourse).State = EntityState.Modified;
            this.context.SaveChanges();
        }

        /// <summary>
        /// The delete team instance course.
        /// </summary>
        /// <param name="teamInstanceCourse">
        /// The team instance course.
        /// </param>
        public void DeleteTeamInstanceCourse(TeamInstanceCourse teamInstanceCourse)
        {
            this.context.TeamInstancesCourses.Remove(teamInstanceCourse);
            this.context.SaveChanges();
        }

        #endregion

       #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        /// <param name="disposing">
        /// The disposing.
        /// </param>
        private void Dispose(bool disposing)
        {
            if (this.disposed || !disposing)
            {
                return;
            }

            if (this.context != null)
            {
                this.context.Dispose();
            }

            this.disposed = true;
        }

        #endregion

        /// <summary>
        /// The check.
        /// </summary>
        internal static class Check
        {
            /// <summary>
            /// The require.
            /// </summary>
            /// <param name="value">
            /// The value.
            /// </param>
            /// <exception cref="ArgumentNullException">
            /// If Argument is non existent
            /// </exception>
            /// <exception cref="ArgumentException">
            /// Ïf Argument is invalid
            /// </exception>
            public static void Require(string value)
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                if (value.Trim().Length == 0)
                {
                    throw new ArgumentException();
                }
            }
        }
    }
}
