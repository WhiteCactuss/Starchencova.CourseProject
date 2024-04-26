using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Wolk.Views
{
    /// <summary>
    /// Логика взаимодействия для AddSchedulesWindow.xaml
    /// </summary>
    public partial class AddSchedulesWindow : Window
    {
        public AddSchedulesWindow()
        {
            InitializeComponent();
        }
        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            Window2 createdata = new Window2();
            createdata.Show();
        }
    }
}
