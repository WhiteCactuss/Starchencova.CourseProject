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
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reactive.Subjects;

namespace Wolk.ViewModels
{
    public class CreateScheduleViewModel : ReactiveObject
    {
        public event PropertyChangedEventHandler PropertyChanged;

        ApplicationDbContext db = new ApplicationDbContext();

        public ObservableCollection<string> Audience { get; set; }
        public string SelectedAudience { get; set; }
        public ObservableCollection<string> Subject { get; set; }
        public string SelectedSubject { get; set; }
        public ObservableCollection<string> Teacher { get; set; }
        public string SelectedTeacher { get; set; }
        public ObservableCollection<string> Group { get; set; }
        public string SelectedGroup { get; set; }
        public ObservableCollection<string> Schedule { get; set; }
        public string SelectedSchedule { get; set; }

        private DateTime selectedDate;
        public DateTime SelectedDate
        {
            get => selectedDate;
            set => this.RaiseAndSetIfChanged(ref selectedDate, value);
        }
        public string NewItem { get; set; }

        public ICommand AddItemCommand { get; set; }

        public CreateScheduleViewModel()
        {
            SelectedAudience = Audience.FirstOrDefault();
            SelectedSubject = Subject.FirstOrDefault();
            SelectedTeacher = Teacher.FirstOrDefault();

            /*SearchItemCommand = ReactiveCommand.Create(SearchCommand);
            CreateItemCommand = ReactiveCommand.Create(CreateCommand);
            /*DeleteItemCommand = ReactiveCommand.Create(DeleteCommand);
            SaveItemCommand = ReactiveCommand.Create(SaveCommand);*/

            CreateCommand();
        }
        private void CreateCommand()
        {
            using (var db = new ApplicationDbContext())
            {
                Schedule newSchedule = new Schedule();

                db.Schedules.Add(newSchedule);
                db.SaveChanges();
                MessageBox.Show("Данные успешно добавлены!");
                NewItem = string.Empty;
                OnPropertyChanged(nameof(NewItem));
            }
        }
        private void LoadItems()
        {
            using (var db = new ApplicationDbContext())
            {
                Audience = new ObservableCollection<string>(db.Audiences.Select(a => a.NumberAudience));
                OnPropertyChanged(nameof(Audience));

                Subject = new ObservableCollection<string>(db.Subjects.Select(a => a.NameSubject));
                OnPropertyChanged(nameof(Subject));

                Teacher = new ObservableCollection<string>(db.Teachers.Select(a => a.FLMName));
                OnPropertyChanged(nameof(Teacher));
            }
        }
        private void DeleteItem()
        {
            using (var db = new ApplicationDbContext())
            {
                /*var scheduleToDelete = db.Schedules.FirstOrDefault(a => a.NumberAudience == SelectedDatas);
                if (scheduleToDelete != null)
                {
                    db.Audiences.Remove(scheduleToDelete);
                }

                MessageBox.Show("Данные успешно удалены!");
                db.SaveChanges();*/
            }

            LoadItems();
        }
        private void Initialize()
        {

            using (var db = new ApplicationDbContext())
            {
                /*Audiences = new ObservableCollection<Audience>(db.Audiences.ToList());
                Groups = new ObservableCollection<Group>(db.Groups.ToList());
                Teachers = new ObservableCollection<Teacher>(db.Teachers.ToList());
                Subjects = new ObservableCollection<Subject>(db.Subjects.ToList());
                Date = SelectedDate;


                db.Schedules.Add(newSchedule);
                db.SaveChanges();

                LoadItems();
                Schedules = new ObservableCollection<Schedule>(db.Schedules.ToList());*/
            }
        }
    
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}