using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;
using Wolk.ApplicatonDbContext;
using Wolk.Entites;
using Wolk.Views;

namespace Wolk.ViewModels;

public class TeachersViewModel : ReactiveObject
{
	private readonly ObservableCollection<Teacher> _teachers;

	public ObservableCollection<Teacher> Teachers { get; set; }

	private Teacher _selectedTeacher;

	public Teacher SelectedTeacher
	{
		get => _selectedTeacher;
		set => this.RaiseAndSetIfChanged(ref _selectedTeacher, value);
	}

	public TeachersViewModel()
    {
		using(ApplicationDbContext context = new())
		{
			Teachers = new ObservableCollection<Teacher>(context.Teachers.ToList());
		}
    }

	public ReactiveCommand<object, Unit> RemoveTeacherCommand => ReactiveCommand.Create<object>(o =>
	{
        using (ApplicationDbContext context = new())
        {
			context.Teachers.Remove(SelectedTeacher);
			var result = context.SaveChanges();
			if(result > 0)
			{
                Teachers.Remove(SelectedTeacher);
            }
        }
    });

	public ReactiveCommand<object, Unit> OpenAddTeacherWindowCommand => ReactiveCommand.Create<object>(o =>
	{
		new AddTeacherWindow(Teachers).Show();
	});
}
