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
                        var newTeacher = new Teacher { FLMName = NewItem };
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
