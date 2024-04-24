using System.Collections.ObjectModel;
using System.Windows;
using Wolk.Entites;
using Wolk.ViewModels;

namespace Wolk.Views
{
    /// <summary>
    /// Логика взаимодействия для AddGroupWindow.xaml
    /// </summary>
    public partial class AddGroupWindow : Window
    {
        public AddGroupWindow(ObservableCollection<Group> groups)
        {
            DataContext = new AddGroupViewModel(groups);
            InitializeComponent();
        }
    }
}
