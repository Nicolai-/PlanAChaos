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

         public ActionCommand EditTeacherCommand
         {
             get
             {
                 return new ActionCommand(s => EditTeacher(),
                                          s => true);
             }
         }

         public ActionCommand SaveTeacherCommand
         {
             get
             {
                 return new ActionCommand(s => SaveTeacher(FirstName, LastName),
                                          s => IsValid);
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

         private void SaveTeacher(string firstName, string lastName)
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
                     api.EditTeacher(teacher);
                 }
                 catch (Exception)
                 {
                     // TODO: Cover error handling
                 }
                 Success = "Teacher " + FirstName + " " + LastName + " saved!";
             }
         }

         #endregion



    }
}
