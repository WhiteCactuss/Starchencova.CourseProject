using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wolk.Entites;

namespace Wolk.ViewModels
{
    public class ScheduleWindowViewModel : ReactiveObject
    {


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

    }
}
