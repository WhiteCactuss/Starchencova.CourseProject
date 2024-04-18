using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Wolk.ApplicatonDbContext;
using Wolk.Entites;

namespace Wolk.Views
{
    public class ScheduleViewModel
    {


        /* private ObservableCollection<Subject> _Subjects;
         public ObservableCollection<Subject> Subjects
         {
             get { return _subjects; }
             set
             {
                 if (_subjects != value)
                 {
                     _subjects = value;
                     OnPropertyChanged(nameof(Subjects));
                 }
             }
         }

         private ObservableCollection<Audience> _audiences;
         public ObservableCollection<Audience> Audiences
         {
             get { return _audiences; }
             set
             {
                 if (_audiences != value)
                 {
                     _audiences = value;
                     OnPropertyChanged(nameof(Audiences));
                 }
             }
         }

         private ObservableCollection<Group> _groups;
         public ObservableCollection<Group> Groups
         {
             get { return _groups; }
             set
             {
                 if (_groups != value)
                 {
                     _groups = value;
                     OnPropertyChanged(nameof(Groups));
                 }
             }
         }
        private ObservableCollection<Teacher> _teachers;
         public ObservableCollection<Teacher> Teachers
         {
             get { return _teachers; }
             set
             {
                 if (_teachers != value)
                 {
                     _teachers = value;
                     OnPropertyChanged(nameof(Teachers));
                 }
             }
         }

         private ObservableCollection<Schedule> _schedules;
         public ObservableCollection<Schedule> Schedules
         {
             get { return _schedules; }
             set
             {
                 if (_schedules != value)
                 {
                     _schedules = value;
                     OnPropertyChanged(nameof(Schedules));
                 }
             }
         }

         public ScheduleViewModel()
         {
             Здесь вы можете загрузить данные из базы данных и заполнить коллекции Courses, Teachers и Schedules
             / Просто для примера, создадим пустые коллекции
             Subjects = new ObservableCollection<Subject>();
             Audiences = new ObservableCollection<Audience>();
             Groups = new ObservableCollection<Group>();

             Teachers = new ObservableCollection<Teacher>();

             using (SchoolContext context = new SchoolContext())
             {
                 Schedules = context.Schedules.ToList();
                 var List<Course>? t = context.CourseId
                     .Include(t => t.CourseId)
                     .ToList();
                 Courses = new ObservableCollection<Course>(t);
             }
             Schedules = new ObservableCollection<Schedule>();
         }*/


    }
}
