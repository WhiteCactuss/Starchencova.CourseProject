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

namespace Wolk.ViewModels
{
    public class DeleteDataViewModel : ReactiveObject
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<string> Classes { get; set; }
        public string SelectedClass { get; set; }
        public ObservableCollection<string> Datas { get; set; }
        public string SelectedDatas { get; set; }

        public ICommand DeleteItemCommand { get; set; }
        /*Datas = new ObservableCollection<string>(db.Teachers.Select(t => t.FLMName));*/


        public DeleteDataViewModel()
        {
            Classes = new ObservableCollection<string> { "Audience", "Group", "Subject", "Teacher" };
            Datas = new ObservableCollection<string>();
            SelectedClass = Classes.FirstOrDefault();

            DeleteItemCommand = ReactiveCommand.Create(DeleteItem);

            LoadItems();
        }

        private void DeleteItem()
        {
            using (var db = new ApplicationDbContext())
            {
                switch (SelectedClass)
                {
                    case "Audience":
                        var audienceToDelete = db.Audiences.FirstOrDefault(a => a.NumberAudience == SelectedDatas);
                        if (audienceToDelete != null)
                        {
                            db.Audiences.Remove(audienceToDelete);
                        }
                        break;
                    case "Group":
                        var groupToDelete = db.Groups.FirstOrDefault(g => g.GroupName == SelectedDatas);
                        if (groupToDelete != null)
                        {
                            db.Groups.Remove(groupToDelete);
                        }
                        break;
                    case "Subject":
                        var subjectToDelete = db.Subjects.FirstOrDefault(s => s.NameSubject == SelectedDatas);
                        if (subjectToDelete != null)
                        {
                            db.Subjects.Remove(subjectToDelete);
                        }
                        break;
                    case "Teacher":
                        var teacherToDelete = db.Teachers.FirstOrDefault(t => t.FLMName == SelectedDatas);
                        if (teacherToDelete != null)
                        {
                            db.Teachers.Remove(teacherToDelete);
                        }
                        break;
                    default:
                            MessageBox.Show("Данные не удалены!");
                        break;
                }
                MessageBox.Show("Данные успешно удалены!");
                db.SaveChanges();
            }

            LoadItems();
        }

        private void LoadItems()
        {
            using (var db = new ApplicationDbContext())
            {
                switch (SelectedClass)
                {
                    case "Audience":
                        Datas = new ObservableCollection<string>(db.Audiences.Select(a => a.NumberAudience));
                        OnPropertyChanged(nameof(Audience));
                        break;
                    case "Group":
                        Datas = new ObservableCollection<string>(db.Groups.Select(g => g.GroupName));
                        break;
                    case "Subject":
                        Datas = new ObservableCollection<string>(db.Subjects.Select(s => s.NameSubject));
                        break;
                    case "Teacher":
                        Datas = new ObservableCollection<string>(db.Teachers.Select(t => t.FLMName));
                        break;
                    default:
                        break;
                }
            }

            OnPropertyChanged(nameof(Datas));
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
