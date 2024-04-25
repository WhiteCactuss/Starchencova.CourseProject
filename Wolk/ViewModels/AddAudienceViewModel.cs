using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Windows;
using Wolk.ApplicatonDbContext;
using Wolk.Entites;

namespace Wolk.ViewModels;

public class AddAudienceViewModel : ReactiveObject
{
	private readonly ObservableCollection<Audience> _audiences;

	private string _name;

	public string Name
	{
		get { return _name; }
		set { _name = this.RaiseAndSetIfChanged(ref _name, value); }
	}

    public AddAudienceViewModel(ObservableCollection<Audience> audiences)
    {
        _audiences = audiences;
    }

	public ReactiveCommand<object, Unit> AddAudienceCommand => ReactiveCommand.Create<object>(o =>
	{
		if (_name == null)
		{
            MessageBox.Show("Введите название", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			return;
        }

		var audience = new Audience(_name);

		using(ApplicationDbContext context = new())
		{
			context.Audiences.Add(audience);
			var result = context.SaveChanges();
			if(result > 0)
			{
                _audiences.Add(audience);
                MessageBox.Show($"Аудитория {Name} была добавлена!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }
	});
}
