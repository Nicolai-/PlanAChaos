using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAC.Data.Model;

namespace PAC.Data
{
    public sealed class BusinessContext : IDisposable
    {
        private readonly DataContext context;
        private bool disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessContext"/> class.
        /// </summary>
        public BusinessContext()
        {
            context = new DataContext();
        }

        /// <summary>
        /// Gets the underlying <see cref="DataContext"/>.
        /// </summary>
        public DataContext DataContext
        {
            get { return context; }
        }

        #region StudentLogic
        public void AddNewStudent(Student student)
        {
            Check.Require(student.FirstName);
            Check.Require(student.LastName);

            context.Students.Add(student);
            context.SaveChanges();
        }

        #endregion

        #region TeacherLogic
        public void AddNewTeacher(Teacher teacher)
        {
            Check.Require(teacher.FirstName);
            Check.Require(teacher.LastName);

            context.Teachers.Add(teacher);
            context.SaveChanges();
        }

        #endregion

        #region TeamLogic

        public Team GetTeamById(int? id)
        {
            return context.Teams.Find(id);
        }

        public void AddNewTeam(Team team)
        {
            Check.Require(team.TeamName);

            context.Teams.Add(team);
            context.SaveChanges();
        }

        public void EditTeam(Team team)
        {
           context.Entry(team).State = EntityState.Modified;
           context.SaveChanges();
        }
        #endregion

        #region CourseLogic
        public void AddNewCourse(Course course)
        {
            Check.Require(course.CourseName);
            Check.Require(course.CourseLength.ToString());
            Check.Require(course.CourseDesription);

            context.Courses.Add(course);
            context.SaveChanges();
        }

        #endregion

        #region TeamInstanceLogic

        public void AddNewTeamInstance(TeamInstance ti)
        {
            Check.Require(ti.TeamInstanceName);
            context.TeamInstances.Add(ti);
            context.SaveChanges();
        }

        public TeamInstance GetTeamInstanceById(int? id)
        {
            return context.TeamInstances.Find(id);
        }

        #endregion

        #region TeamInstanceCourseLogic

        public void AddNewTeamInstanceCourse(TeamInstanceCourse teamInstanceCourse)
        {
            context.TeamInstancesCourses.Add(teamInstanceCourse);
            context.SaveChanges();
        }

        public TeamInstanceCourse GetTeamInstanceCourseById(int courseId, int teamInstanceId)
        {
            return context.TeamInstancesCourses.Find(courseId, teamInstanceId);
        }

        #endregion


        static class Check
        {
            public static void Require(string value)
            {
                if (value == null)
                    throw new ArgumentNullException();
                else if (value.Trim().Length == 0)
                    throw new ArgumentException();
            }
        }

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposed || !disposing)
                return;

            if (context != null)
                context.Dispose();

            disposed = true;
        }

        #endregion
    }
}
