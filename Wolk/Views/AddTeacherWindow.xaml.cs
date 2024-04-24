using System.Collections.ObjectModel;
using System.Windows;
using Wolk.Entites;
using Wolk.ViewModels;

namespace Wolk.Views
{
    /// <summary>
    /// Логика взаимодействия для AddTeacherWindow.xaml
    /// </summary>
    public partial class AddTeacherWindow : Window
    {
        public AddTeacherWindow(ObservableCollection<Teacher> teachers)
        {
            DataContext = new AddTeacherViewModel(teachers);
            InitializeComponent();
        }
    }
}
