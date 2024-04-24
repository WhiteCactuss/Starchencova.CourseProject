using System.Collections.ObjectModel;
using System.Windows;
using Wolk.Entites;
using Wolk.ViewModels;

namespace Wolk.Views
{
    /// <summary>
    /// Логика взаимодействия для AddSubjectWindow.xaml
    /// </summary>
    public partial class AddSubjectWindow : Window
    {
        public AddSubjectWindow(ObservableCollection<Subject> subjects)
        {
            DataContext = new AddSubjectViewModel(subjects);
            InitializeComponent();
        }
    }
}
