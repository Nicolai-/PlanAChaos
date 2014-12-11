using PAC.Data;
using PAC.Data.Model;
using PAC.DesktopClient.Views;
using PAC.Windows;
using System;

namespace PAC.DesktopClient.ViewModels
{

    public class StudentViewModel : ViewModel, IPageViewModel
    {
        #region Fields
        private StudentViewModel childViewModel;
        private string _firstName;
        private string _lastName;
        private string _company;
        private string _success;
        private Student _selectedStudent = new Student();
        private MyObservableCollection<Student> _students;
        #endregion

        public StudentViewModel()
        {
            childViewModel = this;
            _students = new MyObservableCollection<Student>();
            try
            {
                var bc = new BusinessContext();
                foreach (Student student in bc.GetAllStudents())
                {
                    Students.Add(student);
                }
            }
            catch (Exception)
            {
                // TODO: Cover error handling
            }

        }

        #region Properties/Commands

        public MyObservableCollection<Student> Students
        {
            get { return _students; }
            set
            {
                   _students = value;
                    NotifyPropertyChanged("Students");
            }
        }

        public Student SelectedStudent {
            get { return _selectedStudent; }
            set
            {
                _selectedStudent = value;
                NotifyPropertyChanged("SelectedStudent");
            } 
        }

        public string Name
        {
            get { return "Student"; }
        }

        public string Success
        {
            get { return _success; }
            set
            {
                _success = value;
                NotifyPropertyChanged("Success");
            }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (value != _firstName)
                {
                    _firstName = value;
                    NotifyPropertyChanged("FirstName");
                }
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (value != _lastName)
                {
                    _lastName = value;
                    NotifyPropertyChanged("LastName");
                }
            }
        }

        public string Company
        {
            get { return _company; }
            set
            {
                if (value != _company)
                {
                    _company = value;
                    NotifyPropertyChanged("Company");
                }
            }
        }
        
        public ActionCommand CreateStudentCommand
        {
            get
            {
                return new ActionCommand(s => CreateStudent()
                    ,s => true);
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

        public ActionCommand EditStudentCommand
        {
            get
            {
                return new ActionCommand(s => EditStudent(),
                                         s => true);
            }
        }

        public ActionCommand<Student> SaveStudentCommand
        {
            get
            {
                return new ActionCommand<Student>(
                    s => SaveStudent(SelectedStudent),
                    s => true);
            }
        }

        public ActionCommand<Student> DeleteStudentCommand
        {
            get
            {
                return new ActionCommand<Student>(
                    s => DeleteStudent(SelectedStudent),
                    s => true);
            }
        }

        #endregion

        #region Methods

        public bool IsValid
        {
            get
            {
                return !String.IsNullOrWhiteSpace(FirstName) &&
                       !String.IsNullOrWhiteSpace(LastName);
            }
        }

        private void CreateStudent()
        {
            var view = new CreateStudentView {DataContext = childViewModel};
            view.Show();
        }

        private void EditStudent()
        {
            var view = new EditStudentView {DataContext = childViewModel};
            view.ShowDialog();
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
                    // TODO: Cover error handling
                }
                Success = "Student " + FirstName + " " + LastName + " added";
                Students.Add(student);
            }
        }

        private void SaveStudent(Student student)
        {
            using (var api = new BusinessContext())
            {
                try
                {
                    var tmpStudent = api.GetStudentById(student.Id);
                    tmpStudent.FirstName = student.FirstName;
                    tmpStudent.LastName = student.LastName;
                    tmpStudent.Company = student.Company;
                    api.EditStudent(tmpStudent);
                }
                catch (Exception)
                {
                    // TODO: Cover error handling
                }
                Success = "Student " + student.FirstName + " " + student.LastName + " saved!";
                int index = Students.IndexOf(student);
                Students.ReplaceItem(index, student);
            }
        }

        private void DeleteStudent(Student student)
        {
            using (var api = new BusinessContext())
            {
                try
                {
                    var tmpStudent = api.GetStudentById(student.Id);
                    api.DeleteStudent(tmpStudent);
                }
                catch (Exception)
                {
                    // TODO: Cover error handling
                }
                Students.Remove(student);
            }
        }

        #endregion



    }

}
