using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;
using Wolk.ApplicatonDbContext;
using Wolk.Entites;
using Wolk.Views;

namespace Wolk.ViewModels;

public class GroupsViewModel : ReactiveObject
{
	private readonly ObservableCollection<Group> _groups;

	public ObservableCollection<Group> Groups { get; set; }

	private Group _selectedGroup;

	public Group SelectedGroup
	{
		get => _selectedGroup;
		set => this.RaiseAndSetIfChanged(ref _selectedGroup, value);
	}

	public GroupsViewModel()
    {
		using(ApplicationDbContext context = new())
		{
			Groups = new ObservableCollection<Group>(context.Groups.ToList());
		}
    }

	public ReactiveCommand<object, Unit> RemoveGroupCommand => ReactiveCommand.Create<object>(o =>
	{
        using (ApplicationDbContext context = new())
        {
			context.Groups.Remove(SelectedGroup);
			var result = context.SaveChanges();
			if(result > 0)
			{
                Groups.Remove(SelectedGroup);
            }
        }
    });

	public ReactiveCommand<object, Unit> OpenAddGroupWindowCommand => ReactiveCommand.Create<object>(o =>
	{
		new AddGroupWindow(Groups).Show();
	});
}
