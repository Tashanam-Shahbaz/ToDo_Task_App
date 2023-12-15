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
using TODOAPP.Model;
using TODOAPP.ViewModel;

namespace TODOAPP.View
{
    /// <summary>
    /// Interaction logic for EditTaskWindow.xaml
    /// </summary>
    public partial class EditTaskWindow : Window
    {
        private TasksViewModel _viewModel;
        private TaskModel _selectedTask;

        public EditTaskWindow(TasksViewModel viewModel, TaskModel selectedTask)
        {
            InitializeComponent();
            _viewModel = viewModel;
            _selectedTask = selectedTask;
            txtTaskName.Text = _selectedTask.TaskName;
        }

        private void UpdateTask_Click(object sender, RoutedEventArgs e)
        {
            string taskName = txtTaskName.Text.Trim();
            if (!string.IsNullOrEmpty(taskName))
            {
                _selectedTask.TaskName = taskName;
                // You can implement any additional logic needed here

                Close();
            }
            else
            {
                MessageBox.Show("Please enter a task name.");
            }
        }
    }
}
