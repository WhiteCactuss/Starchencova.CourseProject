using ReactiveUI;
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
using ReactiveUI;

namespace Wolk.ViewModels
{
    public class CreateDataViewModel : ReactiveObject
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<string> Classes { get; set; }
        public string SelectedClass { get; set; }
        public string NewItem { get; set; }

        public ICommand AddItemCommand { get; set; }

        private List<Audience> audiences;
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

        public CreateDataViewModel()
        {
            Classes = new ObservableCollection<string> { "Audience", "Group", "Subject", "Teacher" };
            SelectedClass = Classes.FirstOrDefault();

            AddItemCommand = ReactiveCommand.Create(AddItem);
        }
        private void AddItem()
        {
            using (var db = new ApplicationDbContext())
            {
                switch (SelectedClass)
                {
                    case "Audience":
                        var newAudience = new Audience { NumberAudience = NewItem };
                        db.Audiences.Add(newAudience);
                        break;
                    case "Group":
                        var newGroup = new Group { GroupName = NewItem };
                        db.Groups.Add(newGroup);
                        break;
                    case "Teacher":
                        var newTeacher = new Teacher { LastName = NewItem, FirstName = NewItem, MiddleName = NewItem };
                        db.Teachers.Add(newTeacher);
                        break;
                    case "Subject":
                        var newSubject = new Subject { NameSubject = NewItem };
                        db.Subjects.Add(newSubject);
                        break;
                    default:
                        MessageBox.Show("Некорректный ввод");
                        break;
                }

                db.SaveChanges();
                MessageBox.Show("Данные успешно добавлены!");
            }

            NewItem = string.Empty;
            OnPropertyChanged(nameof(NewItem));
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
