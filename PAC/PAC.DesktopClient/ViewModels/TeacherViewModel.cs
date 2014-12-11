using PAC.Data;
using PAC.Data.Model;
using PAC.DesktopClient.Views;
using PAC.Windows;
using System;

namespace PAC.DesktopClient.ViewModels
{
    class TeacherViewModel : ViewModel, IPageViewModel
    {
        #region Fields
        private TeacherViewModel childViewModel;
        private string _firstName;
        private string _lastName;
        private string _success;
        private MyObservableCollection<Teacher> _teachers;
        private Teacher _selectedTeacher = new Teacher();
     
        #endregion

         public TeacherViewModel()
        {
            childViewModel = this;
            _teachers = new MyObservableCollection<Teacher>();
            try
            {
                var bc = new BusinessContext();
                foreach (Teacher teacher in bc.GetAllTeachers())
                {
                    Teachers.Add(teacher);
                }
            }
            catch (Exception)
            {
                // TODO: Cover error handling
            }

        }

         #region Properties/Commands
         public MyObservableCollection<Teacher> Teachers{
             get { return _teachers; }
             set
             {
                 _teachers = value;
                 NotifyPropertyChanged("Teachers");
             } 
         }

         public Teacher SelectedTeacher
         {
             get { return _selectedTeacher; }
             set
             {
                 _selectedTeacher = value;
                 NotifyPropertyChanged("SelectedTeacher");
             }
         }
         public string Name
         {
             get { return "Teacher"; }
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

         public ActionCommand CreateTeacherCommand
         {
             get
             {
                 return new ActionCommand(s => CreateTeacher()
                     , s => true);
             }
         }

         public ActionCommand AddTeacherCommand
         {
             get
             {
                 return new ActionCommand(s => AddTeacher(FirstName, LastName),
                                          s => IsValid);
             }
         }

         public ActionCommand<Teacher> EditTeacherCommand
         {
             get
             {
                 return new ActionCommand<Teacher>(
                      s => EditTeacher(),
                      s => true);
             }
         }

         public ActionCommand<Teacher> SaveTeacherCommand
         {
             get
             {
                 return new ActionCommand<Teacher>(
                      s => SaveTeacher(SelectedTeacher),
                      s => true);
             }
         }

         public ActionCommand<Teacher> DeleteTeacherCommand
         {
             get
             {
                 return new ActionCommand<Teacher>(
                      s => DeleteTeacher(SelectedTeacher),
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

         private void CreateTeacher()
         {
             var view = new CreateTeacherView {DataContext = childViewModel};
             view.Show();
         }

         private void EditTeacher()
         {
             var view = new EditTeacherView {DataContext = childViewModel};
             view.ShowDialog();
         }

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
                 Success = "Teacher " + FirstName + " " + LastName + " added";
                 Teachers.Add(teacher);
             }
         }

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
                 Success = "Teacher " + teacher.FirstName + " " + teacher.LastName + " saved!";
                 int index = Teachers.IndexOf(teacher);
                 Teachers.ReplaceItem(index, teacher);
             }
         }

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
                 Teachers.Remove(teacher);
             }
         }
         #endregion



    }
}
