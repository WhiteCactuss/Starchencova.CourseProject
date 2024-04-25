using System.Collections.ObjectModel;
using System.Windows;
using Wolk.Entites;
using Wolk.ViewModels;

namespace Wolk.Views;

/// <summary>
/// Логика взаимодействия для AddAudienceWindow.xaml
/// </summary>
public partial class AddAudienceWindow : Window
{
    public AddAudienceWindow(ObservableCollection<Audience> audiences)
    {
        DataContext = new AddAudienceViewModel(audiences);
        InitializeComponent();
    }
}
