using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Serialization;
using TODOAPP.Model;

namespace TODOAPP.ViewModel
{
    public class TasksViewModel : INotifyPropertyChanged
    {

        /// <summary>
        /// WILL ADD DESCRIPTION
        /// </summary>
        private ObservableCollection<TaskModel> _tasks;
        public ObservableCollection<TaskModel> Tasks
        {
            get { return _tasks; }
            set
            {
                _tasks = value;
                OnPropertyChanged(nameof(Tasks));
            }
        }
        private TaskModel _selectedTask;
        public TaskModel SelectedTask
        {
            get { return _selectedTask; }
            set
            {
                _selectedTask = value;
                OnPropertyChanged(nameof(SelectedTask));
            }
        }
        public TasksViewModel()
        {
            DeSerializeTask();

        }

        public bool  SerializeTask()
        {
            try
            {
                string filePath = "mytask.xml";
                XmlSerializer ser = new XmlSerializer(typeof(ObservableCollection<TaskModel>));
                using (TextWriter writer = new StreamWriter(filePath))
                {
                    ser.Serialize(writer, Tasks);
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool DeSerializeTask()
        {
            string filePath = "mytask.xml";
            if (File.Exists(filePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<TaskModel>));
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    Tasks = (ObservableCollection<TaskModel>)serializer.Deserialize(fileStream);
                }
            }
            return true;
        }
        public void AddTask(string taskName)
        {
            TaskModel newTask = new TaskModel { TaskName = taskName, IsCompleted = false };
            Tasks.Add(newTask);
            SerializeTask();
        }
        public void DeleteTask(TaskModel myTask)
        {
            if (Tasks.Contains(myTask))
            {
                Tasks.Remove(myTask);
                SerializeTask();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
