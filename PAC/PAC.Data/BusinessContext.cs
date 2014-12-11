using System;
using System.Data.Entity;
using System.Linq;
using PAC.Data.Model;

namespace PAC.Data
{
    public sealed class BusinessContext : IDisposable
    {
        private readonly DataContext _context;
        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessContext"/> class.
        /// </summary>
        public BusinessContext()
        {
            _context = new DataContext();
        }

        /// <summary>
        /// Gets the underlying <see cref="DataContext"/>.
        /// </summary>
        public DataContext DataContext
        {
            get { return _context; }
        }

        #region StudentLogic

        public IQueryable<Student> GetAllStudents()
        {
            return _context.Students;
        }

        public Student GetStudentById(int? id)
        {
            return _context.Students.Find(id);
        }

        public void AddNewStudent(Student student)
        {
            Check.Require(student.FirstName);
            Check.Require(student.LastName);

            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void EditStudent(Student student)
        {
            Check.Require(student.FirstName);
            Check.Require(student.LastName);

            _context.Entry(student).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteStudent(Student student)
        {
            _context.Students.Remove(student);
            _context.SaveChanges();
        }

        #endregion

        #region TeacherLogic

        public IQueryable<Teacher> GetAllTeachers()
        {
            return _context.Teachers;
        }

        public Teacher GetTeacherById(int? id)
        {
            return _context.Teachers.Find(id);
        }

        public void AddNewTeacher(Teacher teacher)
        {
            Check.Require(teacher.FirstName);
            Check.Require(teacher.LastName);

            _context.Teachers.Add(teacher);
            _context.SaveChanges();
        }

        public void EditTeacher(Teacher teacher)
        {
            Check.Require(teacher.FirstName);
            Check.Require(teacher.LastName);
            _context.Entry(teacher).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteTeacher(Teacher teacher)
        {
            _context.Teachers.Remove(teacher);
            _context.SaveChanges();
        }

        #endregion

        #region TeamLogic

        public Team GetTeamById(int? id)
        {
            return _context.Teams.Find(id);
        }

        public void AddNewTeam(Team team)
        {
            Check.Require(team.TeamName);

            _context.Teams.Add(team);
            _context.SaveChanges();
        }

        public void EditTeam(Team team)
        {
            Check.Require(team.TeamName);

           _context.Entry(team).State = EntityState.Modified;
           _context.SaveChanges();
        }

        public void DeleteTeam(Team team)
        {
            _context.Teams.Remove(team);
            _context.SaveChanges();
        }
        #endregion

        #region CourseLogic

        public Course GetCourseById(int? id)
        {
            return _context.Courses.Find(id);
        }

        public void AddNewCourse(Course course)
        {
            Check.Require(course.CourseName);
            Check.Require(course.CourseLength.ToString());
            Check.Require(course.CourseDesription);

            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        public void EditCourse(Course course)
        {
            Check.Require(course.CourseName);
            Check.Require(course.CourseLength.ToString());
            Check.Require(course.CourseDesription);

            _context.Entry(course).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteCourse(Course course)
        {
            _context.Courses.Remove(course);
            _context.SaveChanges();
        }

        #endregion

        #region TeamInstanceLogic

        public void AddNewTeamInstance(TeamInstance ti)
        {
            Check.Require(ti.TeamInstanceName);
            _context.TeamInstances.Add(ti);
            _context.SaveChanges();
        }

        public TeamInstance GetTeamInstanceById(int? id)
        {
            return _context.TeamInstances.Find(id);
        }

        public void EditTeamInstance(TeamInstance ti)
        {
            Check.Require(ti.TeamInstanceName);
            _context.Entry(ti).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteTeamInstance(TeamInstance ti)
        {
            _context.TeamInstances.Remove(ti);
            _context.SaveChanges();
        }

        #endregion

        #region TeamInstanceCourseLogic

        public void AddNewTeamInstanceCourse(TeamInstanceCourse teamInstanceCourse)
        {
            _context.TeamInstancesCourses.Add(teamInstanceCourse);
            _context.SaveChanges();
        }

        public TeamInstanceCourse GetTeamInstanceCourseById(int courseId, int teamInstanceId)
        {
            return _context.TeamInstancesCourses.Find(courseId, teamInstanceId);
        }

        public void EditTeamInstanceCourse(TeamInstanceCourse teamInstanceCourse)
        {
            _context.Entry(teamInstanceCourse).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteTeamInstanceCourse(TeamInstanceCourse teamInstanceCourse)
        {
            _context.TeamInstancesCourses.Remove(teamInstanceCourse);
            _context.SaveChanges();
        }

        #endregion


        static class Check
        {
            public static void Require(string value)
            {
                if (value == null)
                    throw new ArgumentNullException();
                if (value.Trim().Length == 0)
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
            if (_disposed || !disposing)
                return;

            if (_context != null)
                _context.Dispose();

            _disposed = true;
        }

        #endregion
    }
}
