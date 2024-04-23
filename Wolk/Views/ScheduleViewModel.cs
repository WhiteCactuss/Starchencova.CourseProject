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

        /*private List<Audience> audiences;
        private string NumberAudience;

        private List<Group> groups;
        private string NameGroup;

        private List<Schedule> Schedules;
        private DateTime Day;
        private int NumberLesson;
        private Guid SubjectId;
        private Guid TeacherId;
        private Guid AudienceId;


        private List<Subject> subjects;
        private string NameSubject;

        private List<Teacher> teachers;
        private string NameTeacher;


        private Subject selectedSubjects;
        private Audience selectedAudience;
        private Group selectedGroups;
        private Schedule selectedSchedules;
        private Teacher selectedTeacher;


        public Audience SelectedAudience
        {
            get => selectedAudience;
            set => this.RaiseAndSetIfChanged(ref selectedAudience, value);
        }
        public Group SelectedGroup
        {
            get => selectedGroups;
            set => this.RaiseAndSetIfChanged(ref selectedGroups, value);
        }
        public Schedule SelectedSchedule
        {
            get => selectedSchedules;
            set => this.RaiseAndSetIfChanged(ref selectedSchedules, value);
        }
        public Subject SelectedSubject
        {
            get => selectedSubjects;
            set => this.RaiseAndSetIfChanged(ref selectedSubjects, value);
        }
        public Teacher SelectedTeacher
        {
            get => selectedTeacher;
            set => this.RaiseAndSetIfChanged(ref selectedTeacher, value);
        }

        /*public ReactiveCommand<object, Unit> CreateUserCommand =>
            ReactiveCommand.Create<object>(o => 
                { 
                    if (string.IsNullOrEmpty(Obj))
                    {
                        MessageBox.Show("error","Error",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                });*/

    }
}
