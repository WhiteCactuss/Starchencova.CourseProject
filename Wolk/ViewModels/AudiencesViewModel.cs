using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;
using Wolk.ApplicatonDbContext;
using Wolk.Entites;
using Wolk.ViewModels;
using Wolk.Views;

namespace Wolk.ViewModels;

public class AudiencesViewModel : ReactiveObject
{
	private readonly ObservableCollection<Audience> _audiences;

	public ObservableCollection<Audience> Audiences { get; set; }

	private Audience _selectedAudience;

	public Audience SelectedAudience
    {
		get => _selectedAudience;
		set => this.RaiseAndSetIfChanged(ref _selectedAudience, value);
	}

	public AudiencesViewModel()
    {
		using(ApplicationDbContext context = new())
		{
            Audiences = new ObservableCollection<Audience>(context.Audiences.ToList());
		}
    }

	public ReactiveCommand<object, Unit> RemoveAudienceCommand => ReactiveCommand.Create<object>(o =>
	{
        using (ApplicationDbContext context = new())
        {
			context.Audiences.Remove(SelectedAudience);
			var result = context.SaveChanges();
			if(result > 0)
			{
                Audiences.Remove(SelectedAudience);
            }
        }
    });

	public ReactiveCommand<object, Unit> OpenAddAudienceWindowCommand => ReactiveCommand.Create<object>(o =>
	{
		new AddAudienceWindow(Audiences).Show();
	});
}
