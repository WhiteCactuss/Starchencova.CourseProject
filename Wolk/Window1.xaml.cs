using Microsoft.EntityFrameworkCore;
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
using Wolk.ApplicatonDbContext;
using Wolk.Entites;
using Wolk.Views;

namespace Wolk
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private ApplicationDbContext dbContext = new ApplicationDbContext();
        public ScheduleViewModel ScheduleViewModel { get; set; }

        public Window1()
        {
            InitializeComponent();
            LoadComboBoxes();
            ScheduleViewModel viewModel = new ScheduleViewModel();
            DataContext = viewModel;
        }


        private void LoadComboBoxes()
        {
            SubjectComboBox.ItemsSource = dbContext.Subjects.ToList();
            SubjectComboBox.DisplayMemberPath = "Subject";

            AudienceComboBox.ItemsSource = dbContext.Audiences.ToList();
            AudienceComboBox.DisplayMemberPath = "Audience";
        }
        private void CreateSchedule_Click(object sender, RoutedEventArgs e)
        {
            DateTime selectedDate = datePicker.SelectedDate ?? DateTime.Now;
            Subject selectedSubject = (Subject)SubjectComboBox.SelectedItem;
            Teacher selectedTeacher = (Teacher)TeacherComboBox.SelectedItem;
            Audience selectedAudience = (Audience)AudienceComboBox.SelectedItem;

            Schedule newSchedule = new Schedule
            {
                ScheduleId = Guid.NewGuid(),
                Day = selectedDate,
                //NumberLesson = Convert.ToInt32(numberLessonTextBlock.Text),
                SubjectId = selectedSubject.SubjectId,
                TeacherId = selectedTeacher.TeacherId,
                AudienceId = selectedAudience.AudienceId,
            };
            Audience newAudience = new Audience
            {
                AudienceId = selectedAudience.AudienceId,
            };
            dbContext.Audiences.Add(newAudience);
            dbContext.SaveChanges();

            MessageBox.Show("Schedule created successfully!");
        }
    }
}
