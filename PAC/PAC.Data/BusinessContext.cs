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

        public IQueryable<Student> GetAllStudents()
        {
            return context.Students;
        }

        public Student GetStudentById(int? id)
        {
            return context.Students.Find(id);
        }

        public void AddNewStudent(Student student)
        {
            Check.Require(student.FirstName);
            Check.Require(student.LastName);

            context.Students.Add(student);
            context.SaveChanges();
        }

        public void EditStudent(Student student)
        {
            Check.Require(student.FirstName);
            Check.Require(student.LastName);

            context.Entry(student).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteStudent(Student student)
        {
            context.Students.Remove(student);
            context.SaveChanges();
        }

        #endregion

        #region TeacherLogic

        public IQueryable<Teacher> GetAllTeachers()
        {
            return context.Teachers;
        }

        public Teacher GetTeacherById(int? id)
        {
            return context.Teachers.Find(id);
        }

        public void AddNewTeacher(Teacher teacher)
        {
            Check.Require(teacher.FirstName);
            Check.Require(teacher.LastName);

            context.Teachers.Add(teacher);
            context.SaveChanges();
        }

        public void EditTeacher(Teacher teacher)
        {
            Check.Require(teacher.FirstName);
            Check.Require(teacher.LastName);
            context.Entry(teacher).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteTeacher(Teacher teacher)
        {
            context.Teachers.Remove(teacher);
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
            Check.Require(team.TeamName);

           context.Entry(team).State = EntityState.Modified;
           context.SaveChanges();
        }

        public void DeleteTeam(Team team)
        {
            context.Teams.Remove(team);
            context.SaveChanges();
        }
        #endregion

        #region CourseLogic

        public Course GetCourseById(int? id)
        {
            return context.Courses.Find(id);
        }

        public void AddNewCourse(Course course)
        {
            Check.Require(course.CourseName);
            Check.Require(course.CourseLength.ToString());
            Check.Require(course.CourseDesription);

            context.Courses.Add(course);
            context.SaveChanges();
        }

        public void EditCourse(Course course)
        {
            Check.Require(course.CourseName);
            Check.Require(course.CourseLength.ToString());
            Check.Require(course.CourseDesription);

            context.Entry(course).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteCourse(Course course)
        {
            context.Courses.Remove(course);
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

        public void EditTeamInstance(TeamInstance ti)
        {
            Check.Require(ti.TeamInstanceName);
            context.Entry(ti).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteTeamInstance(TeamInstance ti)
        {
            context.TeamInstances.Remove(ti);
            context.SaveChanges();
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

        public void EditTeamInstanceCourse(TeamInstanceCourse teamInstanceCourse)
        {
            context.Entry(teamInstanceCourse).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteTeamInstanceCourse(TeamInstanceCourse teamInstanceCourse)
        {
            context.TeamInstancesCourses.Remove(teamInstanceCourse);
            context.SaveChanges();
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
