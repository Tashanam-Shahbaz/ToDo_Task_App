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
    /// Interaction logic for DeleteTaskWindow.xaml
    /// </summary>
    public partial class DeleteTaskWindow : Window
    {
        private TasksViewModel _viewModel;
        private TaskModel _selectedTask;

        public DeleteTaskWindow(TasksViewModel viewModel, TaskModel selectedTask)
        {
            InitializeComponent();
            _viewModel = viewModel;
            _selectedTask = selectedTask;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.DeleteTask(_selectedTask);
            Close();
        }
    }
}
