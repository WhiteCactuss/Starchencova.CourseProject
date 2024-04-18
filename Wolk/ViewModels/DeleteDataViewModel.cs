using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Wolk.ApplicatonDbContext;
using Wolk.Entites;

namespace Wolk.ViewModels
{
    public class DeleteDataViewModel : ReactiveObject
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<string> Classes { get; set; }
        public string SelectedClass { get; set; }
        public ObservableCollection<string> Items { get; set; }
        public string SelectedItem { get; set; }
        public ICommand DeleteItemCommand { get; set; }



        public DeleteDataViewModel()
        {
            Classes = new ObservableCollection<string> { "Audience", "Group", "Subject", "Teacher" };
            SelectedClass = Classes.FirstOrDefault();

            DeleteItemCommand = ReactiveCommand.Create(DeleteItem);
        }
        private void DeleteItem()
        {
            using (var db = new ApplicationDbContext())
            {
                switch (SelectedClass)
                {
                    case "Audience":
                        var audienceToDelete = db.Audiences.FirstOrDefault(a => a.NumberAudience == SelectedItem);
                        if (audienceToDelete != null)
                        {
                            db.Audiences.Remove(audienceToDelete);
                        }
                        break;
                    case "Group":
                        var groupToDelete = db.Groups.FirstOrDefault(g => g.GroupName == SelectedItem);
                        if (groupToDelete != null)
                        {
                            db.Groups.Remove(groupToDelete);
                        }
                        break;
                    case "Subject":
                        var subjectToDelete = db.Subjects.FirstOrDefault(s => s.NameSubject == SelectedItem);
                        if (subjectToDelete != null)
                        {
                            db.Subjects.Remove(subjectToDelete);
                        }
                        break;
                    case "Teacher":
                        var teacherToDelete = db.Teachers.FirstOrDefault(t => t.LastName == SelectedItem);
                        if (teacherToDelete != null)
                        {
                            db.Teachers.Remove(teacherToDelete);
                        }
                        break;
                    default:
                        break;
                }

                db.SaveChanges();
            }

            LoadItems();
        }

        private void LoadItems()
        {
            switch (SelectedClass)
            {
                case "Audience":
                    Items = new ObservableCollection<string>(db.Audiences.Select(a => a.NumberAudience));
                    break;
                case "Group":
                    Items = new ObservableCollection<string>(db.Groups.Select(g => g.GroupName));
                    break;
                case "Subject":
                    Items = new ObservableCollection<string>(db.Subjects.Select(s => s.NameSubject));
                    break;
               case "Teacher":
                    Items = new ObservableCollection<string>(db.Teachers.Select(t => t.LastName));
                    break;
                default:
                    break;
            }
            OnPropertyChanged(nameof(Items));
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
