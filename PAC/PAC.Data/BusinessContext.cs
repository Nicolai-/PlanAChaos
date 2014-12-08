using System;
using System.Collections.Generic;
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

        #region TeamLogic

        public void AddNewTeam(Team team)
        {
            Check.Require(team.TeamName);

            context.Teams.Add(team);
            context.SaveChanges();
        }

        #endregion


        #region TeamInstanceLogic

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
