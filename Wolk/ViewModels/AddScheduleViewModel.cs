using DynamicData;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Windows;
using Wolk.ApplicatonDbContext;
using Wolk.Entites;
using Wolk.Views;

namespace Wolk.ViewModels;

public class AddScheduleViewModel : ReactiveObject
{
    private readonly ObservableCollection<Schedule> _schedules;
    private readonly List<Audience> _audiences;
    private readonly List<Group> _groups;
    private readonly List<Subject> _subjects;
    private readonly List<Teacher> _teachers;

    public ObservableCollection<Schedule> Schedules => _schedules;
    public List<Audience> Audiences => _audiences;
    public List<Group> Groups => _groups;
    public List<Subject> Subjects => _subjects;
    public List<Teacher> Teachers => _teachers;

    private Audience _audience;
    public Audience Audience
    {
        get { return _audience; }
        set { _audience = this.RaiseAndSetIfChanged(ref _audience, value); }
    }

    private Group _group;
    public Group Group
    {
        get { return _group; }
        set { _group = this.RaiseAndSetIfChanged(ref _group, value); }
    }

    private Subject _subject;
    public Subject Subject
    {
        get { return _subject; }
        set { _subject = this.RaiseAndSetIfChanged(ref _subject, value); }
    }

    private Teacher _teacher;
    public Teacher Teacher
    {
        get { return _teacher; }
        set { _teacher = this.RaiseAndSetIfChanged(ref _teacher, value); }
    }

    private DateTime _date;
    public DateTime Date 
    { 
        get => _date;
        set => this.RaiseAndSetIfChanged(ref _date, value); 
    }

    public AddScheduleViewModel()
    {
        using(ApplicationDbContext context = new())
        {
            _schedules = new ObservableCollection<Schedule>(
                context.Schedules
                    .Include(x => x.Teacher)
                    .Include(x => x.Audience) 
                    .Include(x => x.Group)
                    .Include(x => x.Subject)
                    .ToList());

            _audiences = context.Audiences.ToList();
            _groups = context.Groups.ToList();
            _subjects = context.Subjects.ToList();
            _teachers = context.Teachers.ToList();
        }
    }

    public ReactiveCommand<object, Unit> AddScheduleCommand => ReactiveCommand.Create<object>(o =>
    {
        if (_audience == null)
        {
            MessageBox.Show("Укажите аудиторию", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (_group == null)
        {
            MessageBox.Show("Укажите группу", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (_subject == null)
        {
            MessageBox.Show("Укажите дисциплину", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (_teacher == null)
        {
            MessageBox.Show("Укажите преподавателя", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        var schedule = new Schedule(
            _date, 
            0,
            _subject.Id, 
            _teacher.Id, 
            _audience.Id, 
            _group.Id);

        using(ApplicationDbContext context = new())
        {
            context.Schedules.Add(schedule);
            var result = context.SaveChanges();
            if (result > 0)
                _schedules.Add(new Schedule(
                    schedule.Id,
                    schedule.Date,
                    schedule.LessonNumber,
                    _subject,
                    _teacher,
                    _audience,
                    _group));
        }
    });

    private Schedule _schedule;
    public Schedule Schedule
    {
        get => _schedule;
        set => this.RaiseAndSetIfChanged(ref _schedule, value);
    }
   
    public ReactiveCommand<object, Unit> DeleteScheduleCommand => ReactiveCommand.Create<object>(o =>
    {
        using (ApplicationDbContext context = new())
        {
            context.Schedules.Remove(_schedule);
            var result = context.SaveChanges();
            if (result > 0)
            {
                Schedules.Remove(_schedule);
            }
        }
    });

    public ReactiveCommand<object, Unit> OpenChangeClassesDatasWindowCommand => ReactiveCommand.Create<object>(o =>
    {
        new ChangeClassesDatasWindow().Show();
    });

}
