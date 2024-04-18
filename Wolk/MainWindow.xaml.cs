using Microsoft.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wolk.ApplicatonDbContext;
using Wolk.Entites;
using Wolk.Views;

namespace Wolk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //LoadComboBoxes();
            ScheduleViewModel viewModel = new ScheduleViewModel();
            //DataContext = viewModel;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 taskWindow = new Window1();
            taskWindow.Show();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            Window2 createdata = new Window2();
            createdata.Show();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Window3 deletedata = new Window3();
            deletedata.Show();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}