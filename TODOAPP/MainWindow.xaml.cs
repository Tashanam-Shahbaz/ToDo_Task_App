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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TODOAPP.Model;
using TODOAPP.View;
using TODOAPP.ViewModel;

namespace TODOAPP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private TasksViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new TasksViewModel();
            DataContext = _viewModel;

        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            AddTakWindow addTaskWindow = new AddTakWindow(_viewModel);
            addTaskWindow.ShowDialog();
        }


        private void EditTask_Click(object sender, RoutedEventArgs e)
        {
            TaskModel selectedTask = (TaskModel)TasksListView.SelectedItem;
            if (selectedTask != null)
            {   EditTaskWindow editTaskWindow = new EditTaskWindow(_viewModel, selectedTask);
                editTaskWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a task to edit.");
            }
        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            TaskModel selectedTask = (TaskModel)TasksListView.SelectedItem;
            if (selectedTask != null)
            {
               DeleteTaskWindow deleteTaskWindow = new DeleteTaskWindow(_viewModel, selectedTask);
                deleteTaskWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a task to edit.");
            }
        }


    }
}
