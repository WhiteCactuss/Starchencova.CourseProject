﻿using Microsoft.Data.SqlClient;
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

namespace Wolk.Views;

/// <summary>
/// Interaction logic for PreviewWindow.xaml
/// </summary>
public partial class PreviewWindow : Window
{
    public PreviewWindow()
    {
        InitializeComponent();
        //LoadComboBoxes();
        //ScheduleViewModel viewModel = new ScheduleViewModel();
        //DataContext = viewModel;
    }
}