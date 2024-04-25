using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using Wolk.Views;

namespace Wolk.ViewModels;

public class ChangeViewModel
{
    public ReactiveCommand<object, Unit> OpenAudienceWindowCommand => ReactiveCommand.Create<object>(o =>
    {
        new AudiencesWindow().Show();
    });
    public ReactiveCommand<object, Unit> OpenGroupWindowCommand => ReactiveCommand.Create<object>(o =>
    {
        new GroupsWindow().Show();
    });
    public ReactiveCommand<object, Unit> OpenSubjectWindowCommand => ReactiveCommand.Create<object>(o =>
    {
        new SubjectsWindow().Show();
    });
    public ReactiveCommand<object, Unit> OpenTeacherWindowCommand => ReactiveCommand.Create<object>(o =>
    {
        new TeacherWindow().Show();
    });
}
