using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Windows;
using Wolk.ApplicatonDbContext;
using Wolk.Entites;

namespace Wolk.ViewModels;

public class AddTeacherViewModel : ReactiveObject
{
	private readonly ObservableCollection<Teacher> _teachers;

	private string _name;

	public string Name
	{
		get { return _name; }
		set { _name = this.RaiseAndSetIfChanged(ref _name, value); }
	}

    public AddTeacherViewModel(ObservableCollection<Teacher> teachers)
    {
        _teachers = teachers;
    }

	public ReactiveCommand<object, Unit> AddTeacherCommand => ReactiveCommand.Create<object>(o =>
	{
		if (_name == null)
		{
            MessageBox.Show("Введите ФИО", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			return;
        }

		var teacher = new Teacher(_name);

		using(ApplicationDbContext context = new())
		{
			context.Teachers.Add(teacher);
			var result = context.SaveChanges();
			if(result > 0)
			{
                _teachers.Add(teacher);
                MessageBox.Show($"Преподаватель {Name} был добавлен!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }
	});
}
