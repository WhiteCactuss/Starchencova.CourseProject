using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;
using Wolk.ApplicatonDbContext;
using Wolk.Entites;
using Wolk.Views;

namespace Wolk.ViewModels;

public class SubjectsViewModel : ReactiveObject
{
	private readonly ObservableCollection<Subject> _subjects;

	public ObservableCollection<Subject> Subjects { get; set; }

	private Subject _selectedSubject;

	public Subject SelectedSubject
	{
		get => _selectedSubject;
		set => this.RaiseAndSetIfChanged(ref _selectedSubject, value);
	}

	public SubjectsViewModel()
    {
		using(ApplicationDbContext context = new())
		{
			//OpenExisting.ItemsSource = dt.DefaultView
			Subjects = new ObservableCollection<Subject>(context.Subjects.ToList());
		}
    }

	public ReactiveCommand<object, Unit> RemoveSubjectCommand => ReactiveCommand.Create<object>(o =>
	{
        using (ApplicationDbContext context = new())
        {
			context.Subjects.Remove(SelectedSubject);
			var result = context.SaveChanges();
			if(result > 0)
			{
                Subjects.Remove(SelectedSubject);
            }
        }
    });

	public ReactiveCommand<object, Unit> OpenAddSubjectWindowCommand => ReactiveCommand.Create<object>(o =>
	{
		new AddSubjectWindow(Subjects).Show();
	});
}
