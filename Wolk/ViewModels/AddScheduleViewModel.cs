using DynamicData;
using DynamicData.Binding;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Windows;
using Wolk.ApplicatonDbContext;
using Wolk.Entites;
using Wolk.Views;

namespace Wolk.ViewModels;
//WhiteCactuss
//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
//https://github.com/WhiteCactuss/Starchencova.CourseProject.git
public class AddScheduleViewModel : ReactiveObject
{
    private readonly ObservableCollection<Schedule> _schedules;
    private readonly ObservableCollection<Audience> _audiences;
    private readonly ObservableCollection<Group> _groups;
    private readonly ObservableCollection<Subject> _subjects;
    private readonly ObservableCollection<Teacher> _teachers;

    //ApplicationDbContext context = new ApplicationDbContext();

    public ObservableCollection<Schedule> Schedules => _schedules;
    public ObservableCollection<Audience> Audiences => _audiences;
    public ObservableCollection<Group> Groups => _groups;
    public ObservableCollection<Subject> Subjects => _subjects;
    public ObservableCollection<Teacher> Teachers => _teachers;

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
        using (var context = new ApplicationDbContext())
        {
            _schedules = new ObservableCollection<Schedule>(
            context.Schedules
                .Include(x => x.Teacher)
                .Include(x => x.Audience)
                .Include(x => x.Group)
                .Include(x => x.Subject)
                .ToList());

            _audiences = new ObservableCollection<Audience>( context.Audiences.ToList());
            _groups = new ObservableCollection<Group>(context.Groups.ToList());
            _subjects = new ObservableCollection<Subject>(context.Subjects.ToList());
            _teachers = new ObservableCollection<Teacher>(context.Teachers.ToList());
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

        using (var context = new ApplicationDbContext())
        {
            var schedule = new Schedule(
                _date,
                0,
                _subject.Id,
                _teacher.Id,
                _audience.Id,
                _group.Id);

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
        using (var context = new ApplicationDbContext())
        {
            context.Schedules.Remove(_schedule);
            var result = context.SaveChanges();
            if (result > 0)
            {
                Schedules.Remove(_schedule);
            }
        }
    });

    public ReactiveCommand<object, Unit> UpdateDatasCommand => ReactiveCommand.Create<object>(async o =>
    {
        using (var context = new ApplicationDbContext())
        {
            _audiences.Clear();
            _groups.Clear();
            _subjects.Clear();
            _teachers.Clear();

            Audiences.AddRange(context.Audiences.ToList());
            Groups.AddRange(context.Groups.ToList());
            Subjects.AddRange(context.Subjects.ToList());
            Teachers.AddRange(context.Teachers.ToList());
        }
    });

    public ReactiveCommand<object, Unit> OpenChangeClassesDatasWindowCommand => ReactiveCommand.Create<object>(o =>
    {
        new ChangeClassesDatasWindow().Show();
    });
    public ReactiveCommand<object, Unit> OpenPreviewWindowCommand => ReactiveCommand.Create<object>(o =>
    {
        new PreviewWindow().Show();
    });
}
