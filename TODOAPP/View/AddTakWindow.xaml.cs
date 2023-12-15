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
using TODOAPP.ViewModel;

namespace TODOAPP.View
{
    /// <summary>
    /// Interaction logic for AddTakWindow.xaml
    /// </summary>
    public partial class AddTakWindow : Window
    {
        private TasksViewModel _viewModel;

        public AddTakWindow(TasksViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            string taskName = txtTaskName.Text.Trim();
            if (!string.IsNullOrEmpty(taskName))
            {
                _viewModel.AddTask(taskName);
                Close();
            }
            else
            {
                MessageBox.Show("Please enter a task name.");
            }
        }
    }
}