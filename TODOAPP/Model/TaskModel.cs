using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOAPP.Model
{
    public class TaskModel : INotifyPropertyChanged
    {
        private string _taskName;
        private bool _isCompleted;

        public string TaskName
        {
            get { return _taskName; }
            set
            {
                _taskName = value;
                OnPropertyChanged(nameof(TaskName));
            }
        }

        public bool IsCompleted
        {
            get { return _isCompleted; }
            set
            {
                _isCompleted = value;
                OnPropertyChanged(nameof(IsCompleted));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
