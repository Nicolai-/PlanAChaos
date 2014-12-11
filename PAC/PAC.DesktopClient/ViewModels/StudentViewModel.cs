// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StudentViewModel.cs" company="J.N Systems">
//   .
// </copyright>
// <summary>
//   Defines the StudentViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PAC.DesktopClient.ViewModels
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using PAC.Data;
    using PAC.Data.Model;
    using PAC.DesktopClient.Views;
    using PAC.Windows;

    /// <summary>
    /// The student view model.
    /// </summary>
    public class StudentViewModel : ViewModel, IPageViewModel
    {
        #region Fields

        /// <summary>
        /// The child view model.
        /// </summary>
        private readonly StudentViewModel childViewModel;

        /// <summary>
        /// The first name.
        /// </summary>
        private string firstName;

        /// <summary>
        /// The last name.
        /// </summary>
        private string lastName;

        /// <summary>
        /// The company.
        /// </summary>
        private string company;

        /// <summary>
        /// The success.
        /// </summary>
        private string success;

        /// <summary>
        /// The selected student.
        /// </summary>
        private Student selectedStudent = new Student();

        /// <summary>
        /// The students list.
        /// </summary>
        private MyObservableCollection<Student> students;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentViewModel"/> class.
        /// It fetches all Students from the database and makes them visible for the view through the Students property
        /// which is a MyObservableCollection.
        /// </summary>
        public StudentViewModel()
        {
            this.childViewModel = this;
            this.students = new MyObservableCollection<Student>();
            try
            {
                var bc = new BusinessContext();
                foreach (var student in bc.GetAllStudents())
                {
                    this.Students.Add(student);
                }
            }
            catch (Exception)
            {
                // TODO: Cover error handling
            }
        }

        #region Properties/Commands

        /// <summary>
        /// Gets or sets the students.
        /// </summary>
        public MyObservableCollection<Student> Students
        {
            get
            {
                return this.students;
            }

            set
            {
                this.students = value;
                    this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the selected student.
        /// </summary>
        public Student SelectedStudent
        {
            get
            {
                return this.selectedStudent;
            }

            set
            {
                this.selectedStudent = value;
                this.NotifyPropertyChanged();
            } 
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name
        {
            get { return "Student"; }
        }

        /// <summary>
        /// Gets or sets the success.
        /// </summary>
        public string Success
        {
            get
            {
                return this.success;
            }
           
            set
            {
                this.success = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (value != this.firstName)
                {
                    this.firstName = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (value == this.lastName)
                {
                    return;
                }

                this.lastName = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        public string Company
        {
            get
            {
                return this.company;
            }

            set
            {
                if (value == this.company)
                {
                    return;
                }

                this.company = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets the create student command accessible from the view.
        /// </summary>
        public ActionCommand CreateStudentCommand
        {
            get
            {
                return new ActionCommand(s => this.CreateStudent());
            }
        }

        /// <summary>
        /// Gets the add student command accessible from the view.
        /// </summary>
        public ActionCommand AddStudentCommand
        {
            get
            {
                return new ActionCommand(s => this.AddStudent(this.FirstName, this.LastName, this.Company), s => this.IsValid);
            }
        }

        /// <summary>
        /// Gets the edit student command accessible from the view.
        /// </summary>
        public ActionCommand EditStudentCommand
        {
            get
            {
                return new ActionCommand(s => this.EditStudent());
            }
        }

        /// <summary>
        /// Gets the save student command accessible from the view.
        /// </summary>
        public ActionCommand<Student> SaveStudentCommand
        {
            get
            {
                return new ActionCommand<Student>(
                    s => this.SaveStudent(this.SelectedStudent));
            }
        }

        /// <summary>
        /// Gets the delete student command accessible from the view.
        /// </summary>
        public ActionCommand<Student> DeleteStudentCommand
        {
            get
            {
                return new ActionCommand<Student>(
                    s => this.DeleteStudent(this.SelectedStudent));
            }
        }

        /// <summary>
        /// Gets a value indicating whether is valid.
        /// </summary>
        public bool IsValid
        {
            [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1121:UseBuiltInTypeAlias", Justification = "Reviewed. Suppression is OK here.")]
            get
            {
                return !String.IsNullOrWhiteSpace(this.FirstName) &&
                       !String.IsNullOrWhiteSpace(this.LastName);
            }
        }
        #endregion

        #region Methods

        /// <summary>
        /// The command to launch the CreateStudentView
        /// </summary>
        private void CreateStudent()
        {
            var view = new CreateStudentView { DataContext = this.childViewModel };
            view.Show();
            //TODO : Close child window on button press in view

        }

        /// <summary>
        /// The command to launch the EditStudentView
        /// </summary>
        private void EditStudent()
        {
            var view = new EditStudentView { DataContext = this.childViewModel };
            view.ShowDialog();
            //TODO : Close child window on button press in view

        }

        /// <summary>
        /// The add student.
        /// </summary>
        /// <param name="studentFirstName">
        /// The first name.
        /// </param>
        /// <param name="studentLastName">
        /// The last name.
        /// </param>
        /// <param name="studentCompany">
        /// The studentCompany.
        /// </param>
        private void AddStudent(string studentFirstName, string studentLastName, string studentCompany)
        {
            using (var api = new BusinessContext())
            {
                var student = new Student
                {
                    FirstName = studentFirstName,
                    LastName = studentLastName,
                    Company = studentCompany
                };

                try
                {
                    api.AddNewStudent(student);
                }
                catch (Exception)
                {
                    // TODO: Cover error handling
                }

                this.Success = "Student " + this.FirstName + " " + this.LastName + " added";
                this.Students.Add(student);
            }
        }

        /// <summary>
        /// The method for saving changes to an entity
        /// It will locate the existing entity and do the changes and save.
        /// </summary>
        /// <param name="student">
        /// The student.
        /// </param>
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

                this.Success = "Student " + student.FirstName + " " + student.LastName + " saved!";
                int index = this.Students.IndexOf(student);
                this.Students.ReplaceItem(index, student);
            }
        }

        /// <summary>
        /// The delete student.
        /// Locates the existing student and deletes it.
        /// </summary>
        /// <param name="student">
        /// The student.
        /// </param>
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

                this.Students.Remove(student);
            }
        }

        #endregion
    }
}
