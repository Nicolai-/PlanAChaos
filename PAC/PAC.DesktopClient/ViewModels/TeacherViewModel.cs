// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TeacherViewModel.cs" company="J.N Systems">
//   .
// </copyright>
// <summary>
//   The teacher view model class.
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
    /// The teacher view model class.
    /// </summary>
    public class TeacherViewModel : ViewModel, IPageViewModel
    {
        #region Fields

        /// <summary>
        /// The child view model.
        /// </summary>
        private TeacherViewModel childViewModel;

        /// <summary>
        /// The first name variable.
        /// </summary>
        private string firstName;

        /// <summary>
        /// The last name variable.
        /// </summary>
        private string lastName;

        /// <summary>
        /// The success variable. 
        /// </summary>
        private string success;

        /// <summary>
        /// The teachers.
        /// a dynamic data collection that provides notifications when items get added, removed, or when the whole list is refreshed
        /// </summary>
        private MyObservableCollection<Teacher> teachers;

        /// <summary>
        /// The selected teacher.
        /// </summary>
        private Teacher selectedTeacher = new Teacher();
     
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="TeacherViewModel"/> class.
        /// </summary>
        public TeacherViewModel()
        {
            this.childViewModel = this;
            this.teachers = new MyObservableCollection<Teacher>();
            try
            {
                var bc = new BusinessContext();
                foreach (Teacher teacher in bc.GetAllTeachers())
                {
                    this.Teachers.Add(teacher);
                }
            }
            catch (Exception)
            {
                // TODO: Cover error handling
            }
        }

         #region Properties/Commands

        /// <summary>
        /// Gets or sets the teachers.
        /// </summary>
        public MyObservableCollection<Teacher> Teachers
        {
            get
            {
                return this.teachers;
            }

            set
            {
                 this.teachers = value;
                 this.NotifyPropertyChanged();
             } 
         }

        /// <summary>
        /// Gets or sets the selected teacher.
        /// </summary>
        public Teacher SelectedTeacher
        {
            get
            {
                return this.selectedTeacher;
            }

            set
            {
                 this.selectedTeacher = value;
                 this.NotifyPropertyChanged();
             }
         }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name
         {
            get { return "Teacher"; }
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
                 if (value != this.lastName)
                 {
                     this.lastName = value;
                     this.NotifyPropertyChanged();
                 }
             }
         }

        /// <summary>
        /// Gets the create teacher command.
        /// </summary>
        public ActionCommand CreateTeacherCommand
         {
             get
             {
                 return new ActionCommand(s => this.CreateTeacher(), s => true);
             }
         }

        /// <summary>
        /// Gets the add teacher command.
        /// </summary>
        public ActionCommand AddTeacherCommand
         {
             get
             {
                 return new ActionCommand(s => this.AddTeacher(this.FirstName, this.LastName), s => this.IsValid);
             }
         }

        /// <summary>
        /// Gets the edit teacher command.
        /// </summary>
        public ActionCommand<Teacher> EditTeacherCommand
         {
             get
             {
                 return new ActionCommand<Teacher>(
                      s => this.EditTeacher(),
                      s => true);
             }
         }

        /// <summary>
        /// Gets the save teacher command.
        /// </summary>
        public ActionCommand<Teacher> SaveTeacherCommand
         {
             get
             {
                 return new ActionCommand<Teacher>(
                      s => this.SaveTeacher(this.SelectedTeacher),
                      s => true);
             }
         }

        /// <summary>
        /// Gets the delete teacher command.
        /// </summary>
        public ActionCommand<Teacher> DeleteTeacherCommand
         {
             get
             {
                 return new ActionCommand<Teacher>(
                      s => this.DeleteTeacher(this.SelectedTeacher),
                      s => true);
             }
         }

        /// <summary>
        /// Gets a value indicating whether is valid.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1404:CodeAnalysisSuppressionMustHaveJustification", Justification = "Reviewed. Suppression is OK here.")]
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
        /// The create teacher.
        /// </summary>
        private void CreateTeacher()
        {
            var view = new CreateTeacherView { DataContext = this.childViewModel };
            view.Show();
        }

        /// <summary>
        /// The edit teacher.
        /// </summary>
        private void EditTeacher()
        {
            var view = new EditTeacherView { DataContext = this.childViewModel };
            view.ShowDialog();
        }

        /// <summary>
        /// The add teacher.
        /// </summary>
        /// <param name="firstName">
        /// The first name.
        /// </param>
        /// <param name="lastName">
        /// The last name.
        /// </param>
        private void AddTeacher(string firstName, string lastName)
         {
             using (var api = new BusinessContext())
             {
                 var teacher = new Teacher
                 {
                     FirstName = firstName,
                     LastName = lastName,
                 };

                 try
                 {
                     api.AddNewTeacher(teacher);
                 }
                 catch (Exception)
                 {
                     // TODO: Cover error handling
                 }

                 this.Success = "Teacher " + this.FirstName + " " + this.LastName + " added";
                 this.Teachers.Add(teacher);
             }
         }

        /// <summary>
        /// The save teacher.
        /// </summary>
        /// <param name="teacher">
        /// The teacher.
        /// </param>
        private void SaveTeacher(Teacher teacher)
        {
            using (var api = new BusinessContext())
             {
                 try
                 {
                     var tmpTeacher = api.GetTeacherById(teacher.Id);
                     tmpTeacher.FirstName = teacher.FirstName;
                     tmpTeacher.LastName = teacher.LastName;
                     
                     api.EditTeacher(tmpTeacher);
                 }
                 catch (Exception)
                 {
                     // TODO: Cover error handling
                 }

                 this.Success = "Teacher " + teacher.FirstName + " " + teacher.LastName + " saved!";
                 int index = this.Teachers.IndexOf(teacher);
                 this.Teachers.ReplaceItem(index, teacher);
             }
         }

        /// <summary>
        /// The delete teacher.
        /// </summary>
        /// <param name="teacher">
        /// The teacher.
        /// </param>
        private void DeleteTeacher(Teacher teacher)
         {
             using (var api = new BusinessContext())
             {
                 try
                 {
                     var tmpTeacher = api.GetTeacherById(teacher.Id);
                     api.DeleteTeacher(tmpTeacher);
                 }
                 catch (Exception)
                 {
                     // TODO: Cover error handling
                 }

                 this.Teachers.Remove(teacher);
             }
         }

        #endregion
    }
}
