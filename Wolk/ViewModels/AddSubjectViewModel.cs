using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Windows;
using Wolk.ApplicatonDbContext;
using Wolk.Entites;

namespace Wolk.ViewModels;

public class AddSubjectViewModel : ReactiveObject
{
	private readonly ObservableCollection<Subject> _subjects;

	private string _name;

	public string Name
	{
		get { return _name; }
		set { _name = this.RaiseAndSetIfChanged(ref _name, value); }
	}

    public AddSubjectViewModel(ObservableCollection<Subject> subjects)
    {
        _subjects = subjects;
    }

	public ReactiveCommand<object, Unit> AddSubjectCommand => ReactiveCommand.Create<object>(o =>
	{
		if (_name == null)
		{
            MessageBox.Show("Введите название", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			return;
        }

		var subject = new Subject(_name);

		using(ApplicationDbContext context = new())
		{
			context.Subjects.Add(subject);
			var result = context.SaveChanges();
			if(result > 0)
			{
                _subjects.Add(subject);
                MessageBox.Show($"Дисциплина {Name} была добавлена!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }
	});
}
