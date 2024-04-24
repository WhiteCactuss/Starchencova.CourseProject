using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Windows;
using Wolk.ApplicatonDbContext;
using Wolk.Entites;

namespace Wolk.ViewModels;

public class AddGroupViewModel : ReactiveObject
{
	private readonly ObservableCollection<Group> _groups;

	private string _name;

	public string Name
	{
		get { return _name; }
		set { _name = this.RaiseAndSetIfChanged(ref _name, value); }
	}

    public AddGroupViewModel(ObservableCollection<Group> groups)
    {
        _groups = groups;
    }

	public ReactiveCommand<object, Unit> AddGroupCommand => ReactiveCommand.Create<object>(o =>
	{
		if (_name == null)
		{
            MessageBox.Show("Введите название", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			return;
        }

		var group = new Group(_name);

		using(ApplicationDbContext context = new())
		{
			context.Groups.Add(group);
			var result = context.SaveChanges();
			if(result > 0)
			{
                _groups.Add(group);
                MessageBox.Show($"Группа {Name} была добавлена!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }
	});
}
