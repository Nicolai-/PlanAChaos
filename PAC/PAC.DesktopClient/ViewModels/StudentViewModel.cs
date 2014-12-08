using System.Runtime.InteropServices;
using PAC.Data;
using PAC.Data.Model;
using PAC.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.DesktopClient.ViewModels
{

    public class StudentViewModel : ViewModel
    {

        public StudentViewModel()
        {
            Students = new ObservableCollection<Student>();
        }

        public ICollection<Student> Students { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }


        public bool IsValid
        {
            get
            {
                return !String.IsNullOrWhiteSpace(FirstName) &&
                       !String.IsNullOrWhiteSpace(LastName);
            }
        }

        public ActionCommand AddStudentCommand
        {
            get
            {
                return new ActionCommand(s => AddStudent(FirstName, LastName, Company),
                                         s => IsValid);
            }
        }

        private void AddStudent(string firstName, string lastName, string company)
        {
            using (var api = new BusinessContext())
            {
                var student = new Student
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Company = company
                };

                try
                {
                    api.AddNewStudent(student);
                }
                catch (Exception)
                {
                    // TODO: In Later session, cover error handling
                    return;
                }
                Students.Add(student);
            }
        }

        public ActionCommand EditStudentCommand
        {
            get
            {
                return new ActionCommand(s => EditStudent(FirstName, LastName, Company),
                                         s => IsValid);
            }
        }

        private void EditStudent(string firstName, string lastName, string company)
        {
            using (var api = new BusinessContext())
            {
                var student = new Student
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Company = company
                };

                try
                {
                    api.EditStudent(student);
                }
                catch (Exception)
                {
                    // TODO: In Later session, cover error handling
                    return;
                }
            }
        }


    }
}
